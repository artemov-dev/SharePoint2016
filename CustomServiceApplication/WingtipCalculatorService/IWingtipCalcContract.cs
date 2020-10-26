using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    [ServiceContract]
    public interface IWingtipCalcContract
    {
        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        int Subtract(int x, int y);
    }
}
