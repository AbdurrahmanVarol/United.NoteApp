using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.DataAccess.Abstract;
using United.NoteApp.Entities.Concrete;

namespace United.NoteApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NoteAppContext>, IUserDal
    {

    }
}
