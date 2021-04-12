using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Performance;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
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
            var result = _userDal.GetAll();

            if (result is null)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFound);

            }

            return new SuccessDataResult<List<User>>(result, Messages.Listed);

        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(c => c.Id == userId);
            if (result is null)
            {

                return new ErrorDataResult<User>(Messages.NotFound);


            }

            return new SuccessDataResult<User>(result, Messages.Listed); 
        }
        [PerformanceAspect(5)]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));

        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }


     

     

       

        public IResult ProfileUpdate(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var updatedUser = new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = user.Status

            };

            _userDal.Update(updatedUser);
            return new SuccesResult(Messages.Updated);

        }

     

        public IDataResult<Findeks> GetUserFindeks(Findeks findeks)
        {
            Random rmd = new Random();

            var userFindeks = new Findeks
            {
                Tc = findeks.Tc,
                DataYear = findeks.DataYear,
                UserFindeks = rmd.Next(0, 1900)

            };

            return new SuccessDataResult<Findeks>(userFindeks);
        }
    }
}
