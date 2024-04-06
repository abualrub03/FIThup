using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class CompetitionsTeamMembers
    {
        public int      CompetitionsTeamID                {set;get;}
        public int       CompetitionID                     {set;get;}
        public string?       CompetitionsTeamName              {set;get;}
        public int            CompetitionsTeamMemberID          {set;get;}
        public int          UserID                            {set;get;}
        public string?            Username                          {set;get;}
        public string?            FullName                           { set; get; }
        public int              Place                           { set;get;}
        public string? TeamPicture { set;get;}

    }
}
