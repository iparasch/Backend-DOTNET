using Microsoft.AspNetCore.Mvc;
using ProjDAW.Models;
using ProjDAW.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjDAW.Controllers
{
    [Route("account")]
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
            if(account == null)
            {
                ViewBag.error = "Invalid";
                return View("Login");
            }
            else
            {
                securityManager.SignIn(this.HttpContext, account, "User_Schema");
                return RedirectToAction("Welcome", "account");
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
            securityManager.SignOut(this.HttpContext, "User_Schema");
            return RedirectToAction("login", "account");
        }
    }
}
