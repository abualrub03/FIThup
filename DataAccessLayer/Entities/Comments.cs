using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entities
{
    public class Comments
    {
        public int CommentID                {set;get;}
        public string CommentText           {set;get;}
        public string Category           {set;get;}
        public int CommentSenderId          {set;get;}
        public int CommentEventRecieverId   {set;get;}
        public DateTime CommentDateTime  { set; get; }
    }
}
