using Core.Aspects.Autofac.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.BLL.Abstract;
using UnluCo.BLL.ValidationRules.FluentValidation;
using UnluCo.DAL.Abstract;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.DTOs;

namespace UnluCo.BLL.Concrete
{
    public class ProductManager : IProductService
    {

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        private IProductDal _productDal;

        [ValidationAspect(typeof(ProductValidator))]
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public void AddWithImage(Product product, string serverPath)
        {
            _productDal.AddWithImage(product, serverPath);
        }

        public Product Find(int id)
        {
            return _productDal.Find(x => x.Id.Equals(id) && x.isActive.Equals(true) && x.isSold.Equals(false));
        }

        public List<Product> GetList()
        {
            return _productDal.GetList().Where(x => x.isActive.Equals(true) && x.isSold.Equals(false)).OrderByDescending(x => x.Id).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails().Where(x => x.isActive.Equals(true) && x.isSold.Equals(false)).OrderByDescending(x => x.Id).ToList();
        }

        public void Remove(Product product)
        {
            _productDal.Remove(product);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public void UpdateWithImage(Product product, string serverPath)
        {
            _productDal.UpdateWithImage(product, serverPath);
        }

        public void RemoveImage(int id)
        {
            _productDal.RemoveImage(id);
        }
    }
}
