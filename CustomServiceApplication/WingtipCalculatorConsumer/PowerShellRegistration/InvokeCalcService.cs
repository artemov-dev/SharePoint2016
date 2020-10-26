using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Microsoft.SharePoint.PowerShell;
using Microsoft.SharePoint;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    [Cmdlet("Invoke", "CalcService", SupportsShouldProcess = true)]
    public class InvokeCalcService : SPCmdlet
    {
        private int[] _values;

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public SPServiceContextPipeBind ServiceContext;

        [Parameter(ParameterSetName = "Add", Mandatory = true)]
        public int[] Add
        {
            get { return _values; }
            set { _values = value; }
        }

        protected override void InternalProcessRecord()
        {
            // get the specified service context
            SPServiceContext serviceContext = ServiceContext.Read();
            if (serviceContext == null)
                WriteError(new InvalidOperationException("Invalid service context."), ErrorCategory.ResourceExists, serviceContext);
            else
            {
                CalcServiceClient client = new CalcServiceClient(serviceContext);

                // validate only two values we're passed in
                if (_values.Length != 2)
                    WriteError(new InvalidOperationException("Only two values can be added/subtracted"), ErrorCategory.InvalidArgument, _values);
                else
                {
                    WriteProgress("Executing Calculation", "Sending calculation commands to calculation service application...");
                    int result = client.Add(_values[0], _values[1]);
                    WriteObject(result);
                }
            }
        }
    }
}
