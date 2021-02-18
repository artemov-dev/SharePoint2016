using BDCAdventure;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace BDCAdventure.BdcAdventure
{
    public partial class AdventureService
    {
        private static string connStr = "Data Source=SP2016;Initial Catalog=AdventureWorks2016;uid=advuser;pwd=123qweAa";
        public static vEmployee ReadItem(int businessEntityID)
        {
            AdventureDBDataContext dataContext = new AdventureDBDataContext(connStr);
            return dataContext.vEmployees.Where(e => e.BusinessEntityID.Equals(businessEntityID)).Single();
        }



        public static IEnumerable<vEmployee> ReadList()
        {
            AdventureDBDataContext dataContext = new AdventureDBDataContext(connStr);
            return dataContext.vEmployees.ToList();
        }
    }
}