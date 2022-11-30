using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.Entities.Concrete;

namespace United.NoteApp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
