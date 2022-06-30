using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Entities.Concrete
{
    public class OfferStatus:IEntity
    {
        public OfferStatus()
        {
            Offers = new List<Offer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
