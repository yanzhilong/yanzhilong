using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Infrastructure.Mapper;
using yanzhilong.Models;
using yanzhilong.Service;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class NoteController : Controller
    {
        private NoteService noteService = new NoteService();
        [Authentication]
        public ActionResult Index()
        {
            return List();
        }

        [Authentication]
        public ActionResult List(int page = 1)
        {
            PageModel pagemodel = new PageModel(Constant.PAGESIZE, page, noteService.GetCount());
            pagemodel.actionName = "List";
            pagemodel.controllerName = "Note";
            ViewBag.pagemodel = pagemodel;

            var notes = noteService.GetNotes(page);
            IEnumerable<NoteModel> noteModels = notes.Select(x => x.ToModel());

            return View("Index", noteModels);
        }

        // GET: GuestBook/Create
        [Authentication]
        public ActionResult Create()
        {
            NoteModel noteModel = new NoteModel();
            return View(noteModel);
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(NoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                noteModel.NoteID = Guid.NewGuid().ToString();
                noteModel.CreateAt = DateTime.Now;
                noteModel.UpdateAt = DateTime.Now;
                Note note = noteModel.ToEntity();
                noteService.Create(note);
                return RedirectToAction("Index");
            }
            return View(noteModel);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = noteService.GetTutorialsById(id);
            NoteModel noteModel = note.ToModel();

            return View(noteModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(NoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                Note note = noteModel.ToEntity();
                noteService.Update(note);
                return RedirectToAction("Index");
            }
            return View(noteModel);
        }
        [Authentication]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            noteService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}