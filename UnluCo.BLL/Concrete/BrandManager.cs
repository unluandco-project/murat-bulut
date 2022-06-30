
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

namespace UnluCo.BLL.Concrete
{
    public class BrandManager : IBrandService
    {
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        private IBrandDal _brandDal;

        [ValidationAspect(typeof(BrandValidator))]
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public Brand Find(int id)
        {
            return _brandDal.Find(x => x.Id.Equals(id) && x.isActive.Equals(true));
        }

        public List<Brand> GetList()
        {
            return _brandDal.GetList().Where(x=>x.isActive.Equals(true)).ToList();
        }

        public void Remove(Brand brand)
        {
            _brandDal.Remove(brand);
        }
        [ValidationAspect(typeof(BrandValidator))]
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

    }
}
