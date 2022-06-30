using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.BLL.Abstract;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.Models;
using UnluCo.WebApi.Utilities;

namespace UnluCo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        private IUserService _userService;

        [HttpPost("login")]
        public IActionResult Login([FromForm] LoginModel user)
        {
            try
            {
                var result = _userService.Login(user);

                if (!(result is null))
                {
                    if (!(result is bool))
                    {
                        var token = TokenTool.Create();
                        return Ok(token);
                    }
                    else
                    {
                        return BadRequest("Çok fazla hatalı şifre girişi yaptınız, hesabınız askıya alındı!");
                    }

                }

                return NotFound("E-posta adresi veya şifre yanlış!");
            }
            catch (Exception)
            {

                return BadRequest("Lütfen eksik alanları doldurun!");
            }
            
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] User user)
        {
            try
            {
                _userService.AddWithHash(user);
                return Ok("Kayıt başarılı!");
            }
            catch (Exception e)
            {
              //  return BadRequest("Lütfen, eksik alanları doldurun!");
                return BadRequest(e.Message);
            }


        }

    }
}
