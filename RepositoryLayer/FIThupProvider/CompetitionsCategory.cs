using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class CompetitionsCategory
    {
        public List<Entities.CompetitionsCategory> getCompetitionsCategory()
        {
            using var DAL2 = new DataAccess.DataAccessLayer();
            return DAL2.ExecuteReader<Entities.CompetitionsCategory>("spGetCompetitionsCategory");
        }

        public List<Entities.CompetitionsCategory> getCompetitionsCategoryById(int CompetitionId)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@CompetitionId", Value =  CompetitionId },

            };
            return DAL2.ExecuteReader<Entities.CompetitionsCategory>("spGetCompetitionsCategoryById");
        }


    }
}
