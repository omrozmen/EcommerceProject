using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileUpload;
using Core.Utilities.Result;
using DAL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{

    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal
        )
        {
            _productImageDal = productImageDal;
        }
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GettAllImageByProductId(int productid)
        {
            return new SuccessDataResult<List<ProductImage>>(CheckIfProductHaveNoImage(productid));

        }

        public IResult DeleteByProductId(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId);
            if (result.Any())
            {
                foreach (var productImage in result)
                {
                    Delete(productImage);
                }
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductHaveNoImage);
        }
        public IDataResult<ProductImage> GetById(int Id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(c => c.Id == Id));
        }

        public IResult Add(ProductImage productImage, IFormFile file)
        {
            var result =
                BusinessRules.Run
                (
                CheckIfImageLimitExpired(productImage.ProductId),
                CheckIfImageExtensionValid(file)
                );
            if (result != null)
            {
                return result;
            }

            productImage.ImagePath = FileHelper.Add(file);
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        public IResult Update(ProductImage productImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(productImage.ProductId),
                CheckIfImageExtensionValid(file),
                CheckIfImageExist(productImage.Id));
            if (result != null)
            {
                return result;
            }

            ProductImage oldProductImage = GetById(productImage.Id).Data;
            productImage.ImagePath = FileHelper.Update(file, oldProductImage.ImagePath);
            productImage.Date = DateTime.Now;
            productImage.ProductId = oldProductImage.ProductId;
            _productImageDal.Update(productImage);
            //_productImageDal.Update(result);
            return new SuccessResult();


        }
        [SecuredOperation("product.delete,admin")]
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Delete(ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageExist(productImage.Id));
            if (result != null)
            {
                return result;
            }

            string path = GetById(productImage.Id).Data.ImagePath;
            FileHelper.Delete(path);
            _productImageDal.Delete(productImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitExpired(int productId)
        {
            var result = _productImageDal.GetAll(i => i.ProductId == productId).Count;
            if (result >= 5)
            {
                return new ErrorResult("Hatalı İşlem");
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (isValidFileExtension!)
            {
                return new ErrorResult("Resim mevcut olabilir");
            }
            return new SuccessResult();
        }

        private List<ProductImage> CheckIfProductHaveNoImage(int productId)
        {
            string path = @"Images/default.png";
            var result = _productImageDal.GetAll(p => p.ProductId == productId);
            if (Equals(!result.Any()))
            {
                return new List<ProductImage>
                {
                    new ProductImage
                    {
                        ProductId = productId, ImagePath = path
                    }
                };

            }
            return result;
        }

        private IResult CheckIfImageExist(int id)
        {
            if (_productImageDal.IsExist(id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductImageMustBeExist);
        }
    }
}
