using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.Entities.Concrete;

namespace United.NoteApp.DataAccess.Concrete.EntityFramework.Mapping
{
    public class NoteMap : EntityTypeConfiguration<Note>
    {
        public NoteMap()
        {
            this.ToTable("Notes");

            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired<User>(s => s.User)
                .WithMany(g => g.Notes)
                .HasForeignKey<int>(s => s.UserId);

            this.Property(p => p.Id).IsRequired();
            this.Property(p => p.Description).HasMaxLength(100).IsRequired();
        }
    }
}
