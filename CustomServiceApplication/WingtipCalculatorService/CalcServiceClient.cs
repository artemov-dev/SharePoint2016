using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    public sealed class CalcServiceClient
    {
        private SPServiceContext _serviceContext;

        public CalcServiceClient(SPServiceContext serviceContext)
        {
            if (serviceContext == null)
                throw new ArgumentNullException("serviceContext");

            _serviceContext = serviceContext;
        }

        public int Add(int x, int y)
        {
            int result = 0;

            // run the call against the application proxy
            CalcServiceApplicationProxy.Invoke(_serviceContext,
                proxy => result = proxy.Add(x, y));

            return result;
        }

        public int Subtract(int x, int y)
        {
            int result = 0;

            // run the call against the application proxy
            CalcServiceApplicationProxy.Invoke(_serviceContext,
                proxy => result = proxy.Subtract(x, y));

            return result;
        }
    }
}
