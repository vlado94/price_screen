using Microsoft.AspNetCore.Mvc;
using PriceScreen.Models;
using PriceScreen.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PriceScreen.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _loginUser;

        public LoginController(ILogin loguser)
        {
            _loginUser = loguser;
            
        }
        //public HomeController(ILogin loguser)
        //{
        //    _loginUser = loguser;
        //
        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index (string email, string password)
        {
            var issuccess = _loginUser.AuthenticateUser(email, password);

            if(issuccess.Result != null)
            {
                ViewBag.email = string.Format("Successfully logged in", email);
                TempData["email"] = "Ahmed";
                return RedirectToAction("Index", "Layout");
            }
            else
            {
                ViewBag.email = string.Format("Login failed", email);
                return View();
            }
        }
    }
}
