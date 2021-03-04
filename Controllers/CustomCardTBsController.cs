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
    public class CustomCardTBsController : Controller
    {
        private DB_A6FB48_MTGDeckBuilderDBEntities3 db = new DB_A6FB48_MTGDeckBuilderDBEntities3();

        // GET: CustomCardTBs
        public ActionResult Index(string name)
        {
            IEnumerable<CustomCardTB> cardList = new List<CustomCardTB>();

            var repo = new CustomCardRepo();

            if (!string.IsNullOrEmpty(name))
            {
                cardList = repo.SearchCustomCard(name);
            }
            else
            {
                cardList = db.CustomCardTBs.ToList();
            }
            return View(cardList);
            //return View(db.CustomCardTBs.ToList());
        }

        public ActionResult YourCards(string name)
        {
            IEnumerable<CustomCardTB> cardList = new List<CustomCardTB>();
            cardList = db.CustomCardTBs.ToList(); ;
            var repo = new CustomCardRepo();


            if (Session["Id"] != null)
            {
                cardList = repo.GetCustomCards(Int32.Parse(Session["Id"].ToString()));
                if(!string.IsNullOrEmpty(name))
                {
                    cardList = repo.SearchUserCustomCard(name, Int32.Parse(Session["Id"].ToString()));
                }
                return View(cardList);
            }
            else
            {
                return View();
            }
        }

        // GET: CustomCardTBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomCardTB customCardTB = db.CustomCardTBs.Find(id);
            if (customCardTB == null)
            {
                return HttpNotFound();
            }
            return View(customCardTB);
        }

        // GET: CustomCardTBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomCardTBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Power,Tough,Image,PlayerId")] CustomCardTB customCardTB)
        {
            if (ModelState.IsValid)
            {
                customCardTB.PlayerId = Int32.Parse(Session["Id"].ToString());
                db.CustomCardTBs.Add(customCardTB);
                db.SaveChanges();
                return RedirectToAction("YourCards");
            }

            return View(customCardTB);
        }

        // GET: CustomCardTBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomCardTB customCardTB = db.CustomCardTBs.Find(id);
            if (customCardTB == null)
            {
                return HttpNotFound();
            }
            return View(customCardTB);
        }

        // POST: CustomCardTBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Power,Tough,Image,PlayerId")] CustomCardTB customCardTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customCardTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("YourCards");
            }
            return View(customCardTB);
        }

        // GET: CustomCardTBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomCardTB customCardTB = db.CustomCardTBs.Find(id);
            if (customCardTB == null)
            {
                return HttpNotFound();
            }
            return View(customCardTB);
        }

        // POST: CustomCardTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomCardTB customCardTB = db.CustomCardTBs.Find(id);
            db.CustomCardTBs.Remove(customCardTB);
            db.SaveChanges();
            return RedirectToAction("YourCards");
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
