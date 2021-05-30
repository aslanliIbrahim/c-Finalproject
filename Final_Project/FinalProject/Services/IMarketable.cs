using FinalProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{// Imarketablein olma meqsedi bizim metodlarimizi yaratmaqdir, diger classlarda bu metodlarin icini doldururug.
   public interface  IMarketable
    {

       

        #region MEHSUL
        public static void LoadProduct(string ad, double qiymet, int kod, string kateqoriya, int say)
        {
            

        }
        public static void ChangeProduct(string ad, double qiymet, int kod, string kateqoriya, int say)
        {
           

        }
        public static void RemoveProduct(int kod)
        {
            
        }
         
       
        public static void ShowProductByPrice(double ilkqiymet, double sonqiymet)
        {
           
        }
        public static void ShowProductByCategory( string kateqoriya)
        {
           

        }
        public static void ShowProductByName(string ad)
        {
            

        }
        #endregion

        #region SATIS
        public void AddSell(string ad, int say, double mebleg)
        {

        }

        public void ReturnProduct(string ad, int say)
        {
            
        }

        public void ShowSells()
        {
           

        }

        public void ShowSellByDate(DateTime baslamavaxti, DateTime bitmevaxti)
        {
            
        }

        public void ShowSellByCost(double baslaqiymet, double sonqiymet)
        {
           
        }

        public void ShowSellByNo(int nomre)
        {
            
        }

        public void ShowSellByOneDate(DateTime tarix)
        {

        }
        #endregion


    }
}   
