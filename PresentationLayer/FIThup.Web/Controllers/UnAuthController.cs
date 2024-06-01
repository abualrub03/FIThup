using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Entities;
using ViewModel;

namespace FIThup.Web.Controllers
{
    public class UnAuthController : BaseController
    {
        [Route("/")]
        public IActionResult Index()
        {
            var VM = new IndexViewModel();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            return View("Index",VM);
        }

        public IActionResult SignUp()
        {
            var VM = new IndexViewModel();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            return View(VM);
        }

        public IActionResult SignIn()
        {
            var VM = new IndexViewModel();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            return View(VM);
        }
        
        [HttpPost]
        public IActionResult SignUpRequest(Entities.Users usr)
        {
            new FIThupProvider.Users().SignUpNewUser(usr);
            var VM = new IndexViewModel();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();
            return View("SignIn",VM);

        } 
        [HttpPost]
        public async Task<IActionResult> SignInRequest(Entities.Users usr)
        {


            if (ModelState.IsValid)
            {
                var data = new FIThupProvider.Users().SignInRequest(usr);
                if (data == null)
                {
                    ModelState.AddModelError("FormValidation", "Wrong Username or Password");
                    return View("SignIn", usr);
                }
                var claims = new List<Claim>
                     {
                         new Claim("UserID", data.FirstOrDefault().UserID.ToString() ,ClaimValueTypes.Integer32),
                         new Claim("CustomerEmail", data.FirstOrDefault().UniEmail,ClaimValueTypes.Email),
                         new Claim(ClaimTypes.Role, data.FirstOrDefault().Role,ClaimValueTypes.String ),
                         new Claim(ClaimTypes.Role, data.FirstOrDefault().FullName,ClaimValueTypes.String )
                     };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            else
                return View("SignIn", usr);


            var VM = new IndexViewModel();
            VM.clubs = new FIThupProvider.Clubs().getClubsList();
            VM.competitions = new FIThupProvider.CompetitionsCategory().getCompetitionsCategory();


            return RedirectToAction("Index", "Home", VM);

        }

    }
}
