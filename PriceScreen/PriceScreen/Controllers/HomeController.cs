using Microsoft.AspNetCore.Mvc;
using PriceScreen.Models;
using System.Diagnostics;
using PriceScreen.Data;


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

            PriceScreenDbContext _UserContext = new PriceScreenDbContext();
            var status = _UserContext.Users.Where(m => m.Email == _user.Email && m.Password == _user.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("SuccessPage", "Home");
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





