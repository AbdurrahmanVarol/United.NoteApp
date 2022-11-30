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
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Users");

            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasMany<Note>(g => g.Notes)
                .WithRequired(s => s.User)
                .HasForeignKey<int>(s => s.UserId)
                .WillCascadeOnDelete(true);

            this.Property(p => p.Id).IsRequired();
            this.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
            this.Property(p => p.LastName).HasMaxLength(100).IsRequired();
            this.Property(p => p.Email).HasMaxLength(100).IsRequired();
            this.Property(p => p.UserName).HasMaxLength(100).IsRequired();
            this.Property(p => p.Password).HasMaxLength(100).IsRequired();
        }
    }
}
