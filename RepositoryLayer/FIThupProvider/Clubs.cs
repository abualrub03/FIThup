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
    }
}
