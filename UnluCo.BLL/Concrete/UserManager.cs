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
using UnluCo.Entities.Models;

namespace UnluCo.BLL.Concrete
{
    public class UserManager : IUserService
    {
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        private IUserDal _userDal;

        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        [ValidationAspect(typeof(UserValidator))]
        public void AddWithHash(User user)
        {
            _userDal.AddWithHash(user);
        }

        public User Find(int id)
        {
            return _userDal.Find(x => x.Id.Equals(id) && x.isActive.Equals(true));
        }

        public List<User> GetList()
        {
            return _userDal.GetList().Where(x => x.isActive.Equals(true)).ToList();
        }

        public void Remove(User user)
        {
            _userDal.Remove(user);
        }

        [ValidationAspect(typeof(UserValidator))]
        public void Update(User user)
        {
            _userDal.Update(user);
        }
        [ValidationAspect(typeof(LoginModelValidator))]
        public object Login(LoginModel user)
        {
            return _userDal.Login(user);
        }
    }
}
