using EleventyNote.Models;
using EleventyNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EleventyNote.Web.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId()); Pass this to svc if it's screwed
            var svc = new NoteService(Guid.Parse(User.Identity.GetUserId()));
            var model = svc.GetNotes();
            return View(model);
        }
        public ActionResult Create()
        {
            var model = new NoteCreateModel();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new NoteService(userId);

            if (!svc.CreateNote(model))
            {
                ModelState.AddModelError("", "Unable to create note");
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}