using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    public class CalcServiceInstance : SPIisWebServiceInstance
    {
        public CalcServiceInstance() { }
        public CalcServiceInstance(SPServer server, CalcService service)
            : base(server, service) { }

        public override string DisplayName
        {
            get { return "Wingtip Calculator Service"; }
        }
        public override string Description
        {
            get { return "Wingtip Calculator providing simple arithmatic services."; }
        }
        public override string TypeName
        {
            get { return "Wingtip Calculator Service"; }
        }
    }
}
