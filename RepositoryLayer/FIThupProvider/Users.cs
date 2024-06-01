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
        public List<Entities.Users> SignUpNewUser(Entities.Users usr)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Username", Value =  usr.Username },
                new SqlParameter{ ParameterName = "@UniEmail", Value =  usr.UniEmail },
                new SqlParameter{ ParameterName = "@Password", Value =  usr.Password }

            };
            return DAL2.ExecuteReader<Entities.Users>("spSignUpNewUser");
        }public List<Entities.Users> SignInRequest(Entities.Users usr)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Username", Value =  usr.Username },
                new SqlParameter{ ParameterName = "@Password", Value =  usr.Password }

            };
            return DAL2.ExecuteReader<Entities.Users>("SignInRequest");
        }
    }
}
