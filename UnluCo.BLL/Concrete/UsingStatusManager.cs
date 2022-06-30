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
    public class UsingStatusManager : IUsingStatusService
    {
        public UsingStatusManager(IUsingStatusDal usingStatusDal)
        {
            _usingStatusDal = usingStatusDal;
        }
        private IUsingStatusDal _usingStatusDal;

        [ValidationAspect(typeof(UsingStatusValidator))]
        public void Add(UsingStatus usingStatus)
        {
            _usingStatusDal.Add(usingStatus);
        }

        public UsingStatus Find(int id)
        {
            return _usingStatusDal.Find(x => x.Id.Equals(id) && x.isActive.Equals(true));
        }

        public List<UsingStatus> GetList()
        {
            return _usingStatusDal.GetList().Where(x => x.isActive.Equals(true)).ToList();
        }

        public void Remove(UsingStatus usingStatus)
        {
            _usingStatusDal.Remove(usingStatus);
        }

        [ValidationAspect(typeof(UsingStatusValidator))]
        public void Update(UsingStatus usingStatus)
        {
            _usingStatusDal.Update(usingStatus);
        }
    }
}
