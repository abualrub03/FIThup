using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class Clubs : Core.Disposable
    {
        public List<Entities.Clubs> getClubsList()
        {
            using var DAL2 = new DataAccess.DataAccessLayer();
            return DAL2.ExecuteReader<Entities.Clubs>("spGetClubsList");
        }
   
        public List<Entities.Clubs> getClubDetailsWithClubId(int ClubID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubID", Value =  ClubID },

            };
            return DAL2.ExecuteReader<Entities.Clubs>("spGetClubDetailsWithClubId");
        }
        
    }
}
