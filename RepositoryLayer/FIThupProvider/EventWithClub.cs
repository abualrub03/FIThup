using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class EventWithClub : Core.Disposable
    {
        public List<Entities.Event> getEventWithClub(int ClubHistoryID)
        {


            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubsUpdateId", Value =  ClubHistoryID },

            };
            return DAL2.ExecuteReader<Entities.Event>("spGetEventWithClub");
        }
        public List<Entities.Event> getEventDetailsByID(int WorkShopID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@EventID", Value =  WorkShopID },

            };
            return DAL2.ExecuteReader<Entities.Event>("spGetEventDetailsByID");
        }
    }
}
