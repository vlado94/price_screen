using Microsoft.AspNetCore.Mvc;
using PriceScreen.Models;

namespace PriceScreen.Controllers
{
    public class StoreController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

    }
}

