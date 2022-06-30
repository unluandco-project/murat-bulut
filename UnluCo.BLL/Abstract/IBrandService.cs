using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetList();
        Brand Find(int id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Remove(Brand brand);
    }
}
