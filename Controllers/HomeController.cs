using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using MTGDeckBuilder.Models;
using System.Security.Cryptography;

namespace MTGDeckBuilder.Controllers
{
    public class HomeController : Controller
    {
        private DB_Entities db = new DB_Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Information about the deck of cards.";

            return View();
        }

        public ActionResult Deck()
        {
            ViewBag.Message = "Decks of cards.";

            return View();
        }

        public ActionResult Library()
        {
            ViewBag.Message = "Library of cards.";

            return View();
        }
        public ActionResult Info()
        {
            ViewBag.Message = "Information regarding rules and other info.";

            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Sign up.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Username == user.Username);
                if (check == null)
                {
                    user.Password = GetMD5(user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Username Already Exit";
                    return View();
                }


            }
            return View();


        }


        public ActionResult LogIn()
        {
            ViewBag.Message = "Log in.";

            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}