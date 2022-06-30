using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.DTOs;

namespace UnluCo.BLL.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        List<ProductDetailDto> GetProductDetails();
        Product Find(int id);
        void Add(Product product);
        void AddWithImage(Product product, string serverPath);
        void UpdateWithImage(Product product, string serverPath);
        void Update(Product product);
        void Remove(Product product);
        void RemoveImage(int id);
    }
}
