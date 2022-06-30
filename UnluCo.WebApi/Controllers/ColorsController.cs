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
    public class ColorsController : ControllerBase
    {
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        private IColorService _colorService;

        [Authorize]
        [HttpGet("get")]
        public IActionResult GetList()
        {

            var result = _colorService.GetList();
            return Ok(result);
        }
    }
}
