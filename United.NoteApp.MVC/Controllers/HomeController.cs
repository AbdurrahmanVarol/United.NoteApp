using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using United.NoteApp.Business.Abstract;
using United.NoteApp.Business.Concrete;
using United.NoteApp.DataAccess.Concrete.EntityFramework;
using United.NoteApp.Entities.Concrete;
using United.NoteApp.MVC.Models;

namespace United.NoteApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService = new NoteManager(new EfNoteDal());
        [HttpGet]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Request.Cookies["UserId"].Value);
            var notes = _noteService.GetByUserId(id);
            return View(notes);
        }

        [HttpGet]
        public JsonResult GetNotes()
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddNote(NoteModel noteModel)
        {
            int userId = Convert.ToInt32(Request.Cookies["UserId"].Value);
            Note note = new Note
            {
                Title = noteModel.Title,
                Description = noteModel.Description,
                UserId = userId
            };
            _noteService.Add(note);

            
            var notes = _noteService.GetByUserId(userId);
            return Json(notes, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteNote(int id)
        {
            Note note = _noteService.GetById(id);
            _noteService.Delete(note);

            int userId = Convert.ToInt32(Request.Cookies["UserId"].Value);
            var notes = _noteService.GetByUserId(userId);
            return Json(notes, JsonRequestBehavior.AllowGet);
        }
    }
}