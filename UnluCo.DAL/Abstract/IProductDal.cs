using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.DTOs;

namespace UnluCo.DAL.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
        void AddWithImage(Product product, string serverPath);
        void UpdateWithImage(Product product, string serverPath);
        void RemoveImage(int id);
    }
}
