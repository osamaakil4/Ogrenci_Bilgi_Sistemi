using System;
using System.Collections.Generic;
using System.Linq;

namespace Ogrenci_Bilgi_Sistemi
{
    public class DersYonetici
    {
        private Dictionary<string, Ders> dersler;

        public DersYonetici()
        {
            dersler = new Dictionary<string, Ders>();
        }

     
        public bool DersEkle(Ders ders)
        {
            if (ders == null || string.IsNullOrEmpty(ders.Kod))
            {
                return false;
            }

            if (dersler.ContainsKey(ders.Kod))
            {
                Console.WriteLine($"Bu ders kodu zaten mevcut: {ders.Kod}");
                return false;
            }

            dersler.Add(ders.Kod, ders);
            Console.WriteLine($"Ders başarıyla eklendi: {ders.GetInfo()}");
            return true;
        }

       
        public Ders DersGetir(string dersKodu)
        {
            if (string.IsNullOrEmpty(dersKodu))
            {
                return null;
            }

            dersler.TryGetValue(dersKodu, out Ders ders);
            return ders;
        }

     
        public bool DersSil(string dersKodu)
        {
            if (string.IsNullOrEmpty(dersKodu))
            {
                return false;
            }

            if (!dersler.ContainsKey(dersKodu))
            {
                Console.WriteLine($"Silinecek ders bulunamadı: {dersKodu}");
                return false;
            }

            Ders silinenDers = dersler[dersKodu];
            dersler.Remove(dersKodu);
            Console.WriteLine($"Ders başarıyla silindi: {silinenDers.GetInfo()}");
            return true;
        }

        // Tüm dersleri listele
        public List<Ders> TumDersler()
        {
            return dersler.Values.ToList();
        }

        // Zorunlu dersleri listele
        public List<ZorunluDers> ZorunluDersler()
        {
            return dersler.Values
                .Where(d => d is ZorunluDers)
                .Cast<ZorunluDers>()
                .ToList();
        }

        // Seçmeli dersleri listele
        public List<SecmeliDers> SecmeliDersler()
        {
            return dersler.Values
                .Where(d => d is SecmeliDers)
                .Cast<SecmeliDers>()
                .ToList();
        }

     
        public bool DersVarMi(string dersKodu)
        {
            if (string.IsNullOrEmpty(dersKodu))
            {
                return false;
            }

            return dersler.ContainsKey(dersKodu);
        }

     
        public int ToplamDersSayisi()
        {
            return dersler.Count;
        }


        // Dönem dersleri 
        public List<Ders> DonemDersleri(string donem)
        {
            if (string.IsNullOrEmpty(donem))
            {
                return new List<Ders>();
            }

            return dersler.Values
                .Where(d => d.Donem.Equals(donem, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        
        public Ders DersBul(string dersKodu)
        {
            if (string.IsNullOrEmpty(dersKodu))
            {
                return null;
            }

            return dersler.Values
                .FirstOrDefault(d => d.Kod.Equals(dersKodu, StringComparison.OrdinalIgnoreCase));
        }

    

      

      

      
    }
}