using System;
using System.Collections.Generic;
using System.Linq;

namespace Ogrenci_Bilgi_Sistemi
{
    public class NotYonetici
    {
        private List<Not> notlar;

       
        public NotYonetici()
        {
            notlar = new List<Not>();
        }

       
        public bool NotEkle(Not not)
        {
            if (not == null || string.IsNullOrEmpty(not.OgrenciNo) || string.IsNullOrEmpty(not.DersKodu))
            {
                Console.WriteLine("Geçersiz not bilgisi!");
                return false;
            }
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

            mevcutNot.Vize = yeniNot.Vize;
            mevcutNot.Final = yeniNot.Final;

            Console.WriteLine($"Not başarıyla güncellendi: {mevcutNot.GetInfo()}");
            return true;
        }

       
        public List<Not> OgrenciNotlari(string ogrenciNo)
        {
            if (string.IsNullOrEmpty(ogrenciNo))
            {
                return new List<Not>();
            }

            return notlar.Where(n => n.OgrenciNo == ogrenciNo).ToList();
        }

       
       
        public Not NotGetir(string ogrenciNo, string dersKodu)
        {
            if (string.IsNullOrEmpty(ogrenciNo) || string.IsNullOrEmpty(dersKodu))
            {
                return null;
            }

            return notlar.FirstOrDefault(n => n.OgrenciNo == ogrenciNo && n.DersKodu == dersKodu);
        }

        
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


        public List<Not> TumNotlar()
        {
            return notlar.ToList();
        }

      
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

       

      


     

        
        }
    }
