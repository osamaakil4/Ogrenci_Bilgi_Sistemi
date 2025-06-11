using System;

namespace Ogrenci_Bilgi_Sistemi
{
    public class ZorunluDers : Ders
    {
        private object akts1;

        public ZorunluDers() : base()
        {
        }

        public ZorunluDers(string kod, string ad, int kredi, string v, int akts, string donem)
            : base(kod, ad, kredi, akts, donem)
        {
        }

        public ZorunluDers(string kod, string ad, int kredi, object akts1, string donem)
        {
            this.kod = kod;
            this.ad = ad;
            this.kredi = kredi;
            this.akts1 = akts1;
            this.donem = donem;
        }

        public override string GetTuru()
        {
            return "Zorunlu";
        }

        public override string GetInfo()
        {
            return $"{kod} - {ad} ({kredi} kredi, {akts} AKTS) - Zorunlu Ders - {donem}";
        }
    }
}