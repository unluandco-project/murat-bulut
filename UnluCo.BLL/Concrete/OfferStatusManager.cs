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

namespace UnluCo.BLL.Concrete
{
    public class OfferStatusManager : IOfferStatusService
    {
        public OfferStatusManager(IOfferStatusDal offerStatusDal)
        {
            _offerStatusDal = offerStatusDal;
        }
        private IOfferStatusDal _offerStatusDal;

        [ValidationAspect(typeof(OfferStatusValidator))]
        public void Add(OfferStatus offerStatus)
        {
            _offerStatusDal.Add(offerStatus);
        }

        public OfferStatus Find(int id)
        {
            return _offerStatusDal.Find(x=>x.Id.Equals(id));
        }

        public List<OfferStatus> GetList()
        {
            return _offerStatusDal.GetList();
        }

        public void Remove(OfferStatus offerStatus)
        {
            _offerStatusDal.Remove(offerStatus);
        }

        [ValidationAspect(typeof(OfferStatusValidator))]
        public void Update(OfferStatus offerStatus)
        {
            _offerStatusDal.Update(offerStatus);
        }
    }
}
