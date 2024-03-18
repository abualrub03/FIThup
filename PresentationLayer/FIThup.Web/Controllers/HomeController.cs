using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewModel;

namespace FIThup.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult ClubView(string ClubName)
        {
            var ClubRecordHistory = new FIThupProvider.ClubsHistory().getClubHistory(ClubName);

            var LastUpadteUserName = new FIThupProvider.Users().getStudentNameByID(ClubRecordHistory.FirstOrDefault().LastUpdateUser);

            var VM = new ClubViewModel();
            VM.clubsHistory = ClubRecordHistory;
            VM.Users = LastUpadteUserName;
            VM.TeamMembers = new FIThupProvider.ClubsTeamMembers().getTeamMembersByClubHistoryID(ClubRecordHistory.FirstOrDefault().ClubsUpdateId);
            VM.clubsHistory = new FIThupProvider.ClubsHistory().getClubHistoryLastEditions(ClubName);
            return View("Club",VM);
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
