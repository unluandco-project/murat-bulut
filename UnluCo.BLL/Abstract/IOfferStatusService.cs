using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.Abstract
{
    public interface IOfferStatusService
    {
        List<OfferStatus> GetList();
        OfferStatus Find(int id);
        void Add(OfferStatus offerStatus);
        void Update(OfferStatus offerStatus);
        void Remove(OfferStatus offerStatus);
    }
}
