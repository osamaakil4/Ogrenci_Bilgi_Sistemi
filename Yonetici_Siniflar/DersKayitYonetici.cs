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

        // Constructor
        public DersKayitYonetici(OgrenciYonetici ogrenciYonetici, DersYonetici dersYonetici)
        {
            this.ogrenciYonetici = ogrenciYonetici;
            this.dersYonetici = dersYonetici;
            dersKayitlari = new List<OgrenciDersKayit>();
        }

        // Ders kaydı ekleme
        public bool DersKaydiEkle(string ogrenciNo, string dersKodu)
        {
            // Öğrenci var mı kontrol et
            if (!ogrenciYonetici.OgrenciVarMi(ogrenciNo))
            {
                Console.WriteLine($"Öğrenci bulunamadı: {ogrenciNo}");
                return false;
            }

            // Ders var mı kontrol et
            if (!dersYonetici.DersVarMi(dersKodu))
            {
                Console.WriteLine($"Ders bulunamadı: {dersKodu}");
                return false;
            }

            // Zaten kayıtlı mı kontrol et
            if (OgrenciDerseKayitliMi(ogrenciNo, dersKodu))
            {
                Console.WriteLine($"Öğrenci {ogrenciNo} zaten {dersKodu} dersine kayıtlı!");
                return false;
            }

            // Yeni kayıt oluştur
            OgrenciDersKayit yeniKayit = new OgrenciDersKayit(ogrenciNo, dersKodu);
            dersKayitlari.Add(yeniKayit);

            Console.WriteLine($"Ders kaydı başarıyla eklendi: {yeniKayit.GetInfo()}");
            return true;
        }

        // Ders kaydını iptal etme
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

        // Öğrenci derse kayıtlı mı kontrol
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

        // Derse kayıtlı öğrencileri getir
        public List<OgrenciDersKayit> DersinOgrencileri(string dersKodu)
        {
            return dersKayitlari
                .Where(k => k.DersKodu == dersKodu && k.Durum == "Aktif")
                .ToList();
        }

        // Öğrencinin kayıtlı olduğu ders sayısı
        public int OgrencininDersSayisi(string ogrenciNo)
        {
            return OgrencininDersleri(ogrenciNo).Count;
        }

        // Derse kayıtlı öğrenci sayısı
        public int DersinOgrenciSayisi(string dersKodu)
        {
            return DersinOgrencileri(dersKodu).Count;
        }

        // Öğrencinin toplam kredi yükü
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

        // Tüm kayıtları getir
        public List<OgrenciDersKayit> TumKayitlar()
        {
            return dersKayitlari.ToList();
        }

        // Aktif kayıtları getir
        public List<OgrenciDersKayit> AktifKayitlar()
        {
            return dersKayitlari.Where(k => k.Durum == "Aktif").ToList();
        }

        // Öğrencinin ders kaydı geçmişi
        public List<OgrenciDersKayit> OgrencininKayitGecmisi(string ogrenciNo)
        {
            return dersKayitlari
                .Where(k => k.OgrenciNo == ogrenciNo)
                .OrderByDescending(k => k.KayitTarihi)
                .ToList();
        }

        // Dönem bazında kayıtları getir
        public List<OgrenciDersKayit> DonemKayitlari(string donem)
        {
            var donemDersleri = dersYonetici.DonemDersleri(donem);
            var donemDersKodlari = donemDersleri.Select(d => d.Kod).ToHashSet();

            return dersKayitlari
                .Where(k => donemDersKodlari.Contains(k.DersKodu) && k.Durum == "Aktif")
                .ToList();
        }

        // İstatistikler
        public void KayitIstatistikleri()
        {
            var toplamKayit = dersKayitlari.Count;
            var aktifKayit = AktifKayitlar().Count;
            var iptalKayit = dersKayitlari.Count(k => k.Durum == "Bıraktı");

            Console.WriteLine("\n=== DERS KAYIT İSTATİSTİKLERİ ===");
            Console.WriteLine($"Toplam Kayıt: {toplamKayit}");
            Console.WriteLine($"Aktif Kayıt: {aktifKayit}");
            Console.WriteLine($"İptal Edilen Kayıt: {iptalKayit}");

            // En çok kayıt olan ders
            var dersSayilari = AktifKayitlar()
                .GroupBy(k => k.DersKodu)
                .Select(g => new { DersKodu = g.Key, Sayi = g.Count() })
                .OrderByDescending(x => x.Sayi)
                .FirstOrDefault();

            if (dersSayilari != null)
            {
                var ders = dersYonetici.DersGetir(dersSayilari.DersKodu);
                Console.WriteLine($"En Popüler Ders: {ders?.Ad} ({dersSayilari.DersKodu}) - {dersSayilari.Sayi} öğrenci");
            }
        }

        // Öğrencinin ders programını göster
        public void OgrencininDersProgrami(string ogrenciNo)
        {
            var ogrenci = ogrenciYonetici.OgrenciGetir(ogrenciNo);
            if (ogrenci == null)
            {
                Console.WriteLine($"Öğrenci bulunamadı: {ogrenciNo}");
                return;
            }

            var ogrencininDersleri = OgrencininDersleri(ogrenciNo);
            if (ogrencininDersleri.Count == 0)
            {
                Console.WriteLine($"{ogrenci.TamAd()} hiçbir derse kayıtlı değil.");
                return;
            }

            Console.WriteLine($"\n=== {ogrenci.TamAd()} - DERS PROGRAMI ===");
            int toplamKredi = 0;

            foreach (var kayit in ogrencininDersleri.OrderBy(k => k.DersKodu))
            {
                var ders = dersYonetici.DersGetir(kayit.DersKodu);
                if (ders != null)
                {
                    Console.WriteLine($"{ders.Kod} - {ders.Ad} ({ders.Kredi} kredi) - {ders.Donem}");
                    toplamKredi += ders.Kredi;
                }
            }

            Console.WriteLine($"Toplam Ders Sayısı: {ogrencininDersleri.Count}");
            Console.WriteLine($"Toplam Kredi: {toplamKredi}");
        }
    }
}