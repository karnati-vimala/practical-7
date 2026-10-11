
using System.Collections.Generic;
using System.Web.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        // Stores submitted feedback temporarily
        private static List<Feedback> feedbackList =
            new List<Feedback>();

        // Displays the feedback list
        public ActionResult Index()
        {
            return View(feedbackList);
        }

        // Opens the feedback form
        public ActionResult Create()
        {
            return View();
        }

        // Submits the feedback form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);

                return RedirectToAction("Index");
            }

            return View(feedback);
        }
    }
}
