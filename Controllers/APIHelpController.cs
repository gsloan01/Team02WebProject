using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using MTGDeckBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MTGDeckBuilder.Controllers
{
    public class APIHelpController : Controller
    {
        IMtgServiceProvider serviceProvider = new MtgServiceProvider();
        //IOperationResult<List<ICard>> cards = new IOperationResult<List<ICard>>();
        string resultThing;
        string resultValueThing;


        public async void getCards()
        {
            ICardService service = serviceProvider.GetCardService();
            IOperationResult<List<ICard>> result = await service.AllAsync();
            if (result.IsSuccess)
            {
                var value = result.Value;
            }
            else
            {
                var exception = result.Exception;
            }
            //resultThing = result.ToString();
            //resultValueThing = result.Value.ToString();


        }

        // GET: APIHelp
        public ActionResult Index()
        {
            List<Card> cards = new List<Card>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.magicthegathering.io/v1/cards");
                //HTTP GET
                var responseTask = client.GetAsync("cards");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Card>();
                    readTask.Wait();

                    Console.WriteLine("there should be something here" + readTask.Result.ToString());

                    cards.Add(readTask.Result); //= readTask.Result;
                }
                else //web api sent error response 
                {
                    Console.WriteLine("Error");
                    //log response status here..

                    //cards = Enumerable.Empty<Card>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            foreach (Card card in cards)

            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine(cards.ToString());
            return View(cards);
        }

        // GET: APIHelp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: APIHelp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APIHelp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: APIHelp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: APIHelp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: APIHelp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: APIHelp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

