using AutoMapper;
using Feedback.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class TaskController : Controller
    {
        private readonly FeedbackContext _context;
        public TaskController(FeedbackContext context)
        {
            _context = context; 
        }
        public ActionResult ViewAll()
        {
            var tasks = _context.Tasks.OrderByDescending(x => x.Created).ToList();
            return View(tasks);
        }


        public ActionResult CreateEdit(int Id = 0)
        {
            ViewBag.Categories = _context.Categories
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            if (Id != 0)
            {
                var task = _context.Tasks.FirstOrDefault(x => x.Id == Id);
                var mappedTask = Mapper.Map<TaskVM>(task);
                mappedTask.AssociatedMessageDisplay = task.AssociatedMessage.Subject;

                return View(mappedTask);
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateEdit(Task task)
        {
            if (ModelState.IsValid)
            {
                var editTask = _context.Tasks.FirstOrDefault(x => x.Id == task.Id);
                if (editTask != null)
                {
                    //Updating Task
                    editTask.Title = task.Title;
                    editTask.Description = task.Description;
                    editTask.Category = task.Category;
                    editTask.AssignedToId = task.AssignedToId;
                    editTask.DueDate = task.DueDate;
                    editTask.AssociatedMessageId = task.AssociatedMessageId;
                    editTask.Completed = task.Completed;
                    editTask.Notes = task.Notes;
                    _context.Entry(editTask).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    //New Task
                    _context.Tasks.Add(task);
                    task.Created = DateTime.Now;
                }
                _context.SaveChanges();
                return RedirectToAction("ViewAll");
            }

            ViewBag.Categories = _context.Categories
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return View(task);
        }
        public ActionResult MessageSuggestions(string term)
        {
            var messages = _context.Messages.Where(x => x.Subject.Contains(term))
                .Select(x => new { Label = x.Subject, Id = x.Id }).ToList();
            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AssignToSuggestions(string term)
        {
            var Admins = _context.Admins.Where(x => x.Username.Contains(term))
                .Select(x => new { Label = x.Username, Id = x.Id }).ToList();
            return Json(Admins, JsonRequestBehavior.AllowGet);
        }
    }
}