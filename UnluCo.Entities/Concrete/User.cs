using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Entities.Concrete
{
    public class User : IEntity
    {
        public User()
        {
            Products = new List<Product>();
            Offers = new List<Offer>();
            isActive = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public bool isActive { get; set; }
        public Sale Sale { get; set; }
        public List<Product> Products { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
