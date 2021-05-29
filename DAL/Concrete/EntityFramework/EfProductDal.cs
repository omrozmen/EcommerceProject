using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DAL.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, EfContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (EfContext context = new EfContext())
            {
                var result = from p in context.Products
                             join c1 in context.Categories1 on p.Category1Id equals c1.Id
                             join c2 in context.Categories2 on p.Category2Id equals c2.Id
                             join c3 in context.Categories3 on p.Category3Id equals c3.Id

                             select new ProductDetailDto
                             {

                                 Category1Id = p.Category1Id,
                                 Category2Id = p.Category2Id,
                                 ProductId= p.Id,
                                 ProductName = p.ProductName,
                                 Category1Name = c1.Name,
                                 Category2Name = c2.Name,
                                 Category3Name = c3.Name,
                                 Price = p.Price
                             };
                return result.ToList();
            }
        }
    }
}
