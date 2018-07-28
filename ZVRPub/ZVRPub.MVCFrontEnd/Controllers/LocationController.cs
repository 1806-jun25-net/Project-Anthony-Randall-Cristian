using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class LocationController : Controller
    {
        private readonly static string ServiceUri = "http://localhost:56667/api/";

        public HttpClient HttpClient { get; }

        public LocationController(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        // GET: Location
        public async Task<ActionResult> IndexAsync(string searchString)
        {
            var uri = ServiceUri + "Location";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Location> inventory = JsonConvert.DeserializeObject<List<Location>>(jsonString);

                if (!String.IsNullOrEmpty(searchString))
                {
                    inventory = inventory.Where(s => s.City.Contains(searchString)).ToList();
                }


                return View(inventory);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Location NewLocation)
        {
            if (!ModelState.IsValid)
            {
                return View(NewLocation);
            }

            try
            {
                string jsonString = JsonConvert.SerializeObject(NewLocation);

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

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Location NewLocation)
        {
            if (!ModelState.IsValid)
            {
                return View(NewLocation);
            }

            try
            {
                string jsonString = JsonConvert.SerializeObject(NewLocation);

                var uri = ServiceUri + "Location";
                var request = new HttpRequestMessage(HttpMethod.Put, uri)
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

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
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