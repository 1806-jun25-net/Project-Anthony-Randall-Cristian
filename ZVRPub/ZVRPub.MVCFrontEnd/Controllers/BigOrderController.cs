using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.MVCFrontEnd.Controllers
{
    public class BigOrderController : Controller
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly static string ServiceUri = "http://localhost:56667/api/";

        public HttpClient HttpClient { get; }

        public BigOrderController(HttpClient httpClient)
        {
            log.Info("Creating instance of orders controller");
            HttpClient = httpClient;
        }
        // GET: BigOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: BigOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BigOrder/Create
        public ActionResult Create()
        {
            List<SelectListItem> location = new List<SelectListItem>();

            SelectListItem Reston = new SelectListItem() { Text = "Reston", Value = "Reston", Selected = true };
            SelectListItem New_York = new SelectListItem() { Text = "New York", Value = "New York", Selected = false };
            SelectListItem Tampa = new SelectListItem() { Text = "Tampa", Value = "Tampa", Selected = false };
            SelectListItem San_Andreas = new SelectListItem() { Text = "San Andreas", Value = "San Andreas", Selected = false };
            location.Add(Reston);
            location.Add(New_York);
            location.Add(Tampa);
            location.Add(San_Andreas);
            ViewBag.locations = location;

            List<SelectListItem> Inv = new List<SelectListItem>();

            SelectListItem Tomato = new SelectListItem() { Text = "Tomato", Value = "Tomato", Selected = true };
            SelectListItem Lettuce = new SelectListItem() { Text = "Lettuce", Value = "Lettuce", Selected = false };
            SelectListItem Mayo = new SelectListItem() { Text = "Mayo", Value = "Mayo", Selected = false };
            SelectListItem Ketchup = new SelectListItem() { Text = "Ketchup", Value = "Ketchup", Selected = false };
            Inv.Add(Tomato);
            Inv.Add(Lettuce);
            Inv.Add(Mayo);
            Inv.Add(Ketchup);
            ViewBag.Inv = Inv;

            List<SelectListItem> Inv1 = new List<SelectListItem>();

            SelectListItem Tomato1 = new SelectListItem() { Text = "Tomato", Value = "Tomato", Selected = true };
            SelectListItem Lettuce1 = new SelectListItem() { Text = "Lettuce", Value = "Lettuce", Selected = false };
            SelectListItem Mayo1 = new SelectListItem() { Text = "Mayo", Value = "Mayo", Selected = false };
            SelectListItem Ketchup1 = new SelectListItem() { Text = "Ketchup", Value = "Ketchup", Selected = false };
            Inv1.Add(Tomato1);
            Inv1.Add(Lettuce1);
            Inv1.Add(Mayo1);
            Inv1.Add(Ketchup1);
            ViewBag.Inv1 = Inv1;
            List<SelectListItem> Inv2 = new List<SelectListItem>();

            SelectListItem Tomato2 = new SelectListItem() { Text = "Tomato", Value = "Tomato", Selected = true };
            SelectListItem Lettuce2 = new SelectListItem() { Text = "Lettuce", Value = "Lettuce", Selected = false };
            SelectListItem Mayo2 = new SelectListItem() { Text = "Mayo", Value = "Mayo", Selected = false };
            SelectListItem Ketchup2 = new SelectListItem() { Text = "Ketchup", Value = "Ketchup", Selected = false };
            Inv2.Add(Tomato2);
            Inv2.Add(Lettuce2);
            Inv2.Add(Mayo2);
            Inv2.Add(Ketchup2);
            ViewBag.Inv2 = Inv2;

            List<SelectListItem> Inv3 = new List<SelectListItem>();

            SelectListItem Tomato3 = new SelectListItem() { Text = "Tomato", Value = "Tomato", Selected = true };
            SelectListItem Lettuce3 = new SelectListItem() { Text = "Lettuce", Value = "Lettuce", Selected = false };
            SelectListItem Mayo3 = new SelectListItem() { Text = "Mayo", Value = "Mayo", Selected = false };
            SelectListItem Ketchup3 = new SelectListItem() { Text = "Ketchup", Value = "Ketchup", Selected = false };
            Inv3.Add(Tomato3);
            Inv3.Add(Lettuce3);
            Inv3.Add(Mayo3);
            Inv3.Add(Ketchup3);
            ViewBag.Inv3 = Inv3;

            List<SelectListItem> Inv4 = new List<SelectListItem>();

            SelectListItem Tomato4 = new SelectListItem() { Text = "Tomato", Value = "Tomato", Selected = true };
            SelectListItem Lettuce4 = new SelectListItem() { Text = "Lettuce", Value = "Lettuce", Selected = false };
            SelectListItem Mayo4 = new SelectListItem() { Text = "Mayo", Value = "Mayo", Selected = false };
            SelectListItem Ketchup4 = new SelectListItem() { Text = "Ketchup", Value = "Ketchup", Selected = false };
            Inv4.Add(Tomato4);
            Inv4.Add(Lettuce4);
            Inv4.Add(Mayo4);
            Inv4.Add(Ketchup4);
            ViewBag.Inv4 = Inv4;
            return View();
        }

        // POST: BigOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BigOrder collection, string locations, string Inv, string Inv1,string Inv2, string Inv3, string Inv4)
        {
            
            string Username = TempData.Peek("username").ToString();


            var BO = new BigOrder
            {
                user = Username,
                Location = locations, 
                burger = collection.burger, 
               
                CockTail = collection.CockTail, 
                Custom_Burger= collection.Custom_Burger, 
                Draft_Beer = collection.Draft_Beer, 
                QuantityDraft_Beer = collection.QuantityDraft_Beer, 
                OrderTime = DateTime.Now, 
                QuantityBurger = collection.QuantityBurger, 
                ingredient = Inv, 
                ingredient1 = Inv1,
                ingredient2 = Inv2, 
                ingredient3 = Inv3, 
                ingredient4 = Inv4, 
                QuantityCocktail = collection.QuantityCocktail,
                QuantityOfBurger = collection.QuantityOfBurger, 
                QuantityTaco = collection.QuantityTaco, 
                QuantityWrap = collection.QuantityWrap, 
                Taco = collection.Taco, 
                wrap = collection.wrap, 
                CustomBurgerYes = collection.CustomBurgerYes

            };

            if (!ModelState.IsValid)
            {
                return View(collection);
            }
            try
            {
                string jsonString = JsonConvert.SerializeObject(BO);

                var uri2 = ServiceUri + "BigOrder";
                var request2 = new HttpRequestMessage(HttpMethod.Post, uri2)
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
                };

                var response = await HttpClient.SendAsync(request2);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
               
                return RedirectToAction("Index", "Home");

               // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }
      
        // GET: BigOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BigOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BigOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BigOrder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}