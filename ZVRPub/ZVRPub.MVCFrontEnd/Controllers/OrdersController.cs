using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class OrdersController : Controller
    {

        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly static string ServiceUri = "http://localhost:56667/api/";

        public HttpClient HttpClient { get; }

        public OrdersController(HttpClient httpClient)
        {
            log.Info("Creating instance of orders controller");
            HttpClient = httpClient;
        }

        // GET: Orders
        public async Task<ActionResult> IndexAsync()
        {
            log.Info("Beginning IndexAsync action method");
            log.Info("Setting url");
            var uri = ServiceUri + "Orders";
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
                List<Order> order = JsonConvert.DeserializeObject<List<Order>>(jsonString);

                log.Info("Displaying inventory index");
                return View(order);
            }
            catch (HttpRequestException ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View("Error");
            }
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {

            
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Order NewOrder)
        {

            



            if (!ModelState.IsValid)
            {
                return View(NewOrder);
            }

            

            try
            {
                string jsonString = JsonConvert.SerializeObject(NewOrder);

                var uri2 = ServiceUri + "orders";
                var request2 = new HttpRequestMessage(HttpMethod.Post, uri2)
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };

                var response = await HttpClient.SendAsync(request2);

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


        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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