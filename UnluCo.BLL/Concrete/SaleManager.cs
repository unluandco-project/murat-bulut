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
    public class SaleManager : ISaleService
    {
        public SaleManager(ISaleDal saleDal)
        {
            _saleDal=saleDal;
        }
        private ISaleDal _saleDal;

        [ValidationAspect(typeof(SaleValidator))]
        public void Add(Sale sale)
        {
            _saleDal.Add(sale);
        }

        public Sale Find(int id)
        {
            return _saleDal.Find(x => x.Id.Equals(id));
        }

        public List<Sale> GetList()
        {
            return _saleDal.GetList();
        }

        public void Remove(Sale sale)
        {
            _saleDal.Remove(sale);
        }

        [ValidationAspect(typeof(SaleValidator))]
        public void Update(Sale sale)
        {
            _saleDal.Update(sale);
        }
    }
}
