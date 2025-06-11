using Ogrenci_Bilgi_Sistemi;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi
{
    public class VeriYoneticisi
    {
        private string dosyaYolu;
        private string ogrenciDosya;
        private string dersDosya;
        private string notDosya;

        public VeriYoneticisi()
        {
            // Uygulama klasörü
            dosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OgrenciBilgiSistemi");

            // Klasör yoksa oluştur
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }

            // Dosya yolları
            ogrenciDosya = Path.Combine(dosyaYolu, "ogrenciler.json");
            dersDosya = Path.Combine(dosyaYolu, "dersler.json");
            notDosya = Path.Combine(dosyaYolu, "notlar.json");
        }

        // Öğrencileri kaydetme
        public bool OgrencileriKaydet(List<Ogrenci> ogrenciler)
        {
            try
            {
                string json = JsonSerializer.Serialize(ogrenciler, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ogrenciDosya, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Öğrenci verileri kaydedilirken hata: {ex.Message}");
                return false;
            }
        }

        // Öğrencileri yükleme
        public List<Ogrenci> OgrencileriYukle()
        {
            try
            {
                if (!File.Exists(ogrenciDosya))
                    return new List<Ogrenci>();

                string json = File.ReadAllText(ogrenciDosya);
                return JsonSerializer.Deserialize<List<Ogrenci>>(json) ?? new List<Ogrenci>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Öğrenci verileri yüklenirken hata: {ex.Message}");
                return new List<Ogrenci>();
            }
        }

        // Dersleri kaydetme
        public bool DersleriKaydet(List<Ders> dersler)
        {
            try
            {
                var dersVerileri = new List<DersVeri>();
                foreach (var ders in dersler)
                {
                    dersVerileri.Add(new DersVeri
                    {
                        Kod = ders.Kod,
                        Ad = ders.Ad,
                        Kredi = ders.Kredi,
                        Akts = ders.Akts,
                        Donem = ders.Donem,
                        Turu = ders is ZorunluDers ? "Zorunlu" : "Secmeli"
                    });
                }

                string json = JsonSerializer.Serialize(dersVerileri, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dersDosya, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ders verileri kaydedilirken hata: {ex.Message}");
                return false;
            }
        }

        // Dersleri yükleme
        public List<Ders> DersleriYukle()
        {
            try
            {
                if (!File.Exists(dersDosya))
                    return new List<Ders>();

                string json = File.ReadAllText(dersDosya);
                var dersVerileri = JsonSerializer.Deserialize<List<DersVeri>>(json) ?? new List<DersVeri>();

                var dersler = new List<Ders>();
                foreach (var veri in dersVerileri)
                {
                    if (veri.Turu == "Zorunlu")
                    {
                        dersler.Add(new ZorunluDers(veri.Kod, veri.Ad, veri.Kredi,veri.Akts, veri.Donem));
                    }
                    else
                    {
                        dersler.Add( new SecmeliDers(veri.Kod, veri.Ad, veri.Kredi,veri.Akts,veri.Donem));
                    }
                }

                return dersler;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ders verileri yüklenirken hata: {ex.Message}");
                return new List<Ders>();
            }
        }

        // Notları kaydetme
        public bool NotlariKaydet(List<Not> notlar)
        {
            try
            {
                string json = JsonSerializer.Serialize(notlar, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(notDosya, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Not verileri kaydedilirken hata: {ex.Message}");
                return false;
            }
        }

        // Notları yükleme
        public List<Not> NotlariYukle()
        {
            try
            {
                if (!File.Exists(notDosya))
                    return new List<Not>();

                string json = File.ReadAllText(notDosya);
                return JsonSerializer.Deserialize<List<Not>>(json) ?? new List<Not>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Not verileri yüklenirken hata: {ex.Message}");
                return new List<Not>();
            }
        }

        // Tüm verileri kaydetme
        public bool TumVerileriKaydet(SistemYonetici sistem)
        {
            bool basarili = true;
            basarili &= OgrencileriKaydet(sistem.OgrenciYoneticisi.TumOgrenciler());
            basarili &= DersleriKaydet(sistem.DersYoneticisi.TumDersler());
            basarili &= NotlariKaydet(sistem.NotYoneticisi.TumNotlar());
            return basarili;
        }

        // Tüm verileri yükleme
        public void TumVerileriYukle(SistemYonetici sistem)
        {
            // Öğrencileri yükle
            var ogrenciler = OgrencileriYukle();
            foreach (var ogrenci in ogrenciler)
            {
                sistem.OgrenciYoneticisi.OgrenciEkle(ogrenci);
            }

            // Dersleri yükle
            var dersler = DersleriYukle();
            foreach (var ders in dersler)
            {
                sistem.DersYoneticisi.DersEkle(ders);
            }

            // Notları yükle
            var notlar = NotlariYukle();
            foreach (var not in notlar)
            {
                sistem.NotYoneticisi.NotEkle(not);
            }
        }
    }

    // Ders verisi için yardımcı sınıf
    public class DersVeri
    {
        public string Kod { get; set; }
        public string Ad { get; set; }
        public int Kredi { get; set; }
        public string Donem { get; set; }
        public int Akts { get; set; }
        public string Turu { get; set; } // "Zorunlu" veya "Secmeli"
    }
}
