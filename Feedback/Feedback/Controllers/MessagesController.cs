using Feedback.Models;
using System.Linq;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class MessagesController : Controller
    {
        //private FeedbackContext _context;

        //public MessagesController(FeedbackContext context)
        //{
        //    _context = context;
        //}

        public ActionResult ViewAll()
        {
            FeedbackContext _context = new FeedbackContext();
            var messages = _context.Threads
                    .SelectMany(x => x.Messages).OrderByDescending(c => c.Created).ToList()
                    .GroupBy(y => y.MessageThreadId).Select(grp => grp.FirstOrDefault()).ToList();

            return View(messages);
        }
        public ActionResult Reply()
        {
            return View();
        }
    }
}