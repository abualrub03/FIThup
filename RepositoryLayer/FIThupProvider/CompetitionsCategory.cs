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


    }
}
