using EntityFrameworkCore.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.DAL.Concrete;
using UnluCo.Entities.Concrete;

namespace UnluCo.DAL.Triggers
{
    public static class OfferTrigger
    {
        public static void Load()
        {
            Triggers<Offer, UnluCoContext>.Updating += e =>
            {
                var _offer = e.Context.Offers.Find(e.Entity.Id);
                _offer.SalesPermit = (_offer.OfferStatusId == 2) ? true : false;
                e.Context.Offers.Update(_offer);
            };
        }
    }
}
