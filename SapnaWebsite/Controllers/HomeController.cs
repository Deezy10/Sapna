using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SapnaWebsite.Repositories;
using SapnaWebsite.ViewModels.Home;

namespace SapnaWebsite.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository _data;
        
        public HomeController(IHomeRepository data)
        {
            _data = data;
        }
        
        public IActionResult Index()
        {
            HomeViewModel model = _data.GetHomeData();

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Members()
        {
            return View();
        }

        [Authorize(Roles="Member")]
        public IActionResult Profile(int? id)
        {
            return View();
        }


        [Authorize(Roles = "Member")]
        [HttpPost]
        public IActionResult Profile(EditProfleViewModel model)
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Clients()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
