using Entities;
using FIThupProvider;
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
            VM.LastEditions = new FIThupProvider.ClubsHistory().getClubHistoryLastEditions(ClubRecordHistory.FirstOrDefault().PerviewName);
            VM.workShopWithClubs = new FIThupProvider.WorkShopWithClubs().getWorkShopWithClubs(ClubRecordHistory.FirstOrDefault().ClubsUpdateId);
            VM.ClubHistoryCompetitons = new FIThupProvider.Competitions().getClubHistoryCompetitions(ClubRecordHistory.FirstOrDefault().ClubsUpdateId);
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
        public IActionResult CompetitionDetails()
        {
            return View("CompetitionDetails");
        }
        public IActionResult WorkShopDetails(int WorkShopID)
        {
            var VM = new FIThupProvider.WorkShopWithClubs();
       
            return View("WorkshopDetails", VM.getWorkShopDetailsByID(WorkShopID).FirstOrDefault());
        }

    }
}
