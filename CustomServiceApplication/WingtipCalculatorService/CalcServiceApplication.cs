using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        IncludeExceptionDetailInFaults = true)]
    [System.Runtime.InteropServices.Guid("5F73BBD5-3D24-44C7-B1D3-36BB93A00AD3")]
    public class CalcServiceApplication : SPIisWebServiceApplication, IWingtipCalcContract
    {
        [Persisted]
        private int _settings;
        public int Setting
        {
            get { return _settings; }
            set { _settings = value; }
        }

        public CalcServiceApplication()
            : base() { }
        private CalcServiceApplication(string name, CalcService service, SPIisWebServiceApplicationPool appPool)
            : base(name, service, appPool) { }

        public static CalcServiceApplication Create(string name, CalcService service, SPIisWebServiceApplicationPool appPool)
        {
            #region validation
            if (name == null) throw new ArgumentNullException("name");
            if (service == null) throw new ArgumentNullException("service");
            if (appPool == null) throw new ArgumentNullException("appPool");
            #endregion

            // create the service application
            CalcServiceApplication serviceApplication = new CalcServiceApplication(name, service, appPool);
            serviceApplication.Update();

            // register the supported endpoints
            serviceApplication.AddServiceEndpoint("http", SPIisWebServiceBindingType.Http);
            serviceApplication.AddServiceEndpoint("https", SPIisWebServiceBindingType.Https, "secure");

            return serviceApplication;
        }

        #region service application details
        protected override string DefaultEndpointName
        {
            get { return "http"; }
        }

        public override string TypeName
        {
            get { return "Wingtip Calculator Service Application"; }
        }

        protected override string InstallPath
        {
            get { return SPUtility.GetGenericSetupPath(@"WebServices\Wingtip"); }
        }

        protected override string VirtualPath
        {
            get { return "CalcService.svc"; }
        }

        public override Guid ApplicationClassId
        {
            get { return new Guid("5F73BBD5-3D24-44C7-B1D3-36BB93A00AD3"); }
        }

        public override Version ApplicationVersion
        {
            get { return new Version("1.0.0.0"); }
        }
        #endregion

        #region service application admin UI
        public override SPAdministrationLink ManageLink
        {
            get
            { return new SPAdministrationLink("/_admin/WingtipCalculatorService/Manage.aspx"); }
        }
        public override SPAdministrationLink PropertiesLink
        {
            get
            { return new SPAdministrationLink("/_admin/WingtipCalculatorService/Manage.aspx"); }
        }
        #endregion

        #region IWingtipCalcContract implementation
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }
        #endregion
    }
}
