using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByUserName(string userName);
        IDataResult<List<User>> GetNameSurname(string nameSurname);
        IDataResult<List<User>> GetByGender(string gender);
        IResult Add(User users);
        IResult Update(User users);
        IResult Delete(User users);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
