using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Entities.Concrete
{
    public class Product : IEntity
    {
        public Product()
        {
            Offers = new List<Offer>();
            isOfferable = false;
            isSold = false;
            isActive = true;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string UsingStatus { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool isOfferable { get; set; }
        public bool isSold { get; set; }
        public bool isActive { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public Sale Sale { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
