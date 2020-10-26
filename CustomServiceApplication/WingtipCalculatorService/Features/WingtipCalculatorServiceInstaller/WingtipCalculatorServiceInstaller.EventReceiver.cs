using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Administration;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator.Features.WingtipCalculatorServiceInstaller
{
    [Guid("d93996aa-e161-4e10-8aa8-9b23643842b1")]
    public class WingtipCalculatorServiceInstallerEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            // install the service
            CalcService service = SPFarm.Local.Services.GetValue<CalcService>();
            if (service == null)
            {
                service = new CalcService(SPFarm.Local);
                service.Update();
            }


            // install the service proxy
            CalcServiceProxy serviceProxy = SPFarm.Local.ServiceProxies.GetValue<CalcServiceProxy>();
            if (serviceProxy == null)
            {
                serviceProxy = new CalcServiceProxy(SPFarm.Local);
                serviceProxy.Update(true);
            }


            // with service added to the farm, install instance
            CalcServiceInstance serviceInstance = new CalcServiceInstance(SPServer.Local, service);
            serviceInstance.Update(true);
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            // uninstall the instance
            CalcServiceInstance serviceInstance = SPFarm.Local.Services.GetValue<CalcServiceInstance>();
            if (serviceInstance != null)
                SPServer.Local.ServiceInstances.Remove(serviceInstance.Id);

            // uninstall the service proxy
            CalcServiceProxy serviceProxy = SPFarm.Local.ServiceProxies.GetValue<CalcServiceProxy>();
            if (serviceProxy != null)
            {
                SPFarm.Local.ServiceProxies.Remove(serviceProxy.Id);
            }

            // uninstall the service
            CalcService service = SPFarm.Local.Services.GetValue<CalcService>();
            if (service != null)
                SPFarm.Local.Services.Remove(service.Id);
        }
    }
}
