using System;
namespace Ogrenci_Bilgi_Sistemi
{
    public abstract class Ders
    {
        protected string kod;
        protected string ad;
        protected int kredi;
        protected int akts; 
        protected string donem;

        // Constructor
        public Ders()
        {
        }

        public Ders(string kod, string ad, int kredi, int akts, string donem)
        {
            this.kod = kod;
            this.ad = ad;
            this.kredi = kredi;
            this.akts = akts;
            this.donem = donem;
        }

        // Properties
        public string Kod
        {
            get { return kod; }
            set { kod = value; }
        }

        public string Ad
        {
            get { return ad; }
            set { ad = value; }
        }

        public int Kredi
        {
            get { return kredi; }
            set { kredi = value; }
        }

        public int Akts
        {
            get { return akts; }
            set { akts = value; }
        }

        public string Donem
        {
            get { return donem; }
            set { donem = value; }
        }

        // Methods
        public string GetKod()
        {
            return kod;
        }

        public string GetAd()
        {
            return ad;
        }

        public int GetKredi()
        {
            return kredi;
        }

        public int GetAkts()
        {
            return akts;
        }

        // Abstract method - Alt sınıflar implement etmeli
        public abstract string GetTuru();

        public virtual string GetInfo()
        {
            return $"{kod} - {ad} ({kredi} kredi, {akts} AKTS) - {GetTuru()}";
        }
    }
}
