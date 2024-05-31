using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Entities;

namespace FIThup.Web.Controllers
{
    public class UnAuthController   
    {
        // <<< loginValidation First step
        [HttpPost]
        public async Task<IActionResult> loginValidation(ViewModel.UserViewModels.loginViewModel acc)
        {
            if (ModelState.IsValid)
            {
                var data = new RacoonProvider.Team().getTeamMemberByInfo(acc.Email, acc.Password);
                if (data == null)
                {
                    ModelState.AddModelError("FormValidation", "Wrong Username or Password");
                    return View("login", acc);
                }
                var claims = new List<Claim>
                     {
                         new Claim("CustomerID", data.Id.ToString() ,ClaimValueTypes.Integer32),
                         new Claim("CustomerEmail", data.Email,ClaimValueTypes.Email),
                         new Claim(ClaimTypes.Role, data.Role,ClaimValueTypes.String ),
                         new Claim(ClaimTypes.Role, data.Name,ClaimValueTypes.String )
                     };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            else
                return View("login", acc);


            var v = new ViewMoreViewModel() { };
            v.Contacts = new RacoonProvider.Contact().spNewSearchIntblContact("", "%%", 0, 10);
            v.NumberOfItemsSearchedFor = new RacoonProvider.Contact().spNewCountSearchByName("%%", "%%");
            v.Services = new RacoonProvider.Services().getAllServices();


            return RedirectToAction("dashboard", "Admin", v);
        }
        // loginValidation >>>

    }
}
