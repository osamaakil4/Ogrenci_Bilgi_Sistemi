  using System;

namespace Ogrenci_Bilgi_Sistemi
{

    public class Not
    {
        private string ogrenciNo;
        private string dersKodu;
        private double vize;
        private double final;
        private double ortalama;
        private string harfNotu;
        private double harfNotuPuani; 


        public Not(string ogrenciNo, string dersKodu, double vize, double final )
        {
            this.ogrenciNo = ogrenciNo;
            this.dersKodu = dersKodu;
            this.vize = vize;
            this.final = final;
            HesaplaOrtalama();
            HesaplaHarfNotu();
        }

        public string OgrenciNo
        {
            get { return ogrenciNo; }
            set { ogrenciNo = value; }
        }

        public string DersKodu
        {
            get { return dersKodu; }
            set { dersKodu = value; }
        }

        public double Vize
        {
            get { return vize; }
            set
            {
                vize = value;
               
            }
        }

        public double Final
        {
            get { return final; }
            set
            {
                final = value;
               
            }
        }

        public double Ortalama
        {
            get { return ortalama; }
        }

        public string HarfNotu
        {
            get { return harfNotu; }
        }

        public double HarfNotuPuani
        {
            get { return harfNotuPuani; }
        }

      
        public void HesaplaOrtalama()
        {
            ortalama = vize * 0.4 + final * 0.6;
        }

        public void HesaplaHarfNotu()
        {
            if (ortalama >= 90)
            {
                harfNotu = "AA";
                harfNotuPuani = 4.0;
            }
            else if (ortalama >= 85)
            {
                harfNotu = "BA";
                harfNotuPuani = 3.5;
            }
            else if (ortalama >=75 )
            {
                harfNotu = "BB";
                harfNotuPuani = 3.0;
            }
            else if (ortalama >= 70)
            {
                harfNotu = "CB";
                harfNotuPuani = 2.5;
            }
            else if (ortalama >= 60)
            {
                harfNotu = "CC";
                harfNotuPuani = 2.0;
            }
            else if (ortalama >= 55)
            {
                harfNotu = "DC";
                harfNotuPuani = 1.5;
            }
            else if (ortalama >= 50)
            {
                harfNotu = "DD";
                harfNotuPuani = 1.0;
            }
        
            else
            {
                harfNotu = "FF";
                harfNotuPuani = 0.0;
            }
        }

 
        public string GetInfo()
        {
            return $"{ogrenciNo} - {dersKodu}: Vize={vize}, Final={final}, Ortalama={ortalama:F2}, Harf={harfNotu} ({harfNotuPuani:F1})";
        }

        public bool GectiMi()
        {
            return harfNotu != "FF";
        }

       


    }
}
