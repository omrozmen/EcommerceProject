using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DAL.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
        public IDataResult<User> GetByMail(string email)

        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),
                Messages.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.UsersListed);
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserName_ == userName), Messages.UsersListed);
        }

        public IDataResult<List<User>> GetNameSurname(string nameSurname)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == nameSurname), Messages.UsersListed);
        }

        public IDataResult<List<User>> GetByGender(string gender)
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User users)
        {

            IResult result = BusinessRules.Run(UniqueEmail(users.UserName_));
            if (result != null)
            {
                return result;
            }

            _userDal.Add(users);
            return new SuccessResult(Messages.UserAdded);


        }

        private IResult UniqueEmail(string email)
        {
            var result = _userDal.GetAll(u => u.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.Error);
            }
            return new SuccessResult();
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User users)
        {
            var result = _userDal.GetAll(p => p.UserName_ == users.UserName_ || p.Email == users.Email).Any();
            if (result)
            {
                return new ErrorResult();
            }
            _userDal.Update(users);
            return new SuccessResult();
        }

        public IResult Delete(User users)
        {
            return new SuccessResult();
        }
    }
}
