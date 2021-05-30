using FinalProject.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Entities
{
   public  class SellItem : BaseEntity
    {
        private static int count = 0;
        public Product Product { get; set; }
        public int Counts { get; set; }
        public SellItem(Product product)
        {
            Product = product;
            count++;
            Number = count;
        }


    }
}
