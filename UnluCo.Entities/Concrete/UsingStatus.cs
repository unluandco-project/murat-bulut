using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Entities.Concrete
{
    public class UsingStatus : IEntity
    {
        public UsingStatus()
        {
            isActive = true;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool isActive { get; set; }
    }
}
