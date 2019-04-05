using Feedback.Models;
using System.Linq;
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
            var context = new FeedbackContext();
            var admins = context.Admins.OrderByDescending(x => x.Votes.Count).ToList();

            if (Session["HasVoted"] != null)
            {
                return PartialView("SurveyResults", admins);
            }

            return PartialView(admins);
        }
        [HttpPost]
        public ActionResult Survey(int adminId)
        {
            var context = new FeedbackContext();
            context.Votes.Add(new Vote() { AdminId = adminId });
            context.SaveChanges();

            var admins = context.Admins.OrderByDescending(x => x.Votes.Count).ToList();

            Session["HasVoted"] = true;
            return RedirectToAction("Index");
        }
        public ActionResult Suggestion()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Suggestion(string suggestion)
        {
            //send Email
            var emailSend = true;
            return PartialView("SuggestionResult", emailSend);
        }
    }
}