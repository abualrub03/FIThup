using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CommentsWithUsername
    {
        public int CommentID { set; get; }
        public string CommentText { set; get; }
        public string Category { set; get; }
        public int CommentSenderId { set; get; }
        public int CommentEventRecieverId { set; get; }
        public DateTime CommentDateTime { set; get; }
        public string Username { set; get; }
    }
}
