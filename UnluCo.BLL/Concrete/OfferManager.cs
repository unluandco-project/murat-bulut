using Core.Aspects.Autofac.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.BLL.Abstract;
using UnluCo.BLL.ValidationRules.FluentValidation;
using UnluCo.DAL.Abstract;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.DTOs;

namespace UnluCo.BLL.Concrete
{
    public class OfferManager : IOfferService
    {
        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }
        private IOfferDal _offerDal;

        [ValidationAspect(typeof(OfferValidator))]
        public void Add(Offer offer)
        {
            _offerDal.Add(offer);
        }

        public Offer Find(int id)
        {
            return _offerDal.Find(x => x.Id.Equals(id) && x.isActive.Equals(true) && x.isActive.Equals(true));
        }

        public List<Offer> GetList()
        {
            return _offerDal.GetList().Where(x => x.isActive.Equals(true) && x.isActive.Equals(true)).ToList();
        }

        public List<OfferDetailDto> GetOfferDetails()
        {
            return _offerDal.GetOfferDetails().Where(x => x.isActive.Equals(true) && x.isActive.Equals(true)).ToList();
        }

        public void Remove(Offer offer)
        {
            _offerDal.Remove(offer);
        }

        [ValidationAspect(typeof(OfferValidator))]
        public void Update(Offer offer)
        {
            _offerDal.Update(offer);
        }

        public void RetractOffer(int id)
        {
            _offerDal.RetractOffer(id);
        }
    }
}
