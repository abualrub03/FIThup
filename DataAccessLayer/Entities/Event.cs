using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Event
    {
        public int EventID             {  get; set; }
        public string ImageName        {  get; set; }
        public string Title            {  get; set; }
        public DateTime EventDateTime  {  get; set; }
        public string SmallDescription {  get; set; }
        public string LongDescription { get; set; }
    }
}
