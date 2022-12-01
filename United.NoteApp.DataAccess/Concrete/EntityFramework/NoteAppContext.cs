using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.Entities.Concrete;

namespace United.NoteApp.DataAccess.Concrete.EntityFramework
{
    public  class NoteAppContext : DbContext
    {
        public NoteAppContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
