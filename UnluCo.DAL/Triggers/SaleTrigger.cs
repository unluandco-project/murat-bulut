using EntityFrameworkCore.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.DAL.Concrete;
using UnluCo.Entities.Concrete;

namespace UnluCo.DAL.Triggers
{
    public static class SaleTrigger
    {
        public static void Load()
        {
            Triggers<Sale, UnluCoContext>.Inserting += e =>
            {
                var _product = e.Context.Products.Find(e.Entity.ProductId);
                _product.isSold = true;
                e.Context.Products.Update(_product);
            };
        }
    }
}
