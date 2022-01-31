using Microsoft.AspNetCore.Mvc;
using ProjDAW.Models;
using ProjDAW.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjDAW.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/account")]
    public class AccountController : Controller
    {
        private SecurityManager securityManager = new SecurityManager();

        [HttpGet]
        [Route("")]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            AccountModel accountModel = new AccountModel();
            Account account = accountModel.login(username, password);
            if (account == null)
            {
                ViewBag.error = "Invalid";
                return View("Login");
            }
            else
            {
                securityManager.SignIn(this.HttpContext, account, "Admin_Schema");
                return RedirectToAction("Welcome", "account", new { area = "admin"});
            }
        }

        [Route("welcome")]
        public IActionResult Welcome()
        {
            return View("Welcome");
        }

        [HttpGet]
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            securityManager.SignOut(this.HttpContext, "Admin_Schema");
            return RedirectToAction("login", "account", new { area = "admin"});
        }
        
    }
}
