﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        //UserManager<IdentityUser> _userManager;

        public Settings Settings { get; set; }
        public HomeController(Settings settings)
        {
            Settings = settings;
        }

        public IActionResult Index()
        {
            log.Info("Displaying home index view");
            //if (Request.Cookies[ZVRPubAuth])
            //{
            //    var current_User = await _userManager.GetUserAsync(HttpContext.User);
            //    TempData["id"] = "Welcome " + current_User.UserName + "!";
            //}
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            log.Info("Displaying About page view");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            log.Info("Displaying contact information page");
            return View();
        }

        public IActionResult Error()
        {
            log.Info("Error detected in program. Displaying error page");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
