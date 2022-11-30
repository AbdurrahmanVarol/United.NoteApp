using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace United.NoteApp.MVC.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
    }
}