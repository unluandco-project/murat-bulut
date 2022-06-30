using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.Abstract
{
    public interface IUsingStatusService
    {
        List<UsingStatus> GetList();
        UsingStatus Find(int id);
        void Add(UsingStatus usingStatus);
        void Update(UsingStatus usingStatus);
        void Remove(UsingStatus usingStatus);
    }
}
