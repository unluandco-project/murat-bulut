using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int CategoryId { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string UsingStatus { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool isOfferable { get; set; }
        public bool isSold { get; set; }
        public bool isActive { get; set; }
    }
}
