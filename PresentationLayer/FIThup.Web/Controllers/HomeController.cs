using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FIThup.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}
