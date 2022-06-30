using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.Abstract
{
    public interface ISaleService
    {
        List<Sale> GetList();
        Sale Find(int id);
        void Add(Sale sale);
        void Update(Sale sale);
        void Remove(Sale sale);
    }
}
