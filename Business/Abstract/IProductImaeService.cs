using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<List<ProductImage>> GettAllImageByProductId(int productid);
        IDataResult<ProductImage> GetById(int Id);
        IResult Add(ProductImage productImage, IFormFile file);
        IResult Update(ProductImage productImage, IFormFile file);
        IResult Delete(ProductImage productImage);
        IResult DeleteByProductId(int productId);
    }
}
