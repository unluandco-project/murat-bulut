using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.DTOs;

namespace UnluCo.BLL.Abstract
{
    public interface IOfferService
    {
        List<Offer> GetList();
        List<OfferDetailDto> GetOfferDetails();
        Offer Find(int id);
        void Add(Offer offer);
        void Update(Offer offer);
        void Remove(Offer offer);
        void RetractOffer(int id);

    }
}
