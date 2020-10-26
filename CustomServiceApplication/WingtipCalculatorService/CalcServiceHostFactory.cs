using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;
using Microsoft.SharePoint;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    internal sealed class CalcServiceHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(CalcServiceApplication), baseAddresses);

            // configure the service for claims
            serviceHost.Configure(SPServiceAuthenticationMode.Claims);

            return serviceHost;
        }
    }
}