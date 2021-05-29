using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBasketService
    {
        IDataResult<List<Basket>> GetAll();
        IDataResult<Basket> GetById(int basketId);
        IDataResult<List<Basket>> GetByUserId(int userId);
        IDataResult<List<Basket>> GetByTotalPrice(double min, double max);
        IDataResult<List<Basket>> GetByStatus(bool status);
        IResult Add(Basket basket);
        IResult Update(Basket basket);
        IResult Delete(Basket basket);
    }
}
