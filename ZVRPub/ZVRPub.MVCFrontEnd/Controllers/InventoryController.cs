﻿using System;
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
    public class InventoryController : Controller
    {

        private readonly static string ServiceUri = "http://localhost:56667/api/";

        public HttpClient HttpClient { get; }

        public InventoryController(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        // GET: Inventory
        public async Task<ActionResult> IndexAsync(string searchString)
        {
            var uri = ServiceUri + "inventory";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Inventory> inventory = JsonConvert.DeserializeObject<List<Inventory>>(jsonString);

                if (!String.IsNullOrEmpty(searchString))
                {
                    inventory = inventory.Where(s => s.IngredientName.Contains(searchString)).ToList();
                }


                return View(inventory);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
        }


        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
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
            return View();
        }

        // POST: Inventory/Edit/5
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

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Delete/5
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