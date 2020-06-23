using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace TestPages
{
    public static class common
    {

        /// <summary>
        /// Получение коллекции баз данных содержимого
        /// </summary>
        /// <returns>Коллекцию объектов баз данных содержимого</returns>
        public static List<databases> GetContentDataBases()
        {
            var result = new List<databases>();


            var ctx = SPContext.Current;
            SPSecurity.RunWithElevatedPrivileges(
              delegate
              {
                  using (var site = new SPSite(ctx.Site.ID))
                  {
                      var ListDb = site.WebApplication.ContentDatabases.Cast<SPContentDatabase>().ToList();
                      ListDb.ForEach(db => { databases d = new databases(db.Name, db.DiskSizeRequired); result.Add(d); });
                      
                  }
              });
            return result;
        }

    



    }
}
