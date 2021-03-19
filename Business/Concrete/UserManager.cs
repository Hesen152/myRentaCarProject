using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult Add(User user)
        {
           
            _userDal.Add(user);

            return new SuccesResult();
        }



        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }


        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }


        IDataResult<List<User>> IUserService.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<User> IUserService.GetById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
