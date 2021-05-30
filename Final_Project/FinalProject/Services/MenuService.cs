using ConsoleTables;
using System;

namespace FinalProject.Services
{
    public class MenuService
    {

        static MarketMenu market = new();
        #region Mehsul
        //mehsullari gostermek...
        public static void ShowProductsMenu()
        {
           
            var table = new ConsoleTable("ad", "kod","qiymet", "kateqoriya", "say");
            
            foreach (var mehsul in market.Products)
            {
                table.AddRow(mehsul.Name, mehsul.Code, mehsul.Price, mehsul.Category, mehsul.Count);
            }
            table.Write();
            Console.WriteLine();
        }
        //katiqoriyasina gore gosteren menyu
        public static void ShowCategoryMenu()
        {
            Console.WriteLine("Kateqoriya daxil edin");
            var input = Console.ReadLine();
            var table = new ConsoleTable("Ad","Kateqoriya", "Qiymet", "Say");
            foreach (var mehsul in market.ShowProductByCategory(input))
            {
                table.AddRow(mehsul.Name, mehsul.Category, mehsul.Price, mehsul.Count);
            }
            table.Write();
            Console.WriteLine(); 
        }
        //qiymet araligina gore gosteren menyu
        public static void ShowByProductPriceMenu()
        {
           
            var table = new ConsoleTable("Ad", "Qiymet", "Say");
            Console.WriteLine("Min qiymet daxil edin");
            double BaslangicQiymet = double.Parse(Console.ReadLine());
            Console.WriteLine("Max qiymet daxil edin");
            double SonQiymet = double.Parse(Console.ReadLine());
            foreach (var item in market.ShowByProductPrice(BaslangicQiymet,SonQiymet))
            {
                table.AddRow(item.Name, item.Price, item.Count);
            }
            if (BaslangicQiymet == 0 || SonQiymet == 0)
            {
                throw new ArgumentException("duzgun qiymet daxil edin");
            }
           
                
            table.Write();
            Console.WriteLine();


        }
        //ada gore mehsulun qaytarilmasi
        public static void ShowProductByNameMenu()
        {
            var table = new ConsoleTable("Ad","Kod");
            string Ad = Console.ReadLine();
            foreach (var item in market.ShowProductByName(Ad))
            {
                table.AddRow(item.Name, item.Code);
            }
            
            table.Write();
            Console.WriteLine();
        }
        #endregion

        #region Satis
        //satislari gosteren menyu
        public static void ShowSellsMenu()
        {
            var table = new ConsoleTable("Nomre", "Mebleg", "Mehsul sayi", "Vaxt");
            foreach (var item in market.ShowSells())
            {
                table.AddRow(item.Number, item.Cost, item.SellItems.Count ,item.Date);
            }
            table.Write();
            Console.WriteLine();
        }

        //vaxt araligina gore gosteren menyu
        public static void ShowSellByDateMenu()
        {
            
            Console.WriteLine("Birinci tarixi elave edin(mm.dd.yyyy)");
            string str1 = Console.ReadLine();
            if (str1 == null)
            {
                throw new NullReferenceException("baslangic tarixin daxil EDIN!!!");
            }
            Console.WriteLine("Ikinci tarixi elave edin(mm.dd.yyyy)");
            string str2 = Console.ReadLine();
            if (str2 == null)
            {
                throw new NullReferenceException("Son tarixi daxil edin!!!");
            }
            DateTime BaslamaVaxti = DateTime.Parse(str1);
            DateTime BitmeVaxti = DateTime.Parse(str2);
            var table = new ConsoleTable( "Nomresi", "Mebleg", "Zaman");
            foreach (var item in market.ShowSellByDate(BaslamaVaxti, BitmeVaxti))
            {
                table.AddRow(item.Number,item.Cost, item.Date);
            }
           
            table.Write();
            Console.WriteLine();

        }

        //qiymet araligina gore mehsulun tapilmasi
        public static void ShowSellByCostMenu()
        {
            var table = new ConsoleTable("Qiymet");
            Console.WriteLine("Baslangic  qiymeti daxil edin");
            double baslaqiymet = double.Parse(Console.ReadLine());
            if (baslaqiymet <= -1)
            {
                throw new NullReferenceException("Baslangic qiymeti daxil edin");
            }
            Console.WriteLine("Son qiymeti daxil edin");
            double sonqiymet = double.Parse(Console.ReadLine());
            if (sonqiymet <= -1)
            {
                throw new NullReferenceException("sonqiymet qiymeti daxil edin");
            }
            foreach (var item in market.ShowSellByCost(baslaqiymet, sonqiymet))
            {
                table.AddRow(item.Cost);
            }
            table.Write();
            Console.WriteLine();
        }
        #endregion

        #region 
        //mehsulun elave olunmasi methodu
        public static void LoadProductMenu()
        {
            Console.WriteLine("Ad daxil edin");
            string ad = Console.ReadLine();
            if (string.IsNullOrEmpty(ad))
                //niyaziye goster
            {
                throw new ArgumentNullException("ad mutelq daxil edilmelidir!!!!");
            }
            Console.WriteLine("Qiymet daxil edin");
            double qiymet = double.Parse(Console.ReadLine());
            if (qiymet <= 0 )
            {   
                throw new ArgumentOutOfRangeException("mehsulun qiymeti menfi olmaz");
            }
            Console.WriteLine("Kateqoriyasini daxil edin");
            string kateqoriya = Console.ReadLine();
            Console.WriteLine("Say daxil edin");
            int say =int.Parse(Console.ReadLine());
            if (say <=-1)
            {
                throw new ArgumentOutOfRangeException("menfi ");
            }
            market.LoadProduct(ad,qiymet,kateqoriya,say);
        }

        // mehsulun menyusunun deyisdirilmesi methodu
        public static void ChangeProductMenu()
        {
            Console.WriteLine("Kod daxil edin");
            int kod = int.Parse(Console.ReadLine());
            Console.WriteLine("Ad daxil edin");
            string ad = Console.ReadLine();
            Console.WriteLine("Qiymet daxil edin");
            double qiymet = double.Parse(Console.ReadLine());
            if (qiymet <= 0)
            {
                throw new ArgumentOutOfRangeException("qiymet menfi ola bilmez");
            }
            Console.WriteLine("Kateqoriya daxil edin");
            string kateqoriya = Console.ReadLine();
            Console.WriteLine("Say daxil edin");
            int say = int.Parse(Console.ReadLine());
            if (say <= 0)
            {
                throw new ArgumentOutOfRangeException("sayi duzgun daxil edin");
            }
            market.ChangeProduct(kod, ad, qiymet,  kateqoriya, say);
        }

        //mehsulun geri qaytarilmasi
        public static void RemoveProductMenu()
        {
            Console.WriteLine("Ad daxil edin");
            string Ad = Console.ReadLine();          
            market.RemoveProduct(Ad);
        }
        #endregion

        #region
        // satis elave olnmasi methodu
        public static void AddSellMenu()
        {
            Console.WriteLine("Kod elave edin");
            int kod = int.Parse(Console.ReadLine());
            if (kod <0)
            {
                throw new ArgumentOutOfRangeException("kodu duzgun daxil ediniz(4.cu funksiyani islederek kodunuzu tapa bilersiniz)");
            }
            Console.WriteLine("Say elave edin");
            int say = int.Parse(Console.ReadLine());
            market.AddSell(kod, say );
        }

        //mehsulun silinmesi methodu
        public static void ReturnProductMenu()
        {
            Console.WriteLine("Necenci satisdan qayidacaq mehsulun nomresini daxil edin");
            int nomre = int.Parse(Console.ReadLine());
            if (nomre < 0)
            {
                throw new ArgumentOutOfRangeException("duzgun eded daxil ediniz");
            }
            Console.WriteLine("Ad daxil edin");
            string ad = Console.ReadLine();
            if (ad == null)
            {
                throw new NullReferenceException("adi mutleq daxil edin!!!");
            }
            Console.WriteLine("Say daxil edin");
            int say = int.Parse(Console.ReadLine());
            if (say <= -1 )
            {
                throw new NullReferenceException("say null ola bilmez");
            }
            market.ReturnProduct(nomre,ad, say);
            Console.WriteLine("Mehsul silindi...");
        }

        
        //tarixe gore satisin qaytarilmasi
        public static void ShowSellByOneDateMenu()
        {
            
            Console.WriteLine("Tarixi daxil edin(dd.mm.yyyy)");
            string str1 = Console.ReadLine();
            DateTime bitmevaxti = DateTime.Parse(str1);
            var table = new ConsoleTable("Nomresi","Mebleg", "Tarix");
            foreach (var item in market.ShowSellByOneDate(bitmevaxti))
            {
                
                table.AddRow(item.Number,item.Cost,item.Date);
            }
            table.Write();
            Console.WriteLine();
        }
        
        //necenci satisda hansi mehsulun satilmasinin ekrana cixardilmasi methodu
        public static void ShowSellByNoMenu()
        {
            Console.WriteLine("Satisin nomresini daxil edin");
            int nomre = int.Parse(Console.ReadLine());
            var table = new ConsoleTable("Nomre", "Mebleg","Tarix");
            foreach (var item in market.ShowSellByNo(nomre))
            {
                table.AddRow(item.Number, item.Cost, item.Date);
            }
            table.Write();
            Console.WriteLine();
        }

        //olan satisin silinmesi methodu
        public static void DeleteSellMenu()
        {
            Console.WriteLine("Nomre daxil edin");
            int nomre = int.Parse(Console.ReadLine());
            if (nomre <= 0 )
            {
                throw new ArgumentException("duzgun daxil edin");
            }
            market.DeleteSell(nomre);
            Console.WriteLine("Satis silindi");
        }
        #endregion
    }

}
