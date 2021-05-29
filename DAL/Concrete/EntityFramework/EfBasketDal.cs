using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DAL.Abstract;
using Entities.Concrete;

namespace DAL.Concrete.EntityFramework
{
    public class EfBasketDal:EfEntityRepositoryBase<Basket,EfContext>, IBasketDal
    {
    }
}
