using Entities;
using FIThup.Web.Controllers;
using FIThupProvider;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using ViewModel;

namespace FIThup.Controllers
{
    public class HomeController  : AuthorizedController 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "UnAuth");
        }
        [HttpPost]
        public void AddComment( string CommentText , int  CommentEventRecieverId , string Category) 
        {
            /*
            var user = _httpContextAccessor.HttpContext.User;
            var userId = this.User.FindFirstValue("UserID");
            com.CommentDateTime = DateTime.Now;
            com.CommentText = com.CommentText;
            */
            Entities.Comments  a = new Entities.Comments();
            a.CommentDateTime = DateTime.Now;
            var user = _httpContextAccessor.HttpContext.User;
            var userId = this.User.FindFirstValue("UserID");
            a.CommentSenderId = int.Parse(userId); ;

            a.CommentText = CommentText; 
            a.Category = Category;
            a.CommentEventRecieverId = CommentEventRecieverId;
            
            new FIThupProvider.Comments().AddCommentsOnEvent(a);
            
        }
        public IActionResult Index()
        {
            var VM = new IndexViewModel();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            return View("Index", VM);
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
            VM.listCompetitions = new FIThupProvider.Competitions().SearchCompetitionsOnString(searchTerm);
            VM.listClubs = new FIThupProvider.ClubsHistory().SearchClubsOnString(searchTerm);
            VM.listWorkShopWithClubs = new FIThupProvider.WorkShopWithClubs().SearchWorkShopWithClubsOnString(searchTerm);
            return View("SearchPage",VM);
        }
        public IActionResult MainCompetitionPage()
        {
            var VM = new ViewModel.MainCompetitionPageViewModel();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            return View("MainCompetitionPage", VM);
        }

        /////////////////
        
        public IActionResult EventDetails(int EventId)
        {
            var provider = new FIThupProvider.EventWithClub();
            var VM = new ViewModel.EventDetailsViewModel();
            VM.EventDetails = provider.getEventDetailsByID(EventId);
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();

            ////
            VM.ListImages = new FIThupProvider.Images().getImageByCategoryImageUseageImageAndCategoryID("Events", "MultiImages", EventId);
            ////
            
            return View("EventDetails", VM);
        }
        public IActionResult WorkShopDetails(int WorkShopID)
        {
            var provider = new FIThupProvider.WorkShopWithClubs();
            var VM = new ViewModel.WorkShopWithClubsViewModel();
            VM.CompetitonDetails = provider.getWorkShopDetailsByID(WorkShopID);
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();

            VM.clubs = new FIThupProvider.Clubs().getClubsList();

            /////////
            VM.ListImages = new FIThupProvider.Images().getImageByCategoryImageUseageImageAndCategoryID("Workshops", "MultiImages", WorkShopID);
            //////////
            return View("WorkshopDetails", VM);
        }
        //////////////////////////////////////////////////////////////////////////////
        public IActionResult ClubView(int ClubID)
        {

            var VM = new ClubViewModel();
            VM.Comments = new FIThupProvider.Comments().CommentsOnEvent(ClubID, "Club");
            VM.events = new FIThupProvider.EventWithClub().getEventWithClub(ClubID);
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.clubsHistory = new FIThupProvider.ClubsHistory().getClubHistory(ClubID);
            VM.TeamMembers = new FIThupProvider.ClubsTeamMembers().getTeamMembersByClubHistoryID(VM.clubsHistory.FirstOrDefault().ClubsUpdateId);
            VM.LastEditions = new FIThupProvider.ClubsHistory().getClubHistoryLastEditions(VM.clubsHistory.FirstOrDefault().PerviewName);
            VM.workShopWithClubs = new FIThupProvider.WorkShopWithClubs().getWorkShopWithClubs(VM.clubsHistory.FirstOrDefault().ClubsUpdateId);
            VM.ClubHistoryCompetitons = new FIThupProvider.Competitions().getClubHistoryCompetitions(VM.clubsHistory.FirstOrDefault().ClubsUpdateId);
            VM.Users = new FIThupProvider.Users().getStudentNameByID(VM.clubsHistory.FirstOrDefault().LastUpdateUser);
            return View("Club", VM);
        }
        public IActionResult CompetitionDetails(int CompetitonID)
        {
            var VM = new CompetitionDetailsViewModel();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.ListImages = new FIThupProvider.Images().getImageByCategoryImageUseageImageAndCategoryID("Competitions", "MultiImages", CompetitonID);
            VM.CompetitonDetails = new FIThupProvider.Competitions().getCompetitionByID(CompetitonID);
            VM.CompetitionTeams = new FIThupProvider.Competitions().getFirstThreePlacesInCompetionByID(CompetitonID);

            VM.competitionsCategory = new FIThupProvider.CompetitionsCategory().getCompetitionsCategoryById(CompetitonID);
            VM.CompetitonEditions = new FIThupProvider.Competitions().getAllEditionsForThisCompetitionsCategory(VM.competitionsCategory.FirstOrDefault().CompetitionCategoryID);
            return View("CompetitionDetails", VM);
        }
        public IActionResult ClubsWorkshop(int ClubID)
        {
            var VM = new ClubsWorkshopViewModel();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.workshops = new FIThupProvider.WorkShopWithClubs().getWorkshopsByClubID(ClubID);
            VM.club = new FIThupProvider.Clubs().getClubDetailsWithClubId(ClubID);
            return View("ClubsWorkshop", VM);
        }

        public IActionResult UpCommingEvents(string EventCategory)
        {
            var VM = new UpCommingEventsViewModel();
            VM.EventCategory = EventCategory;
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            if (EventCategory == "Competitions")
                {
                    VM.UpcommingCompetitions = new FIThupProvider.Competitions().getUpCommingCompetitions();
                }
            else if (EventCategory == "Workshops")
            {
                VM.UpcommingWorkShopWithClubs = new FIThupProvider.WorkShopWithClubs().getUpCommingWorkshops();
            }
            else if (EventCategory == "Events")
            {
                VM.UpcommingEvents = new FIThupProvider.EventWithClub().getUpCommingEvents();
            }

                return View("UpCommingEvents", VM);
            }




        }
}
