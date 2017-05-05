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

namespace yanzhilong.Controllers
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

        [Authentication]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Note note = noteService.GetTutorialsById(id);
            return View(note.ToModel());
        }
    }
}