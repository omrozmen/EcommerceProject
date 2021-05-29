using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int ProductId);
        IDataResult<List<Product>> GetByCategory1Id(int category1Id);
        IDataResult<List<Product>> GetByCategory2Id(int category2Id);
        IDataResult<List<Product>> GetByCategory3Id(int category3Id);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IResult Add(Product product);
        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);
    }
}
