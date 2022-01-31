using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjDAW.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin", AuthenticationSchemes = "Admin_Schema")]
    [Area("admin")]
    [Route("admin/home")]
    public class HomeController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
