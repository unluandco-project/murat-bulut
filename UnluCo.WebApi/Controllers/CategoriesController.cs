using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.BLL.Abstract;
using UnluCo.DAL.Concrete;
using UnluCo.Entities.Concrete;

namespace UnluCo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        private ICategoryService _categoryService;

        [HttpGet("get")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] Category category)
        {
            try
            {
                _categoryService.Add(category);
                return Ok("Kategori başarıyla eklendi");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [Authorize]
        [HttpPut]
        public IActionResult Update([FromForm] Category category)
        {
            try
            {
                _categoryService.Update(category);
                return Ok("Kategori başarıyla güncellendi");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }
}
