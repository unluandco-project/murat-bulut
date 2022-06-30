using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.DAL.Abstract;
using UnluCo.Entities.Concrete;

namespace UnluCo.DAL.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, UnluCoContext>, ICategoryDal
    {

    }
}
