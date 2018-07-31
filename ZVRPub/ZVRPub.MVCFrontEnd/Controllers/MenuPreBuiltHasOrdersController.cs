using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class MenuPreBuiltHasOrdersController : Controller
    {

        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly static string ServiceUri = "http://localhost:56667/api/";

        public HttpClient HttpClient { get; }

        public MenuPreBuiltHasOrdersController (HttpClient httpClient)
        {
            log.Info("Creating instance of MenuPreBuiltHasOrdersController controller");
            HttpClient = httpClient;
        }

        // GET: MenuPreBuiltHasOrders
        public async Task<ActionResult> IndexAsync()
        {
            log.Info("Beginning IndexAsync action method");
            log.Info("Setting url");
            var uri = ServiceUri + "MenuPreBuiltHasOrders";
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
                List<MenuPrebuiltHasOrders> menuPre = JsonConvert.DeserializeObject<List<MenuPrebuiltHasOrders>>(jsonString);

                log.Info("Displaying inventory index");
                return View(menuPre);
            }
            catch (HttpRequestException ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View("Error");
            }
        }

        // GET: MenuPreBuiltHasOrders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuPreBuiltHasOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuPreBuiltHasOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MenuPrebuiltHasOrders NewPreOrder)
        {
            if (!ModelState.IsValid)
            {
                return View(NewPreOrder);
            }

            try
            {
                string jsonString = JsonConvert.SerializeObject(NewPreOrder);

                var uri = ServiceUri + "Location";
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

        // GET: MenuPreBuiltHasOrders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MenuPreBuiltHasOrders/Edit/5
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

        // GET: MenuPreBuiltHasOrders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MenuPreBuiltHasOrders/Delete/5
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