using System;
using System.Collections.Generic;
using System.Linq;

namespace Ogrenci_Bilgi_Sistemi
{
    public class OgrenciYonetici
    {
        private Dictionary<string, Ogrenci> ogrenciler;

       
        public OgrenciYonetici()
        {
            ogrenciler = new Dictionary<string, Ogrenci>();
        }

        
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

        public Ogrenci OgrenciGetir(string ogrenciNo)
        {
            if (string.IsNullOrEmpty(ogrenciNo))
            {
                return null;
            }

            ogrenciler.TryGetValue(ogrenciNo, out Ogrenci ogrenci);
            return ogrenci;
        }



     
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

        public List<Ogrenci> TumOgrenciler()
        {
            return ogrenciler.Values.ToList();
        }

       
        public bool OgrenciVarMi(string ogrenciNo)
        {
            if (string.IsNullOrEmpty(ogrenciNo))
            {
                return false;
            }

            return ogrenciler.ContainsKey(ogrenciNo);
        }

     
        public int ToplamOgrenciSayisi()
        {
            return ogrenciler.Count;
        }

        

      
        public List<Ogrenci> OgrenciAra(string adsoyad)
        {
            if (string.IsNullOrEmpty(adsoyad))
            {
                return new List<Ogrenci>();
            }

            return ogrenciler.Values
                .Where(o => o.Ad.ToLower().Contains(adsoyad.ToLower()) ||
                           o.Soyad.ToLower().Contains(adsoyad.ToLower()) ||
                           o.TamAd().ToLower().Contains(adsoyad.ToLower()))
                .ToList();
        }
    }
}