using Entities;
using FIThup.Web.Controllers;
using FIThupProvider;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewModel;

namespace FIThup.Controllers
{
    public class HomeController : BaseController
    {

        public IActionResult ClubView(int ClubID){

            var VM = new ClubViewModel();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();

            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.clubsHistory = new FIThupProvider.ClubsHistory().getClubHistory(ClubID);
            VM.TeamMembers = new FIThupProvider.ClubsTeamMembers().getTeamMembersByClubHistoryID(VM.clubsHistory.FirstOrDefault().ClubsUpdateId);
            VM.LastEditions = new FIThupProvider.ClubsHistory().getClubHistoryLastEditions(VM.clubsHistory.FirstOrDefault().PerviewName);
            VM.workShopWithClubs = new FIThupProvider.WorkShopWithClubs().getWorkShopWithClubs(VM.clubsHistory.FirstOrDefault().ClubsUpdateId);
            VM.ClubHistoryCompetitons = new FIThupProvider.Competitions().getClubHistoryCompetitions(VM.clubsHistory.FirstOrDefault().ClubsUpdateId);
            VM.Users = new FIThupProvider.Users().getStudentNameByID(VM.clubsHistory.FirstOrDefault().LastUpdateUser);

            return View("Club",VM);
        }




        public IActionResult Index()
        {
            var VM = new IndexViewModel();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            return View(VM);
        }
        public IActionResult Club()
        {
            return View();
        }

        public IActionResult CompetitionDetails(int CompetitonID)
        {
            var VM = new CompetitionDetailsViewModel();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();

            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.ListImages = new FIThupProvider.Images().getImageByCategoryImageUseageImageAndCategoryID("Competitions", "MultiImages", CompetitonID);
            VM.CompetitonDetails = new FIThupProvider.Competitions().getCompetitionByID(CompetitonID);
            VM.CompetitionTeams = new FIThupProvider.Competitions().getFirstThreePlacesInCompetionByID(CompetitonID);
            return View("CompetitionDetails" ,VM);
        }
        public IActionResult WorkShopDetails(int WorkShopID)
        {
            var provider = new FIThupProvider.WorkShopWithClubs();

            var VM = new ViewModel.WorkShopWithClubsViewModel();
            VM.CompetitonDetails = provider.getWorkShopDetailsByID(WorkShopID);
            VM.clubs = new FIThupProvider.Clubs().getClubsList();


            return View("WorkshopDetails", VM);
        }
        public IActionResult EventsAndUpComingsDetails(int EventsAndUpComingsID)
        {
            var provider = new FIThupProvider.WorkShopWithClubs();

            var VM = new ViewModel.WorkShopWithClubsViewModel();
         //   VM.CompetitonDetails = provider.getWorkShopDetailsByID(WorkShopID);
            VM.clubs = new FIThupProvider.Clubs().getClubsList();


            return View("EventsAndUpComingsDetails", VM);
        }
        [HttpGet]
        public IActionResult SearchPage(string searchTerm)
        {
            var VM = new ViewModel.SearchPageViewModel();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            return View("SearchPage",VM);
        }

    }
}
