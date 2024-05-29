using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class CompetitionsCategory
    {
        public int CompetitionCategoryID { get; set; }
        public string CompetitionName { get; set; }
        public string CompetitionImageName { get; set; }
        public string LastVersion { get; set; }
    }
}
