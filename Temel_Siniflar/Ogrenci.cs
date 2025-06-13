namespace Ogrenci_Bilgi_Sistemi;

public class Ogrenci
    {
        private string ogrenciNo;
        private string ad;
        private string soyad;
        private string email;
        private DateTime kayitTarihi;

        // Constructor
        public Ogrenci()
        {
            kayitTarihi = DateTime.Now;
        }

        public Ogrenci(string ogrenciNo, string ad, string soyad, string email)
        {
            this.ogrenciNo = ogrenciNo;
            this.ad = ad;
            this.soyad = soyad;
            this.email = email;
            kayitTarihi = DateTime.Now;
        }

        // Properties
        public string OgrenciNo 
        { 
            get { return ogrenciNo; } 
            set { ogrenciNo = value; } 
        }

        public string Ad 
        { 
            get { return ad; } 
            set { ad = value; } 
        }

        public string Soyad 
        { 
            get { return soyad; } 
            set { soyad = value; } 
        }

        public string Email 
        { 
            get { return email; } 
            set { email = value; } 
        }

        public DateTime KayitTarihi 
        { 
            get { return kayitTarihi; } 
            set { kayitTarihi = value; } 
        }

    
        public string TamAd()
        {
            return $"{ad} {soyad}";
        }

        public string GetInfo()
        {
            return $"{ogrenciNo} - {TamAd()} ({email})";
        }
    }
    
