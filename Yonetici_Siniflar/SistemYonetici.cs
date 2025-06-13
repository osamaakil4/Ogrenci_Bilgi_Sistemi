using System;

namespace Ogrenci_Bilgi_Sistemi
{
    public class SistemYonetici
    {
        private OgrenciYonetici ogrenciYonetici;
        private DersYonetici dersYonetici;
        private NotYonetici notYonetici;
        private TranskriptYonetici transkriptYonetici;
        private DersKayitYonetici dersKayitYonetici; 

       
        public OgrenciYonetici OgrenciYoneticisi => ogrenciYonetici;
        public DersYonetici DersYoneticisi => dersYonetici;
        public NotYonetici NotYoneticisi => notYonetici;
        public TranskriptYonetici TranskriptYoneticisi => transkriptYonetici;
        public DersKayitYonetici DersKayitYoneticisi => dersKayitYonetici; 

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
            dersYonetici.DersEkle(new ZorunluDers("CS101", "Programlama Temelleri", 4, 3,"Güz"));
            dersYonetici.DersEkle(new ZorunluDers("CS102", "Veri Yapıları", 3, 5,"Bahar"));
            dersYonetici.DersEkle(new ZorunluDers("CS102", "Veri Yapıları", 3,4, "Bahar"));
            dersYonetici.DersEkle(new SecmeliDers("CS201", "Web Programlama", 3,2, "Bahar"));
            dersYonetici.DersEkle(new ZorunluDers("CS103", "Algoritma Analizi", 4,2, "Güz"));
            dersYonetici.DersEkle(new SecmeliDers("CS202", "Mobil Programlama", 3,  7, "Güz"));

      

      
        }
    }
}