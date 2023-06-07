using Microsoft.AspNetCore.Mvc;
using PriceScreen.Models;
using System.Diagnostics;
using PriceScreen.DBContext;

namespace PriceScreen.Controllers
{
    
    public class HomeController : Controller
    {        
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            User _user = new User();
            return View(_user);
        }

        [HttpPost]
        public IActionResult Index(User _user)
        {

            PriceScreenDBContext _UserContext = new PriceScreenDBContext();
            var status = _UserContext.Users.Where(m=>m.Id == _user.Id && m.Password == _user.Password).FirstOrDefault();
            if(status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("SuccesPage","Home");
            }
            return View(_user);
        }

        public IActionResult SuccessPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//public async Task<IActionResult> LogOut()
//{
//    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//    return RedirectToAction("Login", "Access");
//}