using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.Business.Abstract;
using United.NoteApp.DataAccess.Abstract;
using United.NoteApp.Entities.Concrete;

namespace United.NoteApp.Business.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal _noteDal;

        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        public Note Add(Note note)
        {
            return _noteDal.Add(note);
        }

        public void Delete(Note note)
        {
            _noteDal.Delete(note);
        }

        public Note GetById(int id)
        {
            return _noteDal.Get(p => p.Id == id);

        }

        public List<Note> GetByUserId(int userId)
        {
            return _noteDal.GetAll(p => p.UserId == userId);
        }
    }
}
