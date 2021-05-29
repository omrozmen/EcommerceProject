using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Result;
using DAL.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IDataResult<List<Basket>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>( _basketDal.GetAll());
        }

        public IDataResult<Basket> GetById(int basketId)
        {
            return new SuccessDataResult<Basket>(_basketDal.Get(b => b.Id == basketId));
        }

        public IDataResult<List<Basket>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetAll(u => u.UserId == userId));
        }

        public IDataResult<List<Basket>> GetByTotalPrice(double min, double max)
        {
            return new SuccessDataResult<List<Basket>>( _basketDal.GetAll(p => p.TotalPrice > min && p.TotalPrice < max));
        }

        public IDataResult<List<Basket>> GetByStatus(bool status)
        {
            return new SuccessDataResult<List<Basket>>( _basketDal.GetAll(s => s.Status_ == status));
        }

        public IResult Add(Basket basket)
        {
            _basketDal.Add(basket);
            return new SuccessResult();
        }

        public IResult Update(Basket basket)
        {
           _basketDal.Update(basket);
           return new SuccessResult();
        }

        public IResult Delete(Basket basket)
        {
            _basketDal.Delete(basket);
            return new SuccessResult();
        }
    }
}
