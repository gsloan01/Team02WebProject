using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTGDeckBuilder.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult SignUp()
        {
            ViewBag.Message = "Sign up.";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Message = "Log in.";

            return View();
        }
    }
}