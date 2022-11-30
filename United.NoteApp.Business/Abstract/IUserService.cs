using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.Entities.Concrete;

namespace United.NoteApp.Business.Abstract
{
    public interface IUserService
    {
        User Add(User user);
        User GetByName(string userName);
    }
}
