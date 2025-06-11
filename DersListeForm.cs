using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_Bilgi_Sistemi
{
    public partial class DersListeForm : Form
    {
        private DersYonetici dersYonetici;
        private DataGridView dgvDersler;
        private TextBox txtArama;
        private ComboBox cmbDonem;
        private ComboBox cmbTur;

        public DersListeForm(DersYonetici dersYonetici)
        {
            this.dersYonetici = dersYonetici;
            InitializeComponent();
            DersleriYukle();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form özellikleri
            this.Text = "Ders Listesi";
            this.Size = new System.Drawing.Size(900, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(900, 650);

            // Başlık
            Label lblBaslik = new Label();
            lblBaslik.Text = "DERS LİSTESİ";
            lblBaslik.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            lblBaslik.Location = new System.Drawing.Point(350, 20);
            lblBaslik.Size = new System.Drawing.Size(200, 25);
            lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(lblBaslik);

            // Arama kutusu
            Label lblArama = new Label();
            lblArama.Text = "Arama (Kod veya Ad):";
            lblArama.Location = new System.Drawing.Point(30, 60);
            lblArama.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(lblArama);

            txtArama = new TextBox();
            txtArama.Location = new System.Drawing.Point(150, 60);
            txtArama.Size = new System.Drawing.Size(150, 20);
            txtArama.TextChanged += TxtArama_TextChanged;
            this.Controls.Add(txtArama);

            // Dönem filtresi
            Label lblDonem = new Label();
            lblDonem.Text = "Dönem:";
            lblDonem.Location = new System.Drawing.Point(320, 60);
            lblDonem.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(lblDonem);

            cmbDonem = new ComboBox();
            cmbDonem.Location = new System.Drawing.Point(370, 60);
            cmbDonem.Size = new System.Drawing.Size(100, 20);
            cmbDonem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDonem.Items.AddRange(new string[] { "Tümü", "Güz", "Bahar", "Yaz" });
            cmbDonem.SelectedIndex = 0;
            cmbDonem.SelectedIndexChanged += CmbDonem_SelectedIndexChanged;
            this.Controls.Add(cmbDonem);

            // Ders türü filtresi
            Label lblTur = new Label();
            lblTur.Text = "Tür:";
            lblTur.Location = new System.Drawing.Point(490, 60);
            lblTur.Size = new System.Drawing.Size(30, 20);
            this.Controls.Add(lblTur);

            cmbTur = new ComboBox();
            cmbTur.Location = new System.Drawing.Point(520, 60);
            cmbTur.Size = new System.Drawing.Size(100, 20);
            cmbTur.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTur.Items.AddRange(new string[] { "Tümü", "Zorunlu", "Seçmeli" });
            cmbTur.SelectedIndex = 0;
            cmbTur.SelectedIndexChanged += CmbTur_SelectedIndexChanged;
            this.Controls.Add(cmbTur);

            Button btnYenile = new Button();
            btnYenile.Text = "Yenile";
            btnYenile.Location = new System.Drawing.Point(640, 58);
            btnYenile.Size = new System.Drawing.Size(80, 25);
            btnYenile.BackColor = System.Drawing.Color.DodgerBlue;
            btnYenile.ForeColor = System.Drawing.Color.White;
            btnYenile.Click += BtnYenile_Click;
            this.Controls.Add(btnYenile);

            // DataGridView
            dgvDersler = new DataGridView();
            dgvDersler.Location = new System.Drawing.Point(30, 100);
            dgvDersler.Size = new System.Drawing.Size(820, 450);
            dgvDersler.AllowUserToAddRows = false;
            dgvDersler.AllowUserToDeleteRows = false;
            dgvDersler.ReadOnly = true;
            dgvDersler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDersler.MultiSelect = false;
            dgvDersler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDersler.RowHeadersVisible = false;
            dgvDersler.BackgroundColor = System.Drawing.Color.White;
            dgvDersler.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(dgvDersler);

            // Toplam sayı bilgisi
            Label lblToplam = new Label();
            lblToplam.Name = "lblToplam";
            lblToplam.Text = "Toplam Ders: 0";
            lblToplam.Location = new System.Drawing.Point(30, 570);
            lblToplam.Size = new System.Drawing.Size(200, 20);
            lblToplam.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.Controls.Add(lblToplam);

            // Kredi toplamı bilgisi
            Label lblToplamKredi = new Label();
            lblToplamKredi.Name = "lblToplamKredi";
            lblToplamKredi.Text = "Toplam Kredi: 0";
            lblToplamKredi.Location = new System.Drawing.Point(250, 570);
            lblToplamKredi.Size = new System.Drawing.Size(200, 20);
            lblToplamKredi.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.Controls.Add(lblToplamKredi);

            // Butonlar
            Button btnDetay = new Button();
            btnDetay.Text = "Ders Detayı";
            btnDetay.Location = new System.Drawing.Point(630, 568);
            btnDetay.Size = new System.Drawing.Size(100, 30);
            btnDetay.BackColor = System.Drawing.Color.Green;
            btnDetay.ForeColor = System.Drawing.Color.White;
            btnDetay.Click += BtnDetay_Click;
            this.Controls.Add(btnDetay);

            Button btnKapat = new Button();
            btnKapat.Text = "Kapat";
            btnKapat.Location = new System.Drawing.Point(750, 568);
            btnKapat.Size = new System.Drawing.Size(80, 30);
            btnKapat.BackColor = System.Drawing.Color.IndianRed;
            btnKapat.ForeColor = System.Drawing.Color.White;
            btnKapat.Click += BtnKapat_Click;
            this.Controls.Add(btnKapat);

            this.ResumeLayout(false);
        }

        private void DersleriYukle()
        {
            var dersler = dersYonetici.TumDersler();
            FiltrelenmisListeyiGoster(dersler);
        }

        private void FiltrelenmisListeyiGoster(List<Ders> dersler)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Ders Kodu", typeof(string));
            dt.Columns.Add("Ders Adı", typeof(string));
            dt.Columns.Add("Kredi", typeof(int));
            dt.Columns.Add("Dönem", typeof(string));
            dt.Columns.Add("Tür", typeof(string));

            int toplamKredi = 0;

            foreach (var ders in dersler)
            {
                string dersTuru = (ders is ZorunluDers) ? "Zorunlu" : "Seçmeli";
                dt.Rows.Add(ders.Kod, ders.Ad, ders.Kredi, ders.Donem, dersTuru);
                toplamKredi += ders.Kredi;
            }

            dgvDersler.DataSource = dt;

            // Toplam sayı ve krediyi güncelle
            var lblToplam = this.Controls.Find("lblToplam", true)[0] as Label;
            if (lblToplam != null)
            {
                lblToplam.Text = $"Toplam Ders: {dersler.Count}";
            }

            var lblToplamKredi = this.Controls.Find("lblToplamKredi", true)[0] as Label;
            if (lblToplamKredi != null)
            {
                lblToplamKredi.Text = $"Toplam Kredi: {toplamKredi}";
            }
        }

        private List<Ders> FiltreleriUygula()
        {
            var dersler = dersYonetici.TumDersler();
            string aramaMetni = txtArama.Text.ToLower();

            // Arama filtresi
            if (!string.IsNullOrWhiteSpace(aramaMetni))
            {
                dersler = dersler.Where(d => d.Kod.ToLower().Contains(aramaMetni) ||
                                           d.Ad.ToLower().Contains(aramaMetni))
                               .ToList();
            }

            // Dönem filtresi
            if (cmbDonem.SelectedItem.ToString() != "Tümü")
            {
                dersler = dersler.Where(d => d.Donem == cmbDonem.SelectedItem.ToString()).ToList();
            }

            // Tür filtresi
            if (cmbTur.SelectedItem.ToString() != "Tümü")
            {
                if (cmbTur.SelectedItem.ToString() == "Zorunlu")
                {
                    dersler = dersler.Where(d => d is ZorunluDers).ToList();
                }
                else if (cmbTur.SelectedItem.ToString() == "Seçmeli")
                {
                    dersler = dersler.Where(d => d is SecmeliDers).ToList();
                }
            }

            return dersler;
        }

        private void TxtArama_TextChanged(object sender, EventArgs e)
        {
            var filtrelenmisListe = FiltreleriUygula();
            FiltrelenmisListeyiGoster(filtrelenmisListe);
        }

        private void CmbDonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtrelenmisListe = FiltreleriUygula();
            FiltrelenmisListeyiGoster(filtrelenmisListe);
        }

        private void CmbTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtrelenmisListe = FiltreleriUygula();
            FiltrelenmisListeyiGoster(filtrelenmisListe);
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            txtArama.Text = "";
            cmbDonem.SelectedIndex = 0;
            cmbTur.SelectedIndex = 0;
            DersleriYukle();
        }

        private void BtnDetay_Click(object sender, EventArgs e)
        {
            if (dgvDersler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ders seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dersKodu = dgvDersler.SelectedRows[0].Cells["Ders Kodu"].Value.ToString();
            var ders = dersYonetici.DersBul(dersKodu);

            if (ders != null)
            {
                string dersTuru = (ders is ZorunluDers) ? "Zorunlu Ders" : "Seçmeli Ders";

                string detay = $"DERS DETAY BİLGİLERİ\n\n" +
                              $"Ders Kodu: {ders.Kod}\n" +
                              $"Ders Adı: {ders.Ad}\n" +
                              $"Kredi: {ders.Kredi}\n" +
                              $"Dönem: {ders.Donem}\n" +
                              $"Tür: {dersTuru}\n" +
                              $"Oluşturulma Tarihi: {DateTime.Now.ToString("dd.MM.yyyy")}";

                MessageBox.Show(detay, "Ders Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}