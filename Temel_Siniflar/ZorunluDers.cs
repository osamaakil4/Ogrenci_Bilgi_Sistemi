using System;

namespace Ogrenci_Bilgi_Sistemi
{
    public class ZorunluDers : Ders
    {
      

   

        public ZorunluDers(string kod, string ad, int kredi,  int akts, string donem)
            : base(kod, ad, kredi, akts, donem)
        {
        }

        public override string GetTuru()
        {
            return "Zorunlu";
        }

       
    }
}