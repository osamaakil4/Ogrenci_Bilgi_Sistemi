using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ogrenci_Bilgi_Sistemi
{
    public class TranskriptYonetici : IRaporlanabilir
    {
        private OgrenciYonetici ogrenciYonetici;
        private DersYonetici dersYonetici;
        private NotYonetici notYonetici;

        // Constructor
        public TranskriptYonetici(OgrenciYonetici ogrenciYonetici, DersYonetici dersYonetici, NotYonetici notYonetici)
        {
            this.ogrenciYonetici = ogrenciYonetici;
            this.dersYonetici = dersYonetici;
            this.notYonetici = notYonetici;
        }

        // IRaporlanabilir Belirli öğrenci için transkript oluşturma
        public string TranskriptOlustur(string ogrenciNo)
        {
            var ogrenci = ogrenciYonetici.OgrenciGetir(ogrenciNo);
            if (ogrenci == null)
            {
                return $"Öğrenci bulunamadı: {ogrenciNo}";
            }

            var ogrenciNotlari = notYonetici.OgrenciNotlari(ogrenciNo);
            if (ogrenciNotlari.Count == 0)
            {
                return $"Bu öğrenciye ait not kaydı bulunamadı: {ogrenciNo}";
            }

            var sb = new StringBuilder();

            // Başlık
            sb.AppendLine("==================================================");
            sb.AppendLine("                 TRANSKRİPT");
            sb.AppendLine("==================================================");
            sb.AppendLine();

            // Öğrenci bilgileri
            sb.AppendLine("ÖĞRENCİ BİLGİLERİ:");
            sb.AppendLine($"Öğrenci No    : {ogrenci.OgrenciNo}");
            sb.AppendLine($"Ad Soyad      : {ogrenci.TamAd()}");
            sb.AppendLine($"E-mail        : {ogrenci.Email}");
            sb.AppendLine($"Kayıt Tarihi  : {ogrenci.KayitTarihi:dd.MM.yyyy}");
            sb.AppendLine();

            // Ders başlıkları
            sb.AppendLine("DERS KAYITLARI:");
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine($"{"Ders Kodu",-12} {"Ders Adı",-25} {"Kredi",-6} {"Vize",-6} {"Final",-6} {"Ort.",-6} {"Harf",-5} {"Durum",-8}");
            sb.AppendLine("--------------------------------------------------");

            // Notları sırala
            var siraliNotlar = ogrenciNotlari.OrderBy(n => n.DersKodu).ToList();
            int toplamKredi = 0;
            int gecenKredi = 0;
            double toplamPuan = 0;

            foreach (var not in siraliNotlar)
            {
                var ders = dersYonetici.DersGetir(not.DersKodu);
                if (ders != null)
                {
                    string durum = not.GectiMi() ? "GEÇTİ" : "KALDI";

                    sb.AppendLine($"{not.DersKodu,-12} {ders.Ad,-25} {ders.Kredi,-6} {not.Vize,-6} {not.Final,-6} {not.Ortalama,-6:F1} {not.HarfNotu,-5} {durum,-8}");

                    toplamKredi += ders.Kredi;
                    if (not.GectiMi())
                    {
                        gecenKredi += ders.Kredi;
                        toplamPuan += not.Ortalama * ders.Kredi;
                    }
                }
            }

            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine();

            // Özet bilgiler
            double gano = notYonetici.GanoHesapla(ogrenciNo);
            double agno = gecenKredi > 0 ? toplamPuan / gecenKredi : 0;

            sb.AppendLine("ÖZET BİLGİLER:");
            sb.AppendLine($"Toplam Alınan Kredi  : {toplamKredi}");
            sb.AppendLine($"Başarılan Kredi      : {gecenKredi}");
            sb.AppendLine($"GANO (Genel Ortalama): {gano:F2}");
            sb.AppendLine($"AGNO (Ağırlıklı Ort.): {agno:F2}");
            sb.AppendLine();

            // Tarih
            sb.AppendLine($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine("==================================================");

            return sb.ToString();
        }




      
    }
}