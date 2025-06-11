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
    public partial class TranskriptForm : Form
    {
        private TranskriptYonetici transkriptYonetici;
        private OgrenciYonetici ogrenciYonetici;
        private ComboBox cmbOgrenci;
        private RichTextBox rtbTranskript;

        public TranskriptForm(TranskriptYonetici transkriptYonetici, OgrenciYonetici ogrenciYonetici)
        {
            this.transkriptYonetici = transkriptYonetici;
            this.ogrenciYonetici = ogrenciYonetici;
            InitializeComponent();
            ComboBoxDoldur();
        }

        private void InitializeComponent()
        {
            this.lblBaslik = new Label();
            this.lblOgrenci = new Label();
            cmbOgrenci = new ComboBox();
            this.btnGoster = new Button();
            this.lblTranskript = new Label();
            rtbTranskript = new RichTextBox();
            this.btnYazdir = new Button();
            this.btnKapat = new Button();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblBaslik.Location = new Point(200, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(300, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "TRANSKRİPT GÖRÜNTÜLEME";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOgrenci
            // 
            this.lblOgrenci.Location = new Point(30, 60);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new Size(120, 20);
            this.lblOgrenci.TabIndex = 1;
            this.lblOgrenci.Text = "Öğrenci Seçiniz:";
            // 
            // cmbOgrenci
            // 
            cmbOgrenci.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOgrenci.Location = new Point(160, 60);
            cmbOgrenci.Name = "cmbOgrenci";
            cmbOgrenci.Size = new Size(300, 33);
            cmbOgrenci.TabIndex = 2;
           
            // 
            // btnGoster
            // 
            this.btnGoster.BackColor = Color.DodgerBlue;
            this.btnGoster.ForeColor = Color.White;
            this.btnGoster.Location = new Point(480, 58);
            this.btnGoster.Name = "btnGoster";
            this.btnGoster.Size = new Size(120, 25);
            this.btnGoster.TabIndex = 3;
            this.btnGoster.Text = "Transkript Göster";
            this.btnGoster.UseVisualStyleBackColor = false;
            this.btnGoster.Click += this.BtnGoster_Click;
            // 
            // lblTranskript
            // 
            this.lblTranskript.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.lblTranskript.Location = new Point(30, 100);
            this.lblTranskript.Name = "lblTranskript";
            this.lblTranskript.Size = new Size(100, 20);
            this.lblTranskript.TabIndex = 4;
            this.lblTranskript.Text = "Transkript:";
            // 
            // rtbTranskript
            // 
            rtbTranskript.BackColor = Color.White;
            rtbTranskript.Font = new Font("Courier New", 10F);
            rtbTranskript.Location = new Point(30, 125);
            rtbTranskript.Name = "rtbTranskript";
            rtbTranskript.ReadOnly = true;
            rtbTranskript.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbTranskript.Size = new Size(620, 380);
            rtbTranskript.TabIndex = 5;
            rtbTranskript.Text = "";
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = Color.Gray;
            this.btnYazdir.ForeColor = Color.White;
            this.btnYazdir.Location = new Point(450, 520);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new Size(100, 30);
            this.btnYazdir.TabIndex = 6;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += this.BtnYazdir_Click;
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = Color.IndianRed;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(570, 520);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 30);
            this.btnKapat.TabIndex = 7;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += this.BtnKapat_Click;
            // 
            // TranskriptForm
            // 
            ClientSize = new Size(678, 634);
            Controls.Add(this.lblBaslik);
            Controls.Add(this.lblOgrenci);
            Controls.Add(cmbOgrenci);
            Controls.Add(this.btnGoster);
            Controls.Add(this.lblTranskript);
            Controls.Add(rtbTranskript);
            Controls.Add(this.btnYazdir);
            Controls.Add(this.btnKapat);
            MinimumSize = new Size(700, 600);
            Name = "TranskriptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Transkript Görüntüleme";
            ResumeLayout(false);
        }

        private void ComboBoxDoldur()
        {
            cmbOgrenci.Items.Clear();
            foreach (var ogrenci in ogrenciYonetici.TumOgrenciler())
            {
                cmbOgrenci.Items.Add($"{ogrenci.OgrenciNo} - {ogrenci.Ad} {ogrenci.Soyad}");
            }
        }

        private void BtnGoster_Click(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir öğrenci seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ogrenciNo = cmbOgrenci.Text.Split('-')[0].Trim();
            string transkript = transkriptYonetici.TranskriptOlustur(ogrenciNo);

            if (!string.IsNullOrEmpty(transkript))
            {
                rtbTranskript.Text = transkript;
            }
            else
            {
                rtbTranskript.Text = "Bu öğrenci için transkript oluşturulamadı veya hiç not kaydı bulunamadı.";
            }
        }

        private void BtnYazdir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbTranskript.Text))
            {
                MessageBox.Show("Yazdırılacak transkript bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PrintDialog printDialog = new PrintDialog();
                System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();

                printDocument.PrintPage += (s, ev) =>
                {
                    ev.Graphics.DrawString(rtbTranskript.Text, new Font("Courier New", 10),
                        Brushes.Black, ev.MarginBounds);
                };

                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("Transkript yazdırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yazdırma hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}