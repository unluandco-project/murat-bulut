using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.DTOs;

namespace UnluCo.DAL.Abstract
{
    public interface IOfferDal : IRepository<Offer>
    {
        List<OfferDetailDto> GetOfferDetails();
        void RetractOffer(int id);
    }
}
