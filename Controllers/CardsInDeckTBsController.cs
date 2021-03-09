using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MTGDeckBuilder.Models;

namespace MTGDeckBuilder.Controllers
{
    public class CardsInDeckTBsController : Controller
    {
        private DB_A6FB48_MTGDeckBuilderDBEntities3 db = new DB_A6FB48_MTGDeckBuilderDBEntities3();

        // GET: CardsInDeckTBs
        public ActionResult Index(int deckId/*, int cardId*/)
        {

            //IEnumerable<DeckTB> deck = new List<DeckTB>();
            IEnumerable<CustomCardTB> cardList = new List<CustomCardTB>();


            var repo = new CardsInDeckRepo();

            cardList = repo.GetCardsInDeck(deckId);

            return View(cardList);
        }


        // GET: CardsInDeckTBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardsInDeckTB cardsInDeckTB = db.CardsInDeckTBs.Find(id);
            if (cardsInDeckTB == null)
            {
                return HttpNotFound();
            }
            return View(cardsInDeckTB);
        }

        // GET: CardsInDeckTBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CardsInDeckTBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeckId,CardId")] CardsInDeckTB cardsInDeckTB)
        {
            if (ModelState.IsValid)
            {
                db.CardsInDeckTBs.Add(cardsInDeckTB);
                db.SaveChanges();
                return RedirectToAction("Index", "DeckTBs");
            }

            return View(cardsInDeckTB);
        }

        // GET: CardsInDeckTBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardsInDeckTB cardsInDeckTB = db.CardsInDeckTBs.Find(id);
            if (cardsInDeckTB == null)
            {
                return HttpNotFound();
            }
            return View(cardsInDeckTB);
        }

        // POST: CardsInDeckTBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeckId,CardId")] CardsInDeckTB cardsInDeckTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardsInDeckTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "DeckTBs");
            }
            return View(cardsInDeckTB);
        }

        // GET: CardsInDeckTBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardsInDeckTB cardsInDeckTB = db.CardsInDeckTBs.Find(id);
            if (cardsInDeckTB == null)
            {
                return HttpNotFound();
            }
            return View(cardsInDeckTB);
        }

        // POST: CardsInDeckTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardsInDeckTB cardsInDeckTB = db.CardsInDeckTBs.Find(id);
            db.CardsInDeckTBs.Remove(cardsInDeckTB);
            db.SaveChanges();
            return RedirectToAction("Index", "DeckTBs");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
