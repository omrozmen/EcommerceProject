using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallimagebyproductid")]
        public IActionResult GetAllImageByProductId(int productid)
        {
            var result = _productImageService.GettAllImageByProductId(productid);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] ProductImage productImage, [FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Resim Gelmiyor..");
            }

            IResult result = _productImageService.Add(productImage, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] ProductImage productImage, [FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Boş Resim Gönderilemez.");
            }

            IResult result = _productImageService.Update(productImage, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] ProductImage productImage)
        {
            IResult result = _productImageService.Delete(productImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletebyproductid")]
        public IActionResult DeleteByProductId(int productid)
        {
            IResult result = _productImageService.DeleteByProductId(productid);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
