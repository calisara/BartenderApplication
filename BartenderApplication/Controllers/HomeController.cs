using BartenderApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using BartenderApplication.Models.ViewModels;
using BartenderApplication.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using BartenderApplication.Repository;
using Microsoft.AspNetCore.Authentication;

namespace BartenderApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IAuthService authService, FakeRepository repository)
        {
            _logger = logger;
            _authService = authService;
        }



        [Authorize(Roles = "Employee,Customer")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            ViewData["ErrorMessage"] = null;
            User user = _authService.ValidateLogin(login);
            if (user is null)
            {
                ViewData["ErrorMessage"] = "Username or password is incorrect.";
                return View();
            }

            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            foreach (string role in user.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            HttpContext.Session.SetString("SessionKey", login.Username);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
