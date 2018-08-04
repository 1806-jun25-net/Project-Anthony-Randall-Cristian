using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class InventoryController : AServiceController
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly static string ServiceUri = "https://project2zvrapi.azurewebsites.net/api/";

        public InventoryController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: Inventory
        public async Task<ActionResult> IndexAsync()
        {
            log.Info("Beginning IndexAsync action method");
            log.Info("Setting url");
            var uri = ServiceUri + "inventory";
            log.Info("Obtaining new http request");
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            try
            {
                log.Info("Obtaining response from api");
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    log.Info("HTTP response error - returned status code not 200");
                    return View("Error");
                }

                log.Info("HTTP response was 200, creating json string");
                string jsonString = await response.Content.ReadAsStringAsync();

                log.Info("Creating list from json string");
                List<Inventory> user = JsonConvert.DeserializeObject<List<Inventory>>(jsonString);

                log.Info("Displaying inventory index");
                return View(user);
            }
            catch (HttpRequestException ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View("Error");
            }
        }


        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            log.Info("Displaying information about single inventory item by id");
            return View();
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            log.Info("Displaying inventory creation view");
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Inventory NewInventory)
        {
            if (!ModelState.IsValid)
            {
                return View(NewInventory);
            }

            try
            {
                string jsonString = JsonConvert.SerializeObject(NewInventory);

                var uri = ServiceUri + "Inventory";
                var request = new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };

                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }


        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            log.Info("Displaying inventory edit view");
            return View();
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            log.Info("Response received");
            try
            {
                // TODO: Add update logic here

                log.Info("Redirecting to inventory index view");
                return RedirectToAction(nameof(IndexAsync));
            }
            catch(Exception ex)
            {
                log.Info("Exception thrown - exiting try block");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            log.Info("Displaying inventory delete view");
            return View();
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            log.Info("Response received");
            try
            {
                // TODO: Add delete logic here

                log.Info("Redirecting to inventory index view");
                return RedirectToAction(nameof(IndexAsync));
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