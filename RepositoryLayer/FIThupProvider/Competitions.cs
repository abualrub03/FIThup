using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class Competitions : Core.Disposable
    {

        public List<Entities.Competitions> getClubHistoryCompetitions(int ClubHistroyID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubHistroyID", Value =  ClubHistroyID },

            };
            return DAL2.ExecuteReader<Entities.Competitions>("spGetClubHistoryCompetitions");
        }
        public List<Entities.Competitions> getCompetitionByID(int CompetitionID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@CompetitionID", Value =  CompetitionID },

            };
            return DAL2.ExecuteReader<Entities.Competitions>("spGetCompetitionByID");
        }


    }
}

