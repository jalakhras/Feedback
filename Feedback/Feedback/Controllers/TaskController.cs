using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class TaskController : Controller
    {
      
        public ActionResult ViewAll()
        {
            return View();
        }

        public ActionResult CreateEdit()
        {
            return View();
        }
    }
}