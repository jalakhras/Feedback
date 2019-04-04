using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Survey()
        {
            return PartialView();
        }
        public ActionResult Suggestion()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Suggestion(string suggestion)
        {
            //send Email
            if (!string.IsNullOrWhiteSpace(suggestion))
            {
                TempData["Status"] = "Your message has been submitted";
            }
            else {
                TempData["Status"] = "Your message could not be submitted";
            }
            return RedirectToAction("Index");
        }
    }
}