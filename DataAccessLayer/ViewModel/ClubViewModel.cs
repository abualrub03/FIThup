using Entities;

namespace ViewModel
{
    public class ClubViewModel
    {
        public List<ClubsHistory> clubsHistory {  get; set; }
        public List<Users> Users { get; set; }
        public List<Users> TeamMembers { get; set; }
        public List<ClubsHistory> LastEditions { get; set; }
    }
}
