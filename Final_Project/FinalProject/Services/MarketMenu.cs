using FinalProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public  class MarketMenu : IMarketable
    {
        static MarketMenu market = new();


       public List<Product> Products { get; set; }
       public List<Sell> Sales { get; set; }
        public MarketMenu()
        {
            Products = new();
            Sales = new();
        }

        #region MEHSUL
        // mehsulun elave olunmasi
        public void LoadProduct(string ad, double qiymet,  string kateqoriya, int say)
        {
            Product mehsul = new();
            mehsul.Name = ad;
            mehsul.Price = qiymet;          
            mehsul.Category = kateqoriya;
            mehsul.Count = say;
            Products.Add(mehsul);

        }

        //mehsulun deyisdirilmesi
        public void ChangeProduct(int kod, string ad, double qiymet,  string kateqoriya,  int say)
        {
            var Index = Products.Find(m => m.Code == kod);
            
            Product mehsul = new();
            Products.Remove(Index);
            mehsul.Name = ad;
            mehsul.Price = qiymet;
            
            mehsul.Category = kateqoriya;
            mehsul.Count = say;
            Products.Add(mehsul);

        }

        //mehsulun geri qaytarilmasi
        public void RemoveProduct(string ad)
        {
            var Index = Products.FindIndex(m => m.Name == ad);
            Products.RemoveAt(Index);
        }
        
        //qiymet araligina gore mehsulun qaytarilmasi
        public List<Product> ShowByProductPrice(double ilkqiymet, double sonqiymet)
        {
            var Index = Products.FindAll(m => m.Price >= ilkqiymet && m.Price <= sonqiymet);

            return Index;
        }

        //kateqoriyaya gore mehsulun gosterilmesi
        public List<Product> ShowProductByCategory(string kateqoriya)
        {
            var index = Products.FindAll(m => m.Category == kateqoriya);

            return index.ToList();

        }

        //ada gore mehsulun gosterilmesi
        public List<Product> ShowProductByName(string ad)
        {
            var index = Products.FindAll(m => m.Name == ad);
            return index;

        }
        #endregion

        
        #region SATIS
        //yeni satis elave olunmasi
        public void AddSell( int kod, int say)
        {
             
            int option = 0;
            Sell satis = new();
            Product mehsul = Products.FirstOrDefault(s => s.Code == kod);
            SellItem satisItem = new(mehsul);
            mehsul.Count = mehsul.Count - say;
            satis.Cost += mehsul.Price * say;
            satisItem.Counts += say;
            satis.SellItems.Add(satisItem);



            do
            {
                Console.WriteLine("Basqa bir sey arzuluyursuz?");
                Console.WriteLine("1.He");
                Console.WriteLine("2.Yox");
                Console.WriteLine("Secim daxil edin");
                string optionstr = Console.ReadLine();
                while (!int.TryParse(optionstr, out option))
                {
                    Console.WriteLine("Reqem daxil edin");
                    optionstr = Console.ReadLine();
                }
                switch (option)
                {
                    case 1:
                        kod = int.Parse(Console.ReadLine());
                        say = int.Parse(Console.ReadLine());
                        mehsul = Products.FirstOrDefault(s => s.Code ==kod);
                        satisItem = new(mehsul);
                        mehsul.Count = mehsul.Count - say;
                        satis.Cost += mehsul.Price * say;
                        satis.SellItems.Add(satisItem);
                        break;
                    case 2:
                        Console.WriteLine("satis elave olundu");
                        Sales.Add(satis);
                        break;
                }
            } while (option != 2);
        }

        //mehsulun satisdan geri qaytarilmasi
        public void ReturnProduct(int nomre ,string ad, int say)
        {
            Product mehsul = Products.FirstOrDefault(m => m.Name == ad);
            Sell satis = Sales.FirstOrDefault(m => m.Number == nomre);
            SellItem satisitem = satis.SellItems.FirstOrDefault(m => m.Counts >= say);
            Sales.Remove(satis);
            satis.SellItems.Remove(satisitem);
            mehsul.Count = mehsul.Count + say;
            satis.Cost -= mehsul.Price * say;
            satisitem.Counts -= say;
        }

        //butun satislari goster methodu
        public List<Sell> ShowSells()
        {
            
            return Sales;

        }

        //tarix araligina gore satisin qaytarilmasi
        public List<Sell> ShowSellByDate(DateTime baslamavaxti, DateTime bitmevaxti)
        {
            var zaman = Sales.Where(m => m.Date >= baslamavaxti && m.Date <= bitmevaxti);
            return zaman.ToList();
        }

        //qiymet araligina gore satisin qaytarilmasi methodu
        public List<Sell> ShowSellByCost(double baslaqiymet, double sonqiymet)
        {
            var index = Sales.FindAll(m => m.Cost >= baslaqiymet && m.Cost <= sonqiymet);
            return index;
        }

        //tarixe gore satisin qaytarilmasi
        public List<Sell> ShowSellByOneDate(DateTime tarix)
        {
            var index = Sales.Where(m => m.Date.Month == tarix.Month && m.Date.Day == tarix.Day  && m.Date.Year == tarix.Year);
            return index.ToList();


        }

        //necenci satis oldugunu gosteren method
        public List<Sell> ShowSellByNo(int nomre)
        {
            var index = Sales.FindAll(m => m.Number == nomre);
            return index;
        }

        //satisin silinmesi
        public void DeleteSell(int nomre)
        {
            Sell satis = new();
            int index = Sales.FindIndex(m => m.Number == nomre);
            Sales.RemoveAt(index);

        }
        #endregion

    }
}
