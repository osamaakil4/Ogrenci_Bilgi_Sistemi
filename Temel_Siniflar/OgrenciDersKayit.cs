using System;

namespace Ogrenci_Bilgi_Sistemi
{
    public class OgrenciDersKayit
    {
        public string OgrenciNo { get; set; }
        public string DersKodu { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Durum { get; set; } // "Aktif", "Bıraktı", "Tamamladı"


        public OgrenciDersKayit(string ogrenciNo, string dersKodu)
        {
            OgrenciNo = ogrenciNo;
            DersKodu = dersKodu;
            KayitTarihi = DateTime.Now;
            Durum = "Aktif";
        }

        public string GetInfo()
        {
            return $"Öğrenci: {OgrenciNo} - Ders: {DersKodu} - Kayıt: {KayitTarihi.ToShortDateString()} - Durum: {Durum}";
        }

      

       
     

       
    }
}