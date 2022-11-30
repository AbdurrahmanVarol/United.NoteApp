using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using United.NoteApp.Business.Abstract;
using United.NoteApp.DataAccess.Abstract;
using United.NoteApp.Entities.Concrete;
namespace United.NoteApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Add(User user)
        {
           
            return _userDal.Add(user);
        }

        public User GetByName(string userName)
        {
            return _userDal.Get(p => p.UserName.Equals(userName));
        }
    }
}
