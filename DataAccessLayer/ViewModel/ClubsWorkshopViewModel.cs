using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ClubsWorkshopViewModel : LayoutViewModel
    {
        public List<WorkShopWithClubs> workshops { get; set; }
        public List<Clubs> club {  get; set; }

    }
}
