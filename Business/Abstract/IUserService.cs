using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
       IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult ProfileUpdate(User user, string password);

        IDataResult<User> GetByMail(string email);
        IDataResult<Findeks> GetUserFindeks(Findeks findeks);

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
