using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Transactions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [CacheAspect]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(c => c.Id == productId));
        }

        public IDataResult<List<Product>> GetByCategory1Id(int category1Id)
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(c => c.Category1Id == category1Id));
        }

        public IDataResult<List<Product>> GetByCategory2Id(int category2Id)
        {
            return new SuccessDataResult<List<Product>>();
        }

        public IDataResult<List<Product>> GetByCategory3Id(int category3Id)
        {
            throw new NotImplementedException();
        }


        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName));
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult("işlem başarılı");
        }

        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            return null;
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
