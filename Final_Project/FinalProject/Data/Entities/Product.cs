using FinalProject.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Entities
{
    enum Katiqoriya
    {
        Kolbasa,
        Et_memulatlari,
        Sud_mehsullari,
        Terevez,
        Qelyanalti,
        Souslar
    }
    public class Product: BaseEntity
    {
     private static int count =1111;
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

       public Product()
        {
            count++;
            Code = count;
        }

    }
}
