using Feedback.Models;
using System.Linq;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class HomeController : Controller
    {
        private readonly FeedbackContext _context; 

        public HomeController(FeedbackContext context)
        {
            _context = context; 
        }
        public ActionResult Index()
        {

            var dash = new DashBoardVM()
            {
                Messages = _context.Threads
                    .SelectMany(x => x.Messages).OrderByDescending(c => c.Created).ToList()
                    .GroupBy(y => y.MessageThreadId).Select(grp => grp.FirstOrDefault()).ToList().Take(5),
                Tasks = _context.Tasks.OrderByDescending(x => x.Created).Take(5)
            };

            return View(dash);
        }

        public ActionResult Survey()
        {
            var admins = _context.Admins.OrderByDescending(x => x.Votes.Count).ToList();

            if (Session["HasVoted"] != null)
            {
                return PartialView("SurveyResults", admins);
            }

            return PartialView(admins);
        }

        [HttpPost]
        public ActionResult Survey(int adminId)
        {
            _context.Votes.Add(new Vote() { AdminId = adminId });
            _context.SaveChanges();

            var admins = _context.Admins.OrderByDescending(x => x.Votes.Count).ToList();

            Session["HasVoted"] = true;
            return PartialView("SurveyResults", admins);
        }

        public ActionResult Suggestion()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Suggestion(string suggestion)
        {
            //Send email, return true or false for success
            var emailSent = true;

            return PartialView("SuggestionResult", emailSent);
        }
    }
}