using System;

namespace Ogrenci_Bilgi_Sistemi
{
    public class SistemYonetici
    {
        private OgrenciYonetici ogrenciYonetici;
        private DersYonetici dersYonetici;
        private NotYonetici notYonetici;
        private TranskriptYonetici transkriptYonetici;
        private DersKayitYonetici dersKayitYonetici; // Yeni eklenen

        // Public property'ler - Formlara erişim için
        public OgrenciYonetici OgrenciYoneticisi => ogrenciYonetici;
        public DersYonetici DersYoneticisi => dersYonetici;
        public NotYonetici NotYoneticisi => notYonetici;
        public TranskriptYonetici TranskriptYoneticisi => transkriptYonetici;
        public DersKayitYonetici DersKayitYoneticisi => dersKayitYonetici; // Yeni eklenen

        // Constructor
        public SistemYonetici()
        {
            ogrenciYonetici = new OgrenciYonetici();
            dersYonetici = new DersYonetici();
            notYonetici = new NotYonetici();
            dersKayitYonetici = new DersKayitYonetici(ogrenciYonetici, dersYonetici); // Yeni eklenen
            transkriptYonetici = new TranskriptYonetici(ogrenciYonetici, dersYonetici, notYonetici);
        }

        // Örnek veriler yükleme (public yapıldı)
        public void OrnekVerilerYukle()
        {
            // Örnek öğrenciler
            ogrenciYonetici.OgrenciEkle(new Ogrenci("2021001", "Ahmet", "Yılmaz", "ahmet@email.com"));
            ogrenciYonetici.OgrenciEkle(new Ogrenci("2021002", "Fatma", "Kaya", "fatma@email.com"));
            ogrenciYonetici.OgrenciEkle(new Ogrenci("2021003", "Mehmet", "Demir", "mehmet@email.com"));

            // Örnek dersler
            dersYonetici.DersEkle(new ZorunluDers("CS101", "Programlama Temelleri", 4, "Güz",4,""));
            dersYonetici.DersEkle(new ZorunluDers("CS102", "Veri Yapıları", 3, "Bahar", 5, ""));
            dersYonetici.DersEkle(new ZorunluDers("CS102", "Veri Yapıları", 3, "Bahar", 3, ""));
            dersYonetici.DersEkle(new SecmeliDers("CS201", "Web Programlama", 3, "Bahar", 2, ""));
            dersYonetici.DersEkle(new ZorunluDers("CS103", "Algoritma Analizi", 4, "Güz", 2, ""));
            dersYonetici.DersEkle(new SecmeliDers("CS202", "Mobil Programlama", 3, "Güz", 7, "2"));

            // Örnek ders kayıtları
            dersKayitYonetici.DersKaydiEkle("2021001", "CS101");
            dersKayitYonetici.DersKaydiEkle("2021001", "CS102");
            dersKayitYonetici.DersKaydiEkle("2021002", "CS101");
            dersKayitYonetici.DersKaydiEkle("2021002", "CS201");
            dersKayitYonetici.DersKaydiEkle("2021003", "CS101");

            // Örnek notlar
            notYonetici.NotEkle(new Not("2021001", "CS101", 85, 90));
            notYonetici.NotEkle(new Not("2021002", "CS101", 78, 82));
            notYonetici.NotEkle(new Not("2021001", "CS102", 92, 88));
        }
    }
}