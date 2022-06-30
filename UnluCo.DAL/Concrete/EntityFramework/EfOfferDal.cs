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
    public class EfOfferDal : EfEntityRepositoryBase<Offer, UnluCoContext>, IOfferDal
    {
        public List<OfferDetailDto> GetOfferDetails()
        {
            using (UnluCoContext context = new UnluCoContext())
            {

                var result = (from o in context.Offers
                              join u in context.Users
                              on o.UserId equals u.Id
                              join p in context.Products
                              on o.ProductId equals p.Id
                              join ostatus in context.OfferStatuses
                              on o.OfferStatusId equals ostatus.Id
                              select new OfferDetailDto
                              {
                                  Id = o.Id,
                                  ProductId = p.Id,
                                  OwnerId = p.UserId,
                                  UserId = u.Id,
                                  OfferStatusId = ostatus.Id,
                                  OwnerName = p.User.Name + " " + p.User.Surname,
                                  UserName = u.Name + " " + u.Surname,
                                  OfferStatusTitle = ostatus.Title,
                                  BasePrice = p.Price,
                                  OfferedPrice = (p.Price + (p.Price * o.OfferPercentage) / 100),
                                  OfferPercentage = o.OfferPercentage,
                                  SalesPermit = o.SalesPermit,
                                  isPurchase = o.isPurchase,
                                  isActive = o.isActive
                              });
                return result.ToList();

            }

        }

        public void RetractOffer(int id)
        {
            using (UnluCoContext context = new UnluCoContext())
            {
                var _offer = context.Offers.Find(id);
                if (_offer.isActive)
                    _offer.isActive = false;
                else
                    _offer.isActive = true;

                var entity = context.Entry(_offer);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
