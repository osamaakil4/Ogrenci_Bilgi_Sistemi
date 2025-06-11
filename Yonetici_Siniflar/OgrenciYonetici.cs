using System;
using System.Collections.Generic;
using System.Linq;

namespace Ogrenci_Bilgi_Sistemi
{
    public class OgrenciYonetici
    {
        private Dictionary<string, Ogrenci> ogrenciler;

        // Constructor
        public OgrenciYonetici()
        {
            ogrenciler = new Dictionary<string, Ogrenci>();
        }

        // Öğrenci ekleme
        public bool OgrenciEkle(Ogrenci ogrenci)
        {
            if (ogrenci == null || string.IsNullOrEmpty(ogrenci.OgrenciNo))
            {
                return false;
            }

            if (ogrenciler.ContainsKey(ogrenci.OgrenciNo))
            {
                Console.WriteLine($"Bu öğrenci numarası zaten mevcut: {ogrenci.OgrenciNo}");
                return false;
            }

            ogrenciler.Add(ogrenci.OgrenciNo, ogrenci);
            Console.WriteLine($"Öğrenci başarıyla eklendi: {ogrenci.GetInfo()}");
            return true;
        }

        // Öğrenci getirme
        public Ogrenci OgrenciGetir(string ogrenciNo)
        {
            if (string.IsNullOrEmpty(ogrenciNo))
            {
                return null;
            }

            ogrenciler.TryGetValue(ogrenciNo, out Ogrenci ogrenci);
            return ogrenci;
        }

        // Öğrenci güncelleme
        public bool OgrenciGuncelle(string ogrenciNo, string yeniAd, string yeniSoyad, string yeniEmail)
        {
            Ogrenci ogrenci = OgrenciGetir(ogrenciNo);
            if (ogrenci == null)
            {
                Console.WriteLine($"Öğrenci bulunamadı: {ogrenciNo}");
                return false;
            }

            if (!string.IsNullOrEmpty(yeniAd))
                ogrenci.Ad = yeniAd;

            if (!string.IsNullOrEmpty(yeniSoyad))
                ogrenci.Soyad = yeniSoyad;

            if (!string.IsNullOrEmpty(yeniEmail))
                ogrenci.Email = yeniEmail;

            Console.WriteLine($"Öğrenci başarıyla güncellendi: {ogrenci.GetInfo()}");
            return true;
        }

        // Öğrenci silme
        public bool OgrenciSil(string ogrenciNo)
        {
            if (string.IsNullOrEmpty(ogrenciNo))
            {
                return false;
            }

            if (!ogrenciler.ContainsKey(ogrenciNo))
            {
                Console.WriteLine($"Silinecek öğrenci bulunamadı: {ogrenciNo}");
                return false;
            }

            Ogrenci silinenOgrenci = ogrenciler[ogrenciNo];
            ogrenciler.Remove(ogrenciNo);
            Console.WriteLine($"Öğrenci başarıyla silindi: {silinenOgrenci.GetInfo()}");
            return true;
        }

        // Tüm öğrencileri listeleme
        public List<Ogrenci> TumOgrenciler()
        {
            return ogrenciler.Values.ToList();
        }

        // Öğrenci var mı kontrolü
        public bool OgrenciVarMi(string ogrenciNo)
        {
            if (string.IsNullOrEmpty(ogrenciNo))
            {
                return false;
            }

            return ogrenciler.ContainsKey(ogrenciNo);
        }

        // Toplam öğrenci sayısı
        public int ToplamOgrenciSayisi()
        {
            return ogrenciler.Count;
        }

        // Öğrencileri görüntüleme
        public void OgrencileriGoruntule()
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde kayıtlı öğrenci bulunmamaktadır.");
                return;
            }

            Console.WriteLine("\n=== KAYITLI ÖĞRENCİLER ===");
            foreach (var ogrenci in ogrenciler.Values)
            {
                Console.WriteLine(ogrenci.GetInfo());
            }
            Console.WriteLine($"Toplam öğrenci sayısı: {ogrenciler.Count}");
        }

        // Öğrenci arama (ad/soyad ile)
        public List<Ogrenci> OgrenciAra(string aramaKelimesi)
        {
            if (string.IsNullOrEmpty(aramaKelimesi))
            {
                return new List<Ogrenci>();
            }

            return ogrenciler.Values
                .Where(o => o.Ad.ToLower().Contains(aramaKelimesi.ToLower()) ||
                           o.Soyad.ToLower().Contains(aramaKelimesi.ToLower()) ||
                           o.TamAd().ToLower().Contains(aramaKelimesi.ToLower()))
                .ToList();
        }
    }
}