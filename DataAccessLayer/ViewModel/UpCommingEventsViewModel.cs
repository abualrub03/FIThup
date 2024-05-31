using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UpCommingEventsViewModel : LayoutViewModel
    {
        public string EventCategory { get; set; }
        public List<Competitions> UpcommingCompetitions { get; set; }
        public List<WorkShopWithClubs> UpcommingWorkShopWithClubs { get; set; }
        public List<Event> UpcommingEvents { get; set; }

    }
}
