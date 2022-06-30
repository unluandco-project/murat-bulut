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
    public class OffersController : ControllerBase
    {
        public OffersController(IOfferService offerService)
        {
            OfferTrigger.Load();
            _offerService = offerService;
        }
        private IOfferService _offerService;

        [Authorize]
        [HttpGet("get")]
        public IActionResult GetList()
        {
            var result = _offerService.GetOfferDetails();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get/{id}")]
        public IActionResult GetListById(int id)
        {

            var result = _offerService.GetOfferDetails().Where(x => x.Id.Equals(id));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("my/{id}")]
        public IActionResult GetMyOffersById(int id)
        {

            var result = _offerService.GetOfferDetails().Where(x => x.OwnerId.Equals(id)).ToList();
            if (result.Count == 0)
            {
                return Ok("Henüz teklif almadınız...");
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet("user/{id}")]
        public IActionResult GetListByUserId(int id)
        {

            var result = _offerService.GetOfferDetails().Where(x => x.UserId.Equals(id)).ToList();
            if (result.Count == 0)
            {
                return Ok("Henüz teklif yapmadınız...");
            }

            return Ok(result);
        }


        [Authorize]
        [HttpPost("new")]
        public IActionResult Add([FromForm] Offer offer)
        {
            try
            {
                _offerService.Add(offer);
                return Ok("Teklif verme başarılı...");
            }
            catch (Exception)
            {
                return BadRequest("Lütfen, eksik alanları doldurun!");
            }
        }

        [Authorize]
        [HttpPut("update")]
        public IActionResult Update([FromForm] Offer offer)
        {
            try
            {
                _offerService.Update(offer);
                return Ok("Teklif güncellendi...");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpDelete("retract/{id}")]
        public IActionResult RetractOffer(int id)
        {
            try
            {
                _offerService.RetractOffer(id);
                return Ok("Teklif geri alındı...");
            }
            catch (Exception)
            {
                return BadRequest("Lütfen, geri alınmasını istediğiniz teklifi belirtin!");
            }

        }
    }
}
