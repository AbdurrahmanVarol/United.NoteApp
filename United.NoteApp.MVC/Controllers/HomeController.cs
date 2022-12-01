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
    [Route("[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        private readonly INoteService _noteService = new NoteManager(new EfNoteDal());

        public ActionResult Index()
        {
            var cookie = Request.Cookies["UserId"].Value;
            if (string.IsNullOrEmpty(cookie))
                return RedirectToAction("login", "login");

            var id = Convert.ToInt32(cookie);
            var notes = _noteService.GetByUserId(id);
            return View(notes);
        }

        [HttpGet]
        public JsonResult GetNotes()
        {
            var cookie = Request.Cookies["UserId"].Value;
            if (string.IsNullOrEmpty(cookie))
                return Json("", JsonRequestBehavior.AllowGet);

            var id = Convert.ToInt32(cookie);
            var notes = _noteService.GetByUserId(id);
            return Json(notes, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddNote(NoteModel noteModel)
        {
            int userId = Convert.ToInt32(Request.Cookies["UserId"].Value);
            Note note = new Note
            {
                Title = noteModel.Title,
                Description = noteModel.Description,
                ParentId = noteModel.ParentId,
                UserId = userId
            };
            _noteService.Add(note);


            return GetNotes();
        }
        [HttpGet]
        public JsonResult DeleteNote(int id)
        {
            Note note = _noteService.GetById(id);
            _noteService.Delete(note);

            return GetNotes();
        }
    }
}