using Microsoft.Data.SqlClient;

namespace FIThupProvider
{
    public class ClubsHistory : Core.Disposable 
    {
        
        public List<Entities.ClubsHistory> getClubHistory(string ClubName)
        {
         
            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@PerviewName", Value =  ClubName },
             
            };
            return DAL2.ExecuteReader<Entities.ClubsHistory>("spGetClubHistory");
        }
    }
}
