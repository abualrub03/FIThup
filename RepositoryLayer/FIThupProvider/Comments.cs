using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class Comments : Core.Disposable
    {
        public List<Entities.CommentsWithUsername> CommentsOnEvent(int CommentEventRecieverId, string Category)
        {
           
            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@CommentEventRecieverId", Value =  CommentEventRecieverId },
                new SqlParameter{ ParameterName = "@Category", Value =  Category },
            };
            return DAL2.ExecuteReader<Entities.CommentsWithUsername>("spCommentsOnEvent");
        }

        public List<Entities.Comments> AddCommentsOnEvent(Entities.Comments com)
        {
            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@CommentEventRecieverId", Value =  com.CommentEventRecieverId },
                new SqlParameter{ ParameterName = "@CommentText", Value =  com.CommentText },
                new SqlParameter{ ParameterName = "@Category", Value =  com.Category },
                new SqlParameter{ ParameterName = "@CommentSenderId", Value =  com.CommentSenderId },
                new SqlParameter{ ParameterName = "@CommentDateTime", Value =  com.CommentDateTime },
            };
            return DAL2.ExecuteReader<Entities.Comments>("spAddCommentsOnEvent");
        }


    }
}
