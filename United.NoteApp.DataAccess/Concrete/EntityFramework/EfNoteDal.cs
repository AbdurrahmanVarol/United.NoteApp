using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.DataAccess.Abstract;
using United.NoteApp.Entities.Abstract;
using United.NoteApp.Entities.Concrete;

namespace United.NoteApp.DataAccess.Concrete.EntityFramework
{
    public class EfNoteDal : EfEntityRepositoryBase<Note, NoteAppContext>, INoteDal
    {
        private NoteAppContext _context;
        public EfNoteDal()
        {
            _context = new NoteAppContext();
        }
        public override void Delete(Note entity)
        {

            var notes = _context.Notes.Where(p => p.ParentId == entity.Id).ToList();
            if (notes.Any())
            {
                foreach (var note in notes)
                {
                    DeleteSubNotes(note);
                }
            }

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }
        private void DeleteSubNotes(Note subNote)
        {
            var notes = _context.Notes.Where(p => p.ParentId == subNote.Id).ToList();
            if (notes.Any())
            {
                foreach (var note in notes)
                {
                    DeleteSubNotes(note);
                }

            }
            else
            {
                var deletedEntity = _context.Entry(subNote);
                deletedEntity.State = EntityState.Deleted;
            }
        }



    }
}
