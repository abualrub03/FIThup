using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FIThup.Web.Controllers
{
    [FIThup.Web.Controllers.Filter.Authorize("User")]
    public class AuthorizedController : BaseController
    {
        public Entities.Users CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
        }
        public Entities.Users GetCurrentUser()
        {
            Entities.Users team = new Entities.Users();
            var props = typeof(Entities.Users).GetProperties();
            foreach (var item in props)
            {
                var value = User.FindFirstValue(item.Name);
                if (value != null)
                {
                    item.SetValue(team, value);
                }
            }
            return team;
        }
    }
}
