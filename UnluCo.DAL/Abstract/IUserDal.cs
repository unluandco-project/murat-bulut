using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.Models;

namespace UnluCo.DAL.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        void AddWithHash(User user);
        object Login(LoginModel user);
    }
}
