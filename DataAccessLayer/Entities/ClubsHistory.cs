using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClubsHistory
    {
        public int ClubsUpdateId { get; set; }
        public int ClubId { get; set; }
        public string PerviewName { get; set; }
        public string FullName { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public int LastUpdateUser { get; set; }
        public string ClubImageName { get; set; }
        public string ClubInfo { get; set; }

        public string ClubChairpersonInfo { get; set; }

    }
}
