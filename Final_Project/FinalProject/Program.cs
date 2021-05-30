using FinalProject.Services;
using System;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            int a = 0;
            int b = 0;
            do
            {
                Console.WriteLine("============= IBRAAM MaRkET =============");

                Console.WriteLine("1.Mehsullar uzerinde emelliyat aparmaq");
                Console.WriteLine("2.Satislar uzerinde emelliyat aparmaq");
                Console.WriteLine("3.Sistemden cixmaq");
                Console.WriteLine("Hansi Proses ustunde emelliyat aparilsin?");
                Console.WriteLine("Reqem daxil edin");
                string selectionstr = Console.ReadLine();
                while (!int.TryParse(selectionstr, out selection))
                {
                    Console.WriteLine("Eded daxil edin");
                    selectionstr = Console.ReadLine();
                    
                }
                if (selection <= 0 || selection >= 4)
                {
                    throw new ArgumentOutOfRangeException("Bele emeliyatimiz teesufki yoxdur...");
                }

                switch (selection)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("1.Mehsul elave etmek");
                            Console.WriteLine("2.Mehsul uzerinde duzelis etmek");
                            Console.WriteLine("3.Mehsul sil");
                            Console.WriteLine("4.Butun Mehsullari gosterin");
                            Console.WriteLine("5.Kateqoriya gore mehsulu tapmaq");
                            Console.WriteLine("6.Qiymet araligina gore mehsul tapmaq");
                            Console.WriteLine("7.Mehsullar arasinda ada gore axdaris etmek");
                            Console.WriteLine("0.Sistemden cixis");
                            Console.WriteLine("Hansi emelliyat aparilmalidir?");
                            string str_a = Console.ReadLine();
                            while (!int.TryParse(str_a, out a ))
                            {
                                Console.WriteLine("Duzgun eded daxil edin");
                                str_a = Console.ReadLine();
                            }
                            if (a >= 8 || a<= -1)
                            {
                                throw new ArgumentOutOfRangeException("Bele emelliyatimiz yoxdu");
                            }
                            switch (a)
                            {
                                case 1:
                                    MenuService.LoadProductMenu();
                                    break;
                                case 2:
                                    MenuService.ChangeProductMenu();
                                    break;
                                case 3:
                                    MenuService.RemoveProductMenu();
                                    break;
                                case 4:
                                    MenuService.ShowProductsMenu();
                                    break;
                                case 5:
                                    MenuService.ShowCategoryMenu();
                                    break;
                                case 6:
                                    MenuService.ShowByProductPriceMenu();
                                    break;
                                case 7:
                                    MenuService.ShowProductByNameMenu();
                                    break;

                                default:
                                    break;
                            }
                            
                        } while (a != 0);
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine("1.Yeni satis elave etmek");
                            Console.WriteLine("2.Satisdaki mehsulun geri qaytarilmasi");
                            Console.WriteLine("3.Satisin silinmesi");
                            Console.WriteLine("4.Butun satislarin ekrana cixarilmasi");
                            Console.WriteLine("5.Verilen tarix araligina gore satislarin gosterilmesi");
                            Console.WriteLine("6.Verilen mebleg araligina gore satislarin gosterilmesi");
                            Console.WriteLine("7.Verilmis bir tarixde olan satislarin gosterilmesi");
                            Console.WriteLine("8.Verilmis nomreye esasen hemin nomreli satisin melumatlarin gosterilmesi");
                            Console.WriteLine("0.Sistemden cixis");
                            string str_b = Console.ReadLine();
                            while (!int.TryParse(str_b, out b))
                            {
                                Console.WriteLine("Duzgun eded daxil edin");
                                str_b = Console.ReadLine();
                            }
                            if (b > 8 || b <= -1)
                            {
                                throw new ArgumentOutOfRangeException("bele emelliyat yoxdur...");
                            }
                            switch (b)
                            {
                                case 1:
                                    MenuService.AddSellMenu();
                                    break;
                                case 2:
                                    MenuService.ReturnProductMenu();
                                    break;
                                case 3:
                                    MenuService.DeleteSellMenu();
                                    break;
                                case 4:
                                    MenuService.ShowSellsMenu();
                                    break;
                                case 5:
                                    MenuService.ShowSellByDateMenu();
                                    break;
                                case 6:
                                    MenuService.ShowSellByCostMenu();
                                    break;
                                case 7:
                                    MenuService.ShowSellByOneDateMenu();
                                    break;
                                case 8:
                                    MenuService.ShowSellByNoMenu();
                                    break;
                                default:
                                    break;
                            }


                        } while (b !=0);
                        break;
                    default:
                        break;
                }


            } while (selection != 3);

            
           
        }
    }
}

