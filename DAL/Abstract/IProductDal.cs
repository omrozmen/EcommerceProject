using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using Entities.DTOs;

namespace DAL.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
   {
       List<ProductDetailDto> GetProductDetails();
   }
}
