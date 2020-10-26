using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    [System.Runtime.InteropServices.Guid("F4E0F76F-96C6-49D3-9475-E2127FEBCC68")]
    public class CalcService : SPIisWebService, IServiceAdministration
    {
        public CalcService() { }
        public CalcService(SPFarm farm)
            : base(farm) { }

        public SPServiceApplication CreateApplication(string name, Type serviceApplicationType, SPServiceProvisioningContext provisioningContext)
        {
            #region validation
            if (serviceApplicationType != typeof(CalcServiceApplication))
                throw new NotSupportedException();
            if (provisioningContext == null)
                throw new ArgumentNullException("provisioningContext");
            #endregion

            // if the service doesn't already exist, create it
            CalcServiceApplication serviceApp = this.Farm.GetObject(name, this.Id, serviceApplicationType) as CalcServiceApplication;
            if (serviceApp == null)
                serviceApp = CalcServiceApplication.Create(name, this, provisioningContext.IisWebServiceApplicationPool);

            return serviceApp;
        }

        public SPServiceApplicationProxy CreateProxy(string name, SPServiceApplication serviceApplication, SPServiceProvisioningContext provisioningContext)
        {
            #region validation
            if (serviceApplication.GetType() != typeof(CalcServiceApplication))
                throw new NotSupportedException();
            if (serviceApplication == null)
                throw new ArgumentNullException("serviceApplication");
            #endregion

            // verify the service proxy exists
            CalcServiceProxy serviceProxy = (CalcServiceProxy)this.Farm.GetObject(name, this.Farm.Id, typeof(CalcServiceProxy));
            if (serviceProxy == null)
                throw new InvalidOperationException("CalcServiceProxy does not exist in the farm.");

            // if the app proxy doesn't exist, create it
            CalcServiceApplicationProxy applicationProxy = serviceProxy.ApplicationProxies.GetValue<CalcServiceApplicationProxy>(name);
            if (applicationProxy == null)
            {
                Uri serviceAppAddress = ((CalcServiceApplication)serviceApplication).Uri;
                applicationProxy = new CalcServiceApplicationProxy(name, serviceProxy, serviceAppAddress);
            }

            return applicationProxy;
        }

        public SPPersistedTypeDescription GetApplicationTypeDescription(Type serviceApplicationType)
        {
            if (serviceApplicationType != typeof(CalcServiceApplication))
                throw new NotSupportedException();

            return new SPPersistedTypeDescription("Wingtip Calculator Service", "Custom service application providing simple calculation capabilities.");
        }

        public Type[] GetApplicationTypes()
        {
            return new Type[] { typeof(CalcServiceApplication) };
        }

        public override SPAdministrationLink GetCreateApplicationLink(Type serviceApplicationType)
        {
            return new SPAdministrationLink("/_admin/WingtipCalculatorService/Create.aspx");
        }
    }
}
