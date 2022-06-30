using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.BLL.Abstract;
using UnluCo.Entities.Concrete;

namespace UnluCo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        private IProductService _productService;

        [HttpGet("get")]
        public IActionResult GetList()
        {

            var result = _productService.GetProductDetails();
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetProductDetails().Where(x => x.Id.Equals(id)).ToList();
            return Ok(result);
        }

        [HttpGet("category/{id}")]
        public IActionResult GetListByCategoryId(int id)
        {
            var result = _productService.GetProductDetails().Where(x => x.CategoryId.Equals(id)).ToList();
            return Ok(result);
        }

        [Authorize]
        [HttpPost("new")]
        public IActionResult Add([FromForm] Product product)
        {
            try
            {
                var serverPath = String.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.PathBase);
                _productService.AddWithImage(product, serverPath);
                return Ok("Ürün ekleme başarılı!");
            }
            catch (Exception)
            {
                return BadRequest("Lütfen, eksik alanları doldurun!");
            }
        }

        [Authorize]
        [HttpPut("update")]
        public IActionResult Update([FromForm] Product product)
        {
            try
            {
                var serverPath = String.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.PathBase);
                _productService.UpdateWithImage(product, serverPath);
                return Ok("Ürün güncelleme başarılı!");
            }
            catch (Exception)
            {
                return BadRequest("Lütfen, eksik alanları doldurun!");
            }
        }

        [Authorize]
        [HttpDelete("remove-image/{id}")]
        public IActionResult RemoveImage(int id)
        {
            try
            {
                if (id > 0)
                {
                    _productService.RemoveImage(id);
                    return Ok("Ürün resmi Kaldırıldı!");
                }
                else
                {
                    return BadRequest("Lütfen işleme alınacak ürünü belirtiniz.");
                }
            }
            catch (Exception)
            {
                return BadRequest("Servislerimiz şuan hizmet veremiyor, lütfen daha sonra tekrar deneyin!");
            }
        }

    }
}
