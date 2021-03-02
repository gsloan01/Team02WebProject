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
    public class DeckTBsController : Controller
    {
        private DB_A6FB48_MTGDeckBuilderDBEntities2 db = new DB_A6FB48_MTGDeckBuilderDBEntities2();
        // GET: DeckTBs
        public ActionResult Index()
        {
            IEnumerable<DeckTB> deckList = new List<DeckTB>();
            deckList = db.DeckTBs.ToList(); ;
            var repo = new DeckRepo();


            if (Session["Id"] != null)
            {
                deckList = repo.GetDecks(Int32.Parse(Session["Id"].ToString()));
                return View(deckList);
            }
            else
            {
                return View();
            }
            
   
            //return View(db.DeckTBs.ToList());
        }

        // GET: DeckTBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeckTB deckTB = db.DeckTBs.Find(id);
            if (deckTB == null)
            {
                return HttpNotFound();
            }
            return View(deckTB);
        }

        // GET: DeckTBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeckTBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeckId,PlayerId,DeckName")] DeckTB deckTB)
        {
            if (ModelState.IsValid)
            {
                db.DeckTBs.Add(deckTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deckTB);
        }

        // GET: DeckTBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeckTB deckTB = db.DeckTBs.Find(id);
            if (deckTB == null)
            {
                return HttpNotFound();
            }
            return View(deckTB);
        }

        // POST: DeckTBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeckId,PlayerId,DeckName")] DeckTB deckTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deckTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deckTB);
        }

        // GET: DeckTBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeckTB deckTB = db.DeckTBs.Find(id);
            if (deckTB == null)
            {
                return HttpNotFound();
            }
            return View(deckTB);
        }

        // POST: DeckTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeckTB deckTB = db.DeckTBs.Find(id);
            db.DeckTBs.Remove(deckTB);
            db.SaveChanges();
            return RedirectToAction("Index");
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
