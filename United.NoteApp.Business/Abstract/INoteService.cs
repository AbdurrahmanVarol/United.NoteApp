using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.Entities.Concrete;

namespace United.NoteApp.Business.Abstract
{
    public interface INoteService
    {
        Note Add(Note note);
        void Delete(Note note);
        Note GetById(int id);
        List<Note> GetByUserId(int userId);
    }
}
