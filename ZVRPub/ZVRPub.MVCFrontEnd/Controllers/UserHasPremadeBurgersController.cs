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
    public class UserHasPremadeBurgersController : AServiceController
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly static string ServiceUri = "https://project2zvrapi.azurewebsites.net/api/";

        public UserHasPremadeBurgersController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: UserHasPremadeBurgers
        public async Task<ActionResult> IndexAsync()
        {
            log.Info("Beginning IndexAsync action method");
            log.Info("Setting url");
            var uri = ServiceUri + "UserPreBuildInv/GetUserPreMade/" + TempData.Peek("username").ToString();
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
                UserHasPremadeBurgerAndItemModel userhasPre = JsonConvert.DeserializeObject<UserHasPremadeBurgerAndItemModel>(jsonString);
                

                log.Info("Displaying inventory index");
                return View(userhasPre);
            }
            catch (HttpRequestException ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View("Error");
            }
        }

        // GET: UserHasPremadeBurgers/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            log.Info("Beginning IndexAsync action method");
            log.Info("Setting url");
            var uri = ServiceUri + "UserPreBuildInv/GetUserPreMade/" + TempData.Peek("username").ToString();
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
                UserHasPremadeBurgerAndItemModel userhasPre = JsonConvert.DeserializeObject<UserHasPremadeBurgerAndItemModel>(jsonString);


                log.Info("Displaying inventory index");
                return View(userhasPre);
            }
            catch (HttpRequestException ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View("Error");
            }
        }

        // GET: UserHasPremadeBurgers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserHasPremadeBurgers/Create
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

        // GET: UserHasPremadeBurgers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserHasPremadeBurgers/Edit/5
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

        // GET: UserHasPremadeBurgers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserHasPremadeBurgers/Delete/5
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