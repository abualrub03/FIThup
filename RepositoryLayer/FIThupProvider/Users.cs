using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class Users : Core.Disposable
    {

        public List<Entities.Users> getStudentNameByID(int UserID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@UserID", Value =  UserID },

            };
            return DAL2.ExecuteReader<Entities.Users>("spGetUserByID");
        }
    }
}
