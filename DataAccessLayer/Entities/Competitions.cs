
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Competitions
    {
        public int CompetitionID  {set; get;}
        public string CompetitionTitle  {set; get;}
        public string CompetitionVersion   {set; get;}
        public DateTime CompetitionDateTime {set; get;}
        public string SmallDescription {set; get;}
        public int ClubHistoryID { set; get; }

        public string MainCompetitonImage { set; get;}  
    }
}
