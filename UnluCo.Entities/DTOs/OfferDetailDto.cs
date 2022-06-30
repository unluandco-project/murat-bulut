using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Entities.DTOs
{
    public class OfferDetailDto : IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OwnerId { get; set; }
        public int UserId { get; set; }
        public int OfferStatusId { get; set; }
        public string OwnerName { get; set; }
        public string UserName { get; set; }
        public string OfferStatusTitle { get; set; }
        public decimal BasePrice { get; set; }
        public decimal OfferedPrice { get; set; }
        public int OfferPercentage { get; set; }
        public bool SalesPermit { get; set; }
        public bool isPurchase { get; set; }
        public bool isActive { get; set; }
    }
}
