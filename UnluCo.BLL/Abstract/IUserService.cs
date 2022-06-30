using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.Models;

namespace UnluCo.BLL.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        User Find(int id);
        void Add(User user);
        void AddWithHash(User user);
        void Update(User user);
        void Remove(User user);
        object Login(LoginModel user);

    }
}
