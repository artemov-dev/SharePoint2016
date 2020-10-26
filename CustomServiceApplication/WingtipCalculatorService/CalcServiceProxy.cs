using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    [System.Runtime.InteropServices.Guid("FFF4086E-88B0-45B9-A776-AF98572C5C60")]
    [SupportedServiceApplication("5F73BBD5-3D24-44C7-B1D3-36BB93A00AD3", 
                                "1.0.0.0", 
                                typeof(CalcServiceApplicationProxy))]
    public class CalcServiceProxy: SPIisWebServiceProxy, IServiceProxyAdministration
    {
        public CalcServiceProxy()
            : base() { }
        public CalcServiceProxy(SPFarm farm)
            : base(farm) { }

        public SPServiceApplicationProxy CreateProxy(Type serviceApplicationProxyType, string name, Uri serviceApplicationUri, SPServiceProvisioningContext provisioningContext)
        {
            if (serviceApplicationProxyType != typeof(CalcServiceApplicationProxy))
                throw new NotSupportedException();

            return new CalcServiceApplicationProxy(name, this, serviceApplicationUri);
        }

        public SPPersistedTypeDescription GetProxyTypeDescription(Type serviceApplicationProxyType)
        {
            return new SPPersistedTypeDescription("Wingtip Calculator Service Proxy", "Custom service application proxy providing simple calculation capabilities.");
        }

        public Type[] GetProxyTypes()
        {
            return new Type[] { typeof(CalcServiceApplicationProxy) };
        }
    }
}
