using System;
using System.Collections.Generic;
using System.Linq;

namespace Ogrenci_Bilgi_Sistemi
{
    public class DersKayitYonetici
    {
        private List<OgrenciDersKayit> dersKayitlari;
        private OgrenciYonetici ogrenciYonetici;
        private DersYonetici dersYonetici;

      
        public DersKayitYonetici(OgrenciYonetici ogrenciYonetici, DersYonetici dersYonetici)
        {
            this.ogrenciYonetici = ogrenciYonetici;
            this.dersYonetici = dersYonetici;
            dersKayitlari = new List<OgrenciDersKayit>();
        }


        // Ders kaydı ekleme
        public bool DersKaydiEkle(string ogrenciNo, string dersKodu)
        {
            if (!ogrenciYonetici.OgrenciVarMi(ogrenciNo))
            {
                Console.WriteLine($"Öğrenci bulunamadı: {ogrenciNo}");
                return false;
            }

            if (OgrenciDerseKayitliMi(ogrenciNo, dersKodu))
            {
                Console.WriteLine($"Öğrenci {ogrenciNo} zaten {dersKodu} dersine kayıtlı!");
                return false;
            }
            OgrenciDersKayit yeniKayit = new OgrenciDersKayit(ogrenciNo, dersKodu);
            dersKayitlari.Add(yeniKayit);

            Console.WriteLine($"Ders kaydı başarıyla eklendi: {yeniKayit.GetInfo()}");
            return true;
        }

        // Ders kaydi iptal 
        public bool DersKaydiIptal(string ogrenciNo, string dersKodu)
        {
            var kayit = dersKayitlari.FirstOrDefault(k =>
                k.OgrenciNo == ogrenciNo && k.DersKodu == dersKodu && k.Durum == "Aktif");

            if (kayit == null)
            {
                Console.WriteLine($"Aktif ders kaydı bulunamadı: Öğrenci {ogrenciNo} - Ders {dersKodu}");
                return false;
            }

            kayit.Durum = "Bıraktı";
            Console.WriteLine($"Ders kaydı iptal edildi: {kayit.GetInfo()}");
            return true;
        }


        // Öğrenci derse kayitli mi
        public bool OgrenciDerseKayitliMi(string ogrenciNo, string dersKodu)
        {
            return dersKayitlari.Any(k =>
                k.OgrenciNo == ogrenciNo && k.DersKodu == dersKodu && k.Durum == "Aktif");
        }


        // Öğrencinin kayıtlı olduğu dersleri getir
        public List<OgrenciDersKayit> OgrencininDersleri(string ogrenciNo)
        {
            return dersKayitlari
                .Where(k => k.OgrenciNo == ogrenciNo && k.Durum == "Aktif")
                .ToList();
        }


        // Öğrencinin kayıtlı olduğu ders sayısı
        public int OgrencininDersSayisi(string ogrenciNo)
        {
            return OgrencininDersleri(ogrenciNo).Count;
        }



        // Öğrencinin toplam kredi 
        public int OgrencininToplamKredisi(string ogrenciNo)
        {
            var ogrencininDersleri = OgrencininDersleri(ogrenciNo);
            int toplamKredi = 0;

            foreach (var kayit in ogrencininDersleri)
            {
                var ders = dersYonetici.DersGetir(kayit.DersKodu);
                if (ders != null)
                {
                    toplamKredi += ders.Kredi;
                }
            }

            return toplamKredi;
        }

        public List<OgrenciDersKayit> TumDersKayitlari()
        {
            return dersKayitlari.ToList();
        }

    }
}