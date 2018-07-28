using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class LogOnController : Controller
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        // GET: LogOn
        public ActionResult Index()
        {
            log.Info("Displaying logon index view");
            return View();
        }

        // GET: LogOn/Details/5
        public ActionResult Details(int id)
        {
            log.Info("Displaying logon details view");
            return View();
        }

        // GET: LogOn/Create
        public ActionResult Create()
        {
            log.Info("Displaying logon creation view");
            return View();
        }

        // POST: LogOn/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            log.Info("Response received");
            try
            {
                // TODO: Add insert logic here

                log.Info("Redirecting to the logon index view");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                log.Info("Exception thrown - exiting try block");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View();
            }
        }

        // GET: LogOn/Edit/5
        public ActionResult Edit(int id)
        {
            log.Info("Displaying logon edit information");
            return View();
        }

        // POST: LogOn/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            log.Info("Response received");
            try
            {
                // TODO: Add update logic here

                log.Info("Redirecting to logon index view");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                log.Info("Exception thrown - exiting try block");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View();
            }
        }

        // GET: LogOn/Delete/5
        public ActionResult Delete(int id)
        {
            log.Info("Displayin logon delete view");
            return View();
        }

        // POST: LogOn/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            log.Info("Response received");
            try
            {
                // TODO: Add delete logic here

                log.Info("Redirecting to logon index view");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                log.Info("Exception thrown - exiting try block");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View();
            }
        }
    }
}