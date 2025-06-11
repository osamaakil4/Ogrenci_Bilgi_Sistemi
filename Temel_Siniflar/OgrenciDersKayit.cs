using System;

namespace Ogrenci_Bilgi_Sistemi
{
    public class OgrenciDersKayit
    {
        public string OgrenciNo { get; set; }
        public string DersKodu { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Durum { get; set; } // "Aktif", "Bıraktı", "Tamamladı"

        // Constructor
        public OgrenciDersKayit(string ogrenciNo, string dersKodu)
        {
            OgrenciNo = ogrenciNo;
            DersKodu = dersKodu;
            KayitTarihi = DateTime.Now;
            Durum = "Aktif";
        }

        // Parameterli constructor
        public OgrenciDersKayit(string ogrenciNo, string dersKodu, DateTime kayitTarihi, string durum)
        {
            OgrenciNo = ogrenciNo;
            DersKodu = dersKodu;
            KayitTarihi = kayitTarihi;
            Durum = durum;
        }

        public string GetInfo()
        {
            return $"Öğrenci: {OgrenciNo} - Ders: {DersKodu} - Kayıt: {KayitTarihi.ToShortDateString()} - Durum: {Durum}";
        }

        public override string ToString()
        {
            return GetInfo();
        }

        // Equals ve GetHashCode override'ları
        public override bool Equals(object obj)
        {
            if (obj is OgrenciDersKayit other)
            {
                return OgrenciNo == other.OgrenciNo && DersKodu == other.DersKodu;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (OgrenciNo + DersKodu).GetHashCode();
        }
    }
}