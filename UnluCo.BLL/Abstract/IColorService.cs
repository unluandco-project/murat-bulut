using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.Abstract
{
    public interface IColorService
    {
        List<Color> GetList();
        Color Find(int id);
        void Add(Color color);
        void Update(Color color);
        void Remove(Color color);
    }
}
