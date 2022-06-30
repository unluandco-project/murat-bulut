using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Entities.Concrete
{
    public class Sale : IEntity
    {
        public Sale()
        {
            Products = new List<Product>();
            Users = new List<User>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }
    }
}
