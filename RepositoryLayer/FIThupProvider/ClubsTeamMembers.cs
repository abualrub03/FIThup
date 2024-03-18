using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class ClubsTeamMembers : Core.Disposable
    {

        public List<Entities.Users> getTeamMembersByClubHistoryID(int ClubHistoryID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubsUpdateId", Value =  ClubHistoryID },

            };
            return DAL2.ExecuteReader<Entities.Users>("spGetTeamMembersByClubHistoryID");
        }
    }
}
