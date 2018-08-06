using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NLog;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class UserController : AServiceController
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

       public UserController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: User
        public async Task<ActionResult> IndexAsync(string searchString)
        {
            log.Info("Beginning creation of httprequest message");
            var request = CreateRequestToService(HttpMethod.Get, "api/user");

            try
            {
                //string CurrentUser = TempData.Peek("username").ToString();
                //if (CurrentUser.Equals(""))
                //{
                //    return View("AccessDenied");
                //}
                //log.Info("Sending http request");
                var response = await HttpClient.SendAsync(request);
                log.Info("Request sent");

                if((int)response.StatusCode == 404)
                {
                    return View("AccessDeniedAdmin");
                }

                if (!response.IsSuccessStatusCode)
                {
                    log.Info("Error: HTTP request sent back non-200 message");
                    log.Info("Displaying error view");
                    return View("AccessDenied");
                }

                log.Info("HTTP status code 200 - creating json string");
                string jsonString = await response.Content.ReadAsStringAsync();

                log.Info("Deserializing json string into list");
                List<User> user = JsonConvert.DeserializeObject<List<User>>(jsonString);


                
                if (!String.IsNullOrEmpty(searchString))
                {
                    log.Info("Commencing search for usernames containing provided string");
                    user = user.Where(s => s.Username.ToLower().Contains(searchString.ToLower())).ToList();
                }

                log.Info("Redisplaying index view with given search string");
                return View(user);
            }
            catch(HttpRequestException ex)
            {
                log.Info("Exception thrown - exiting try block");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                log.Info("Displaying error view");
                return View("Error");
            }
        }

        // GET: User/Details/5
        public async Task<ActionResult> DetailsAsync(string username = "")
        {
            if (TempData.Peek("username") != null)
            {
                username = (string)TempData.Peek("username");
            }
            log.Info("Beginning creation of httprequest message");
            var request = CreateRequestToService(HttpMethod.Get, "api/user/username?=" + username);

            try
            {
                log.Info("Sending http request");
                var response = await HttpClient.SendAsync(request);
                log.Info("Request sent");

                if (!response.IsSuccessStatusCode)
                {
                    if (username.Equals(""))
                    {
                        return View("AccessDeniedProfile");
                    }
                    log.Info("Error: HTTP request sent back non-200 message");
                    log.Info("Displaying error view");
                    return View("Error");
                }

                log.Info("HTTP status code 200 - creating json string");
                string jsonString = await response.Content.ReadAsStringAsync();

                log.Info("Deserializing json string into list");
                var user = JsonConvert.DeserializeObject<User>(jsonString);


                log.Info("Redisplaying index view with given search string");
                return View(user);
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

        // GET: User/Create
        public ActionResult Create()
        {
            log.Info("Displaying user creation view");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User NewUser)
        {
            log.Info("response received");
            if (!ModelState.IsValid)
            {
                log.Info("Model state invalid");
                return View(NewUser);
            }

            try
            {
                log.Info("Serializing json string");
                string jsonString = JsonConvert.SerializeObject(NewUser);

                log.Info("Creating new url");
                var request = CreateRequestToService(HttpMethod.Post, "https://project2zvrapi.azurewebsites.net/api/Account/Register");
                request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                log.Info("Sending http request");
                var response = await HttpClient.SendAsync(request);
                if ((int)response.StatusCode == 418 )
                {
                    TempData["TakenInfo"] = "The username you are trying to use has been taken. Please select different username.";
                    return RedirectToAction(nameof(Create));
                }

                if ((int)response.StatusCode == 400)
                {
                   TempData["TakenInfo"] = "Your password must be at least 6 characters long with at least one capital letter, one number, and one special character.";
                   return RedirectToAction(nameof(Create));
                }

                if (!response.IsSuccessStatusCode)
                {
                    log.Info("Error: HTTP status code not 200 or 201. Displaying error view");
                    return View("Error");
                }

                log.Info("HTTP status code 200 or 201. Redirecting to user index view");
                TempData["username"] = NewUser.Username;
                return RedirectToAction(nameof(DetailsAsync));
            }
            catch(Exception ex)
            {
                log.Info("Exception thrown - exiting try block");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            log.Info("Displaying edit user view based on user id");
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            log.Info("response received");
            try
            {
                // TODO: Add update logic here

                log.Info("Redirecting to user index view");
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            log.Info("Displaying delete user view");
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            log.Info("response received");
            try
            {
                // TODO: Add delete logic here

                log.Info("Redirecting to user index view");
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

        public ActionResult Manager()
        {
            return Redirect("http://localhost:4200");
        }
    }
}