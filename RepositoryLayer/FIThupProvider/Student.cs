using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class Student : Core.Disposable
    {

        public List<Entities.Student> getStudentNameByID(int StudentID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@StudentID", Value =  StudentID },

            };
            return DAL2.ExecuteReader<Entities.Student>("spGetStudentNameByID");
        }
    }
}
