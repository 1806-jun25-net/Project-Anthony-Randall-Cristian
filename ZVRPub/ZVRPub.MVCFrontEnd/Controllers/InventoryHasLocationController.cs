using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class InventoryHasLocationController : AServiceController
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public InventoryHasLocationController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: InventoryHasLocation
        // GET: User
        public async Task<ActionResult> IndexAsync(string searchString)
        {
            log.Info("Beginning creation of httprequest message");
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:56667/api/inventoryHasLocation");

            try
            {

                log.Info("Sending http request");
                var response = await HttpClient.SendAsync(request);
                log.Info("Request sent");

                if (!response.IsSuccessStatusCode)
                {
                    log.Info("Error: HTTP request sent back non-200 message");
                    log.Info("Displaying error view");
                    return View("Error");
                }
                log.Info("HTTP status code 200 - creating json string");
                string jsonString = await response.Content.ReadAsStringAsync();

                log.Info("Deserializing json string into list");
                List<InventoryHasLocation> invLoc = JsonConvert.DeserializeObject<List<InventoryHasLocation>>(jsonString);

               
                log.Info("Redisplaying index view with given search string");
                return View(invLoc);
            }
            catch (HttpRequestException ex)
            {
                log.Info("Exception thrown - exiting try block");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                log.Info("Displaying error view");
                return View("Error");
            }
        }


        // GET: InventoryHasLocation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryHasLocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryHasLocation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryHasLocation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryHasLocation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryHasLocation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryHasLocation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}