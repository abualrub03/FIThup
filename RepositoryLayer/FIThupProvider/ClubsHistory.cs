using Microsoft.Data.SqlClient;

namespace FIThupProvider
{
    public class ClubsHistory : Core.Disposable 
    {
        
        public List<Entities.ClubsHistory> getClubHistory(int ClubID)
        {
         
            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubID", Value =  ClubID },
             
            };
            return DAL2.ExecuteReader<Entities.ClubsHistory>("spGetClubHistory");
        }
        public List<Entities.ClubsHistory> getClubHistoryLastEditions(string ClubName)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@PerviewName", Value =  ClubName },

            };
            return DAL2.ExecuteReader<Entities.ClubsHistory>("spGetClubHistoryLastEditions");
        }

    }
}
