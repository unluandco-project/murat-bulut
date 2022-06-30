using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.BLL.Abstract;
using UnluCo.DAL.Triggers;
using UnluCo.Entities.Concrete;

namespace UnluCo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        public SalesController(ISaleService saleService)
        {
            SaleTrigger.Load();
            _saleService = saleService;
        }
        private ISaleService _saleService;

        [Authorize]
        [HttpGet("get")]
        public IActionResult GetList()
        {

            var result = _saleService.GetList();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("user/{id}")]
        public IActionResult GetListByUserId(int id)
        {

            var result = _saleService.GetList().Where(x => x.UserId.Equals(id)).ToList();
            if (result.Count == 0)
            {
                return Ok("Henüz ürün satın almadınız...");
            }

            return Ok(result);
        }

        [Authorize]
        [HttpPost("new")]
        public IActionResult Add([FromForm] Sale sale)
        {
            try
            {
                _saleService.Add(sale);
                return Ok("Ürün satın alındı...");
            }
            catch (Exception)
            {
                return BadRequest("Lütfen, eksik alanları doldurun!");
            }
        }
    }
}
