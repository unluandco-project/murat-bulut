using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Entities.Concrete
{
    public class Offer:IEntity
    {
        public Offer()
        {
            OfferStatusId = 1;
            SalesPermit = false;
            isPurchase = false;
            isActive = true;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int OfferStatusId { get; set; }
        public int OfferPercentage { get; set; }
        public bool SalesPermit { get; set; }
        public bool isPurchase { get; set; }
        public bool isActive { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public OfferStatus OfferStatus { get; set; }
    }
}
