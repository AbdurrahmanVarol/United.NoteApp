using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.Entities.Abstract;

namespace United.NoteApp.Entities.Concrete
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public Note Parent { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
