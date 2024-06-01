using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SearchPageViewModel : LayoutViewModel
    {
        public List<Competitions> listCompetitions{ get; set; }
        public List<WorkShopWithClubs> listWorkShopWithClubs  { get; set; }

        public List<ClubsHistory> listClubs { get; set; }


    }
}
