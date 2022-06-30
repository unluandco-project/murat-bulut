using Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.DAL.Abstract;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.DTOs;

namespace UnluCo.DAL.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, UnluCoContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (UnluCoContext context = new UnluCoContext())
            {

                var result = (from p in context.Products
                              join u in context.Users
                              on p.UserId equals u.Id
                              join c in context.Categories
                              on p.CategoryId equals c.Id
                              select new ProductDetailDto
                              {
                                  Id = p.Id,
                                  UserID = u.Id,
                                  CategoryId=c.Id,
                                  UserName = u.Name + " " + u.Surname,
                                  CategoryName = c.Title,
                                  Name=p.Name,
                                  Description=p.Description,
                                  Color=p.Color,
                                  Brand=p.Brand,
                                  UsingStatus=p.UsingStatus,
                                  ImageUrl=p.ImageUrl,
                                  Price=p.Price,
                                  isOfferable=p.isOfferable,
                                  isSold=p.isSold,
                                  isActive=p.isActive
                              });
                return result.ToList();

            }
        }

        public void AddWithImage(Product product, string serverPath)
        {
            using (UnluCoContext context = new UnluCoContext())
            {
                product.ImageUrl = UploadImageTool.Upload(product.ImageFile,serverPath);
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateWithImage(Product product, string serverPath)
        {
            using (UnluCoContext context = new UnluCoContext())
            {
                product.ImageUrl = UploadImageTool.Upload(product.ImageFile, serverPath);
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void RemoveImage(int id)
        {
            using (UnluCoContext context = new UnluCoContext())
            {
                var _product = context.Products.Where(x => x.Id.Equals(id)).FirstOrDefault();
                _product.ImageUrl = null;
                var entity = context.Entry(_product);
                entity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }

        
    }
}
