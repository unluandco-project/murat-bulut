using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.BLL.Abstract;

namespace UnluCo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        private IBrandService _brandService;

        [Authorize]
        [HttpGet("get")]
        public IActionResult GetList()
        {

            var result = _brandService.GetList();
            return Ok(result);
        }
    }
}
