using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public IActionResult Index()
        {
            log.Info("Displaying home index view");
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
