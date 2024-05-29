using Entities;

namespace ViewModel
{
    public class ClubViewModel  : LayoutViewModel
    {
        public List<ClubsHistory> clubsHistory {  get; set; }
        public List<Event> events { get; set; }
        public List<Users> Users { get; set; }
        public List<Users> TeamMembers { get; set; }
        public List<ClubsHistory> LastEditions { get; set; }
        public List<WorkShopWithClubs> workShopWithClubs { get; set; }
        public List<Entities.Competitions> ClubHistoryCompetitons { get; set; }
    }
}
