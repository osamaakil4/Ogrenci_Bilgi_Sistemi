using Ogrenci_Bilgi_Sistemi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


    public class VeriYoneticisi
    {
        private string dosyaYolu;
        private string ogrenciDosya;
        private string dersDosya;
        private string notDosya;
        private string dersKayitDosya;

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
            dersKayitDosya = Path.Combine(dosyaYolu, "derskayitlari.json");
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
                        dersler.Add(new ZorunluDers(veri.Kod, veri.Ad, veri.Kredi, veri.Akts, veri.Donem));
                    }
                    else
                    {
                        dersler.Add(new SecmeliDers(veri.Kod, veri.Ad, veri.Kredi, veri.Akts, veri.Donem));
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

        // GÜNCELLENMIŞ: Notları kaydetme - basit veri yapısı kullanılıyor
        public bool NotlariKaydet(List<Not> notlar)
        {
            try
            {
                var notVerileri = new List<NotVeri>();
                foreach (var not in notlar)
                {
                    notVerileri.Add(new NotVeri
                    {
                        OgrenciNo = not.OgrenciNo,
                        DersKodu = not.DersKodu,
                        VizeNotu = not.Vize,
                        FinalNotu = not.Final
                   
                    });
                }

                string json = JsonSerializer.Serialize(notVerileri, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(notDosya, json);
                Console.WriteLine($"Toplam {notVerileri.Count} not kaydedildi.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Not verileri kaydedilirken hata: {ex.Message}");
                return false;
            }
        }

        // GÜNCELLENMIŞ: Notları yükleme - basit veri yapısından Not nesnesi oluşturma
        public List<Not> NotlariYukle()
        {
            try
            {
                if (!File.Exists(notDosya))
                {
                    Console.WriteLine("Not dosyası bulunamadı.");
                    return new List<Not>();
                }

                string json = File.ReadAllText(notDosya);
                var notVerileri = JsonSerializer.Deserialize<List<NotVeri>>(json) ?? new List<NotVeri>();
                Console.WriteLine($"Dosyadan {notVerileri.Count} not yüklendi.");

                var notlar = new List<Not>();
                foreach (var veri in notVerileri)
                {
                    var not = new Not(veri.OgrenciNo, veri.DersKodu, veri.VizeNotu, veri.FinalNotu)
                    {
                    
                    };

                    // Bütünleme notu varsa ekle
                
                    notlar.Add(not);
                }

                Console.WriteLine($"Toplam {notlar.Count} not nesnesi oluşturuldu.");
                return notlar;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Not verileri yüklenirken hata: {ex.Message}");
                return new List<Not>();
            }
        }

        // Ders kayıtlarını kaydetme
        public bool DersKayitlariniKaydet(List<OgrenciDersKayit> dersKayitlari)
        {
            try
            {
                var kayitVerileri = new List<DersKayitVeri>();
                foreach (var kayit in dersKayitlari)
                {
                    kayitVerileri.Add(new DersKayitVeri
                    {
                        OgrenciNo = kayit.OgrenciNo,
                        DersKodu = kayit.DersKodu
                    });
                }
                string json = JsonSerializer.Serialize(kayitVerileri, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dersKayitDosya, json);
                Console.WriteLine($"Toplam {kayitVerileri.Count} ders kaydı kaydedildi.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ders kayıt verileri kaydedilirken hata: {ex.Message}");
                return false;
            }
        }

        // Ders kayıtlarını yükleme
        public Dictionary<string, List<string>> DersKayitlariniYukle()
        {
            try
            {
                if (!File.Exists(dersKayitDosya))
                    return new Dictionary<string, List<string>>();

                string json = File.ReadAllText(dersKayitDosya);
                var kayitVerileri = JsonSerializer.Deserialize<List<DersKayitVeri>>(json) ?? new List<DersKayitVeri>();

                var dersKayitlari = new Dictionary<string, List<string>>();
                foreach (var veri in kayitVerileri)
                {
                    if (!dersKayitlari.ContainsKey(veri.OgrenciNo))
                    {
                        dersKayitlari[veri.OgrenciNo] = new List<string>();
                    }
                    dersKayitlari[veri.OgrenciNo].Add(veri.DersKodu);
                }

                Console.WriteLine($"Toplam {kayitVerileri.Count} ders kaydı yüklendi.");
                return dersKayitlari;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ders kayıt verileri yüklenirken hata: {ex.Message}");
                return new Dictionary<string, List<string>>();
            }
        }

        // GÜNCELLENMIŞ: Tüm verileri kaydetme - daha detaylı log
        public bool TumVerileriKaydet(SistemYonetici sistem)
        {
            bool basarili = true;

            Console.WriteLine("Veri kaydetme işlemi başlatılıyor...");

            // Öğrencileri kaydet
            var ogrenciSayisi = sistem.OgrenciYoneticisi.TumOgrenciler().Count;
            Console.WriteLine($"Kaydedilecek öğrenci sayısı: {ogrenciSayisi}");
            basarili &= OgrencileriKaydet(sistem.OgrenciYoneticisi.TumOgrenciler());

            // Dersleri kaydet
            var dersSayisi = sistem.DersYoneticisi.TumDersler().Count;
            Console.WriteLine($"Kaydedilecek ders sayısı: {dersSayisi}");
            basarili &= DersleriKaydet(sistem.DersYoneticisi.TumDersler());

            // Notları kaydet
            var notSayisi = sistem.NotYoneticisi.TumNotlar().Count;
            Console.WriteLine($"Kaydedilecek not sayısı: {notSayisi}");
            basarili &= NotlariKaydet(sistem.NotYoneticisi.TumNotlar());

            // Ders kayıtlarını da kaydet
            if (sistem.DersKayitYoneticisi != null)
            {
                var dersKayitSayisi = sistem.DersKayitYoneticisi.TumDersKayitlari().Count;
                Console.WriteLine($"Kaydedilecek ders kaydı sayısı: {dersKayitSayisi}");
                basarili &= DersKayitlariniKaydet(sistem.DersKayitYoneticisi.TumDersKayitlari());
            }

            Console.WriteLine($"Veri kaydetme işlemi tamamlandı. Başarı durumu: {basarili}");
            return basarili;
        }

        // GÜNCELLENMIŞ: Tüm verileri yükleme - doğru sıralama ve daha detaylı log
        public void TumVerileriYukle(SistemYonetici sistem)
        {
            Console.WriteLine("Veri yükleme işlemi başlatılıyor...");

            // 1. Önce öğrencileri yükle
            var ogrenciler = OgrencileriYukle();
            Console.WriteLine($"Yüklenen öğrenci sayısı: {ogrenciler.Count}");
            foreach (var ogrenci in ogrenciler)
            {
                sistem.OgrenciYoneticisi.OgrenciEkle(ogrenci);
            }

            // 2. Sonra dersleri yükle
            var dersler = DersleriYukle();
            Console.WriteLine($"Yüklenen ders sayısı: {dersler.Count}");
            foreach (var ders in dersler)
            {
                sistem.DersYoneticisi.DersEkle(ders);
            }

            // 3. Ders kayıtlarını yükle
            var dersKayitlari = DersKayitlariniYukle();
            int toplamDersKayit = 0;
            foreach (var kayit in dersKayitlari)
            {
                foreach (var dersKodu in kayit.Value)
                {
                    sistem.DersKayitYoneticisi.DersKaydiEkle(kayit.Key, dersKodu);
                    toplamDersKayit++;
                }
            }
            Console.WriteLine($"Yüklenen ders kaydı sayısı: {toplamDersKayit}");

            // 4. En son notları yükle (öğrenci ve ders bilgileri hazır olduktan sonra)
            var notlar = NotlariYukle();
            Console.WriteLine($"Yüklenen not sayısı: {notlar.Count}");
            foreach (var not in notlar)
            {
                // Not eklemeden önce öğrenci ve dersin var olduğunu kontrol et
                var ogrenci = sistem.OgrenciYoneticisi.OgrenciAra(not.OgrenciNo);
                var ders = sistem.DersYoneticisi.DersBul(not.DersKodu);

                if (ogrenci != null && ders != null)
                {
                    sistem.NotYoneticisi.NotEkle(not);
                    Console.WriteLine($"Not eklendi: {not.OgrenciNo} - {not.DersKodu}");
                }
                else
                {
                    Console.WriteLine($"Not eklenemedi - Öğrenci veya ders bulunamadı: {not.OgrenciNo} - {not.DersKodu}");
                }
            }

            Console.WriteLine("Veri yükleme işlemi tamamlandı.");
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

    // Ders kayıt verisi için yardımcı sınıf
    public class DersKayitVeri
    {
        public string OgrenciNo { get; set; }
        public string DersKodu { get; set; }
    }

    // YENİ: Not verisi için yardımcı sınıf - JSON serileştirme için
    public class NotVeri
    {
        public string OgrenciNo { get; set; }
        public string DersKodu { get; set; }
        public double VizeNotu { get; set; }
        public double FinalNotu { get; set; }
        public double ButunlemeNotu { get; set; }
        public bool HasButunleme { get; set; }
        public int Yil { get; set; }
        public string Donem { get; set; }
    }
