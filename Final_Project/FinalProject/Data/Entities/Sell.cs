using FinalProject.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Entities
{
   public class Sell:BaseEntity
    {
        private static int count = 0;
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public List<SellItem> SellItems { get; set; }
        

        public Sell()
        {
            Date = DateTime.Now;
            SellItems = new();
            count++;
            Number = count;
        }
    }
}
