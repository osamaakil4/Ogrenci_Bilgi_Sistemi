using System;
using System.Collections.Generic;
using System.Linq;

namespace Ogrenci_Bilgi_Sistemi
{
    public class NotYonetici
    {
        private List<Not> notlar;

        // Constructor
        public NotYonetici()
        {
            notlar = new List<Not>();
        }

        // Not ekleme
        public bool NotEkle(Not not)
        {
            if (not == null || string.IsNullOrEmpty(not.OgrenciNo) || string.IsNullOrEmpty(not.DersKodu))
            {
                Console.WriteLine("Geçersiz not bilgisi!");
                return false;
            }

            // Aynı öğrenci ve ders için not var mı kontrol et
            var mevcutNot = NotGetir(not.OgrenciNo, not.DersKodu);
            if (mevcutNot != null)
            {
                Console.WriteLine($"Bu öğrenci ve ders için zaten not kaydı mevcut: {not.OgrenciNo} - {not.DersKodu}");
                return false;
            }

            notlar.Add(not);
            Console.WriteLine($"Not başarıyla eklendi: {not.GetInfo()}");
            return true;
        }

        // Not güncelleme
        public bool NotGuncelle(string ogrenciNo, Not yeniNot)
        {
            if (yeniNot == null || string.IsNullOrEmpty(yeniNot.OgrenciNo) || string.IsNullOrEmpty(yeniNot.DersKodu))
            {
                Console.WriteLine("Geçersiz not bilgisi!");
                return false;
            }

            var mevcutNot = NotGetir(yeniNot.OgrenciNo, yeniNot.DersKodu);
            if (mevcutNot == null)
            {
                Console.WriteLine($"Güncellenecek not bulunamadı: {yeniNot.OgrenciNo} - {yeniNot.DersKodu}");
                return false;
            }

            // Mevcut notu güncelle
            mevcutNot.Vize = yeniNot.Vize;
            mevcutNot.Final = yeniNot.Final;

            Console.WriteLine($"Not başarıyla güncellendi: {mevcutNot.GetInfo()}");
            return true;
        }

        // Belirli öğrencinin notlarını getirme
        public List<Not> OgrenciNotlari(string ogrenciNo)
        {
            if (string.IsNullOrEmpty(ogrenciNo))
            {
                return new List<Not>();
            }

            return notlar.Where(n => n.OgrenciNo == ogrenciNo).ToList();
        }

        // Belirli dersin notlarını getirme
        public List<Not> DersNotlari(string dersKodu)
        {
            if (string.IsNullOrEmpty(dersKodu))
            {
                return new List<Not>();
            }

            return notlar.Where(n => n.DersKodu == dersKodu).ToList();
        }

        // Belirli öğrenci ve ders için not getirme
        public Not NotGetir(string ogrenciNo, string dersKodu)
        {
            if (string.IsNullOrEmpty(ogrenciNo) || string.IsNullOrEmpty(dersKodu))
            {
                return null;
            }

            return notlar.FirstOrDefault(n => n.OgrenciNo == ogrenciNo && n.DersKodu == dersKodu);
        }

        // GANO hesaplama (Öğrencinin tüm derslerinin ortalaması)
        public double GanoHesapla(string ogrenciNo)
        {
            if (string.IsNullOrEmpty(ogrenciNo))
            {
                return 0.0;
            }

            var ogrenciNotlari = OgrenciNotlari(ogrenciNo);
            if (ogrenciNotlari.Count == 0)
            {
                return 0.0;
            }

            double toplamOrtalama = ogrenciNotlari.Sum(n => n.Ortalama);
            return toplamOrtalama / ogrenciNotlari.Count;
        }

        // Öğrencinin genel ortalaması (başka bir hesaplama yöntemi)
        public double OgrencininOrtalamasi(string ogrenciNo)
        {
            return GanoHesapla(ogrenciNo);
        }

        // Tüm notları getirme
        public List<Not> TumNotlar()
        {
            return notlar.ToList();
        }

        // Not silme
        public bool NotSil(string ogrenciNo, string dersKodu)
        {
            var silinecekNot = NotGetir(ogrenciNo, dersKodu);
            if (silinecekNot == null)
            {
                Console.WriteLine($"Silinecek not bulunamadı: {ogrenciNo} - {dersKodu}");
                return false;
            }

            notlar.Remove(silinecekNot);
            Console.WriteLine($"Not başarıyla silindi: {silinecekNot.GetInfo()}");
            return true;
        }

        // Öğrencinin tüm notlarını silme
        public bool OgrenciNotlariniSil(string ogrenciNo)
        {
            var ogrenciNotlari = OgrenciNotlari(ogrenciNo);
            if (ogrenciNotlari.Count == 0)
            {
                Console.WriteLine($"Bu öğrenciye ait not bulunamadı: {ogrenciNo}");
                return false;
            }

            foreach (var not in ogrenciNotlari)
            {
                notlar.Remove(not);
            }

            Console.WriteLine($"{ogrenciNo} numaralı öğrencinin {ogrenciNotlari.Count} adet notu silindi.");
            return true;
        }

        // Ders notlarını görüntüleme
        public void DersNotlariniGoruntule(string dersKodu)
        {
            var dersNotlari = DersNotlari(dersKodu);
            if (dersNotlari.Count == 0)
            {
                Console.WriteLine($"Bu derse ait not bulunamadı: {dersKodu}");
                return;
            }

            Console.WriteLine($"\n=== {dersKodu} DERSİ NOTLARI ===");
            foreach (var not in dersNotlari.OrderBy(n => n.OgrenciNo))
            {
                Console.WriteLine(not.GetInfo());
            }

            // İstatistikler
            double dersOrtalamasi = dersNotlari.Average(n => n.Ortalama);
            int gecenSayisi = dersNotlari.Count(n => n.GectiMi());
            int kalanSayisi = dersNotlari.Count - gecenSayisi;

            Console.WriteLine($"\nDers İstatistikleri:");
            Console.WriteLine($"Ders Ortalaması: {dersOrtalamasi:F2}");
            Console.WriteLine($"Geçen: {gecenSayisi}, Kalan: {kalanSayisi}");
            Console.WriteLine($"Başarı Oranı: %{((double)gecenSayisi / dersNotlari.Count * 100):F1}");
        }

        // Öğrenci notlarını görüntüleme
        public void OgrenciNotlariniGoruntule(string ogrenciNo)
        {
            var ogrenciNotlari = OgrenciNotlari(ogrenciNo);
            if (ogrenciNotlari.Count == 0)
            {
                Console.WriteLine($"Bu öğrenciye ait not bulunamadı: {ogrenciNo}");
                return;
            }

            Console.WriteLine($"\n=== {ogrenciNo} ÖĞRENCİSİNİN NOTLARI ===");
            foreach (var not in ogrenciNotlari.OrderBy(n => n.DersKodu))
            {
                Console.WriteLine(not.GetInfo());
            }

            double gano = GanoHesapla(ogrenciNo);
            int gecenDersSayisi = ogrenciNotlari.Count(n => n.GectiMi());
            int kalanDersSayisi = ogrenciNotlari.Count - gecenDersSayisi;

            Console.WriteLine($"\nÖğrenci Özeti:");
            Console.WriteLine($"GANO: {gano:F2}");
            Console.WriteLine($"Geçilen Ders: {gecenDersSayisi}, Kalınan Ders: {kalanDersSayisi}");
        }

        // En yüksek not
        public Not EnYuksekNot()
        {
            return notlar.OrderByDescending(n => n.Ortalama).FirstOrDefault();
        }

        // En düşük not
        public Not EnDusukNot()
        {
            return notlar.OrderBy(n => n.Ortalama).FirstOrDefault();
        }

        // Genel istatistikler
        public void GenelIstatistikler()
        {
            if (notlar.Count == 0)
            {
                Console.WriteLine("Sistemde kayıtlı not bulunmamaktadır.");
                return;
            }

            Console.WriteLine("\n=== GENEL NOT İSTATİSTİKLERİ ===");
            Console.WriteLine($"Toplam Not Sayısı: {notlar.Count}");
            Console.WriteLine($"Genel Ortalama: {notlar.Average(n => n.Ortalama):F2}");
            Console.WriteLine($"En Yüksek Not: {EnYuksekNot()?.Ortalama:F2}");
            Console.WriteLine($"En Düşük Not: {EnDusukNot()?.Ortalama:F2}");

            int toplamGecen = notlar.Count(n => n.GectiMi());
            int toplamKalan = notlar.Count - toplamGecen;
            Console.WriteLine($"Genel Başarı Oranı: %{((double)toplamGecen / notlar.Count * 100):F1}");
        }
    }
}