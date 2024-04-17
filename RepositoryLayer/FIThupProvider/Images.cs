using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class Images : Core.Disposable
    {

        public List<Entities.Images> getImageByCategoryImageUseageImageAndCategoryID(string Category , string ImageUseage,int ID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Category", Value =  Category },
                new SqlParameter{ ParameterName = "@ImageUseage", Value =  ImageUseage },
                new SqlParameter{ ParameterName = "@ID", Value = ID },

            };
            return DAL2.ExecuteReader<Entities.Images>("spGetImageByCategoryImageUseageImageAndCategoryID");
        }

    }
}
