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
    public class OfferStatusesController : ControllerBase
    {
        public OfferStatusesController(IOfferStatusService offerStatusService)
        {
            _offerStatusService = offerStatusService;
        }
        private IOfferStatusService _offerStatusService;

        [Authorize]
        [HttpGet("get")]
        public IActionResult GetList()
        {

            var result = _offerStatusService.GetList();
            return Ok(result);
        }
    }
}
