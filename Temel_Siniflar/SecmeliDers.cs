using System;

namespace Ogrenci_Bilgi_Sistemi
{
    public class SecmeliDers : Ders
    {
        public SecmeliDers() : base()
        {
        }

        public SecmeliDers(string kod, string ad, int kredi, string v, int akts, string donem)
            : base(kod, ad, kredi, akts, donem)
        {
        }

        public SecmeliDers(string kod, string ad, int kredi, int akts, string donem) : base(kod, ad, kredi, akts, donem)
        {
        }

        public override string GetTuru()
        {
            return "Seçmeli";
        }

        public override string GetInfo()
        {
            return $"{kod} - {ad} ({kredi} kredi, {akts} AKTS) - Seçmeli Ders - {donem}";
        }
    }
}
