using System;
using System.Collections.Generic;
using System.Linq;

namespace Ogrenci_Bilgi_Sistemi
{
    public class DersYonetici
    {
        private Dictionary<string, Ders> dersler;

        // Constructor
        public DersYonetici()
        {
            dersler = new Dictionary<string, Ders>();
        }

        // Ders ekleme
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

        // Ders getirme
        public Ders DersGetir(string dersKodu)
        {
            if (string.IsNullOrEmpty(dersKodu))
            {
                return null;
            }

            dersler.TryGetValue(dersKodu, out Ders ders);
            return ders;
        }

        // Ders güncelleme
        public bool DersGuncelle(string dersKodu, string yeniAd, int yeniKredi, string yeniDonem)
        {
            Ders ders = DersGetir(dersKodu);
            if (ders == null)
            {
                Console.WriteLine($"Ders bulunamadı: {dersKodu}");
                return false;
            }

            if (!string.IsNullOrEmpty(yeniAd))
                ders.Ad = yeniAd;

            if (yeniKredi > 0)
                ders.Kredi = yeniKredi;

            if (!string.IsNullOrEmpty(yeniDonem))
                ders.Donem = yeniDonem;

            Console.WriteLine($"Ders başarıyla güncellendi: {ders.GetInfo()}");
            return true;
        }

        // Ders silme
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

        // Tüm dersleri listeleme
        public List<Ders> TumDersler()
        {
            return dersler.Values.ToList();
        }

        // Zorunlu dersleri listeleme
        public List<ZorunluDers> ZorunluDersler()
        {
            return dersler.Values
                .Where(d => d is ZorunluDers)
                .Cast<ZorunluDers>()
                .ToList();
        }

        // Seçmeli dersleri listeleme
        public List<SecmeliDers> SecmeliDersler()
        {
            return dersler.Values
                .Where(d => d is SecmeliDers)
                .Cast<SecmeliDers>()
                .ToList();
        }

        // Ders var mı kontrolü
        public bool DersVarMi(string dersKodu)
        {
            if (string.IsNullOrEmpty(dersKodu))
            {
                return false;
            }

            return dersler.ContainsKey(dersKodu);
        }

        // Toplam ders sayısı
        public int ToplamDersSayisi()
        {
            return dersler.Count;
        }

        // Dersleri görüntüleme
        public void DersleriGoruntule()
        {
            if (dersler.Count == 0)
            {
                Console.WriteLine("Sistemde kayıtlı ders bulunmamaktadır.");
                return;
            }

            Console.WriteLine("\n=== KAYITLI DERSLER ===");
            foreach (var ders in dersler.Values)
            {
                Console.WriteLine(ders.GetInfo());
            }
            Console.WriteLine($"Toplam ders sayısı: {dersler.Count}");
        }

        // Dönem bazında dersleri getirme
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

        // Ders arama (ad ile)
        public Ders DersBul(string dersKodu)
        {
            if (string.IsNullOrEmpty(dersKodu))
            {
                return null;
            }

            return dersler.Values
                .FirstOrDefault(d => d.Kod.Equals(dersKodu, StringComparison.OrdinalIgnoreCase));
        }

        // Toplam kredi hesaplama
        public int ToplamKrediHesapla()
        {
            return dersler.Values.Sum(d => d.Kredi);
        }

        // Zorunlu derslerin toplam kredisi
        public int ZorunluDerslerToplamKredi()
        {
            return ZorunluDersler().Sum(d => d.Kredi);
        }

        // Seçmeli derslerin toplam kredisi
        public int SecmeliDerslerToplamKredi()
        {
            return SecmeliDersler().Sum(d => d.Kredi);
        }

        // Ders türü istatistikleri
        public void DersIstatistikleri()
        {
            var zorunluSayisi = ZorunluDersler().Count;
            var secmeliSayisi = SecmeliDersler().Count;
            var zorunluKredi = ZorunluDerslerToplamKredi();
            var secmeliKredi = SecmeliDerslerToplamKredi();

            Console.WriteLine("\n=== DERS İSTATİSTİKLERİ ===");
            Console.WriteLine($"Zorunlu Ders Sayısı: {zorunluSayisi} (Toplam Kredi: {zorunluKredi})");
            Console.WriteLine($"Seçmeli Ders Sayısı: {secmeliSayisi} (Toplam Kredi: {secmeliKredi})");
            Console.WriteLine($"Genel Toplam: {dersler.Count} ders, {ToplamKrediHesapla()} kredi");
        }
    }
}