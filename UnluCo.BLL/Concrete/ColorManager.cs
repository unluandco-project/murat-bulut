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
    public class ColorManager : IColorService
    {

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        private IColorDal _colorDal;

        [ValidationAspect(typeof(ColorValidator))]
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public Color Find(int id)
        {
            return _colorDal.Find(x => x.Id.Equals(id) && x.isActive.Equals(true));
        }

        public List<Color> GetList()
        {
            return _colorDal.GetList().Where(x => x.isActive.Equals(true)).ToList();
        }

        public void Remove(Color color)
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(ColorValidator))]
        public void Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
