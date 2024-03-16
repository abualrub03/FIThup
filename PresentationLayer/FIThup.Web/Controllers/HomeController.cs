using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FIThup.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult ClubView(string ClubName)
        {
            var ClubRecordHistory = new FIThupProvider.ClubsHistory().getClubHistory(ClubName);




            return View("Club",ClubRecordHistory);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Club()
        {
            return View();
        }

    }
}
