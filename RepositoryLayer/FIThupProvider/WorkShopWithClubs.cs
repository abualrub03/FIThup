using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class WorkShopWithClubs : Core.Disposable
    {
        public List<Entities.WorkShopWithClubs> getWorkShopWithClubs(int ClubHistoryID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubsUpdateId", Value =  ClubHistoryID },

            };
            return DAL2.ExecuteReader<Entities.WorkShopWithClubs>("spGetWorkShopWithClubs");
        }
    }
}
