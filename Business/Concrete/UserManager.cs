using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userdal)
        {
            _userDal=userdal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("eklendi kardeşim");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("silindi kardeşim");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId==id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("user güncellendi");
        }
    }
}
