using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkShopWithClubs
    {
        public int  WorkShopID {  get; set; }
        public string ImageName                {  get; set; }
        public DateTime WorkShopDateTime       {  get; set; }
        public string SmallDescription         {  get; set; }
        public string LongDescription { get; set; } 
        public string Title { get; set; }

    }
}
