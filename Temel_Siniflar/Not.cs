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
        private double harfNotuPuani; // Harf notunun puan karşılığı

        // Constructor
        public Not(string ogrenciNo)
        {
            this.ogrenciNo = ogrenciNo;
        }

        public Not(string ogrenciNo, string dersKodu, double vize, double final )
        {
            this.ogrenciNo = ogrenciNo;
            this.dersKodu = dersKodu;
            this.vize = vize;
            this.final = final;
            HesaplaOrtalama();
            HesaplaHarfNotu();
        }

        // Properties
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
                HesaplaOrtalama();
                HesaplaHarfNotu();
            }
        }

        public double Final
        {
            get { return final; }
            set
            {
                final = value;
                HesaplaOrtalama();
                HesaplaHarfNotu();
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

        // Methods
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
            else if (ortalama >= 80)
            {
                harfNotu = "BB";
                harfNotuPuani = 3.0;
            }
            else if (ortalama >= 75)
            {
                harfNotu = "CB";
                harfNotuPuani = 2.5;
            }
            else if (ortalama >= 70)
            {
                harfNotu = "CC";
                harfNotuPuani = 2.0;
            }
            else if (ortalama >= 65)
            {
                harfNotu = "DC";
                harfNotuPuani = 1.5;
            }
            else if (ortalama >= 60)
            {
                harfNotu = "DD";
                harfNotuPuani = 1.0;
            }
            else if (ortalama >= 50)
            {
                harfNotu = "FD";
                harfNotuPuani = 0.5;
            }
            else
            {
                harfNotu = "FF";
                harfNotuPuani = 0.0;
            }
        }

        public string GetOgrenciNo()
        {
            return ogrenciNo;
        }

        public string GetDersKodu()
        {
            return dersKodu;
        }

        public void SetVize(int vize)
        {
            this.vize = vize;
            HesaplaOrtalama();
            HesaplaHarfNotu();
        }

        public void SetFinal(int final)
        {
            this.final = final;
            HesaplaOrtalama();
            HesaplaHarfNotu();
        }

        public string GetInfo()
        {
            return $"{ogrenciNo} - {dersKodu}: Vize={vize}, Final={final}, Ortalama={ortalama:F2}, Harf={harfNotu} ({harfNotuPuani:F1})";
        }

        // Not geçme kontrolü
        public bool GectiMi()
        {
            return harfNotu != "FF" && harfNotu != "FD";
        }

        // AKTS bazlı not hesaplama için yardımcı metod
        public double AktsBazliPuan(int akts)
        {
            return harfNotuPuani * akts;
        }
    }
}
