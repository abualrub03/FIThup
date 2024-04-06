using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CompetitionsTeams
    {
        public List<CompetitionsTeamMembers> CompetitionsTeamMembers {  get; set; }
      
        public CompetitionsTeams(List<CompetitionsTeamMembers> CT)
        {
            CompetitionsTeamMembers = CT;
        }
    }
}
