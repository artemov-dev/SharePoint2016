﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.PowerShell;
using System.Management.Automation;
using Microsoft.SharePoint.Administration;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    [Cmdlet(VerbsCommon.New, "CalcServiceApplication", SupportsShouldProcess = true)]
    public class NewCalcServiceApplication : SPCmdlet
    {
        #region cmdlet parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name;

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public SPIisWebServiceApplicationPoolPipeBind ApplicationPool;
        #endregion

        protected override bool RequireUserFarmAdmin()
        {
            return true;
        }

        protected override void InternalProcessRecord()
        {
            #region validation stuff
            // ensure can hit farm
            SPFarm farm = SPFarm.Local;
            if (farm == null)
            {
                ThrowTerminatingError(new InvalidOperationException("SharePoint farm not found."), ErrorCategory.ResourceUnavailable, this);
                SkipProcessCurrentRecord();
            }

            // ensure can hit local server
            SPServer server = SPServer.Local;
            if (server == null)
            {
                ThrowTerminatingError(new InvalidOperationException("SharePoint local server not found."), ErrorCategory.ResourceUnavailable, this);
                SkipProcessCurrentRecord();
            }

            // ensure can hit service application
            CalcService service = farm.Services.GetValue<CalcService>();
            if (service == null)
            {
                ThrowTerminatingError(new InvalidOperationException("Wingtip Calc Service not found (likely not installed)."), ErrorCategory.ResourceUnavailable, this);
                SkipProcessCurrentRecord();
            }

            // ensure can hit app pool
            SPIisWebServiceApplicationPool appPool = this.ApplicationPool.Read();
            if (appPool == null)
            {
                ThrowTerminatingError(new InvalidOperationException("Application pool not found."), ErrorCategory.ResourceUnavailable, this);
                SkipProcessCurrentRecord();
            }
            #endregion

            // verify a service app doesn't already exist
            CalcServiceApplication existingServiceApp = service.Applications.GetValue<CalcServiceApplication>();
            if (existingServiceApp != null)
            {
                WriteError(new InvalidOperationException("Wingtip Calc Service Application already exists."),
                    ErrorCategory.ResourceExists,
                    existingServiceApp);
                SkipProcessCurrentRecord();
            }

            // create & provision the service app
            if (ShouldProcess(this.Name))
            {
                CalcServiceApplication serviceApp = CalcServiceApplication.Create(
                    this.Name,
                    service,
                    appPool);

                // provision the service app
                serviceApp.Provision();

                // pass service app back to the PowerShell
                WriteObject(serviceApp);
            }
        }
    }
}