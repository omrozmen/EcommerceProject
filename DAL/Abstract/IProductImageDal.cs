using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DAL.Abstract
{
    public interface IProductImageDal : IEntityRepository<ProductImage>
    {
        bool IsExist(int id);
    }
}
