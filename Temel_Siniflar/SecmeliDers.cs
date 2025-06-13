using System;

namespace Ogrenci_Bilgi_Sistemi
{
    public class SecmeliDers : Ders
    {
  
        public SecmeliDers(string kod, string ad, int kredi,  int akts, string donem)
            : base(kod, ad, kredi, akts, donem)
        {
        }


        public override string GetTuru()
        {
            return "Seçmeli";
        }

       
    }
}
