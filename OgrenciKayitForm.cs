using Ogrenci_Bilgi_Sistemi;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace Ogrenci_Bilgi_Sistemi
{
    public partial class OgrenciKayitForm : Form
    {
        private OgrenciYonetici ogrenciYonetici;
        private TextBox txtOgrenciNo;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtEmail;

        public OgrenciKayitForm(OgrenciYonetici ogrenciYonetici)
        {
            this.ogrenciYonetici = ogrenciYonetici;
           InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblBaslik = new Label();
            this.lblOgrenciNo = new Label();
            txtOgrenciNo = new TextBox();
            this.lblAd = new Label();
            txtAd = new TextBox();
            this.lblSoyad = new Label();
            txtSoyad = new TextBox();
            this.lblEmail = new Label();
            txtEmail = new TextBox();
            this.btnKaydet = new Button();
            this.btnIptal = new Button();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblBaslik.Location = new Point(100, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(200, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "YENİ ÖĞRENCİ KAYIT";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOgrenciNo
            // 
            this.lblOgrenciNo.Location = new Point(30, 70);
            this.lblOgrenciNo.Name = "lblOgrenciNo";
            this.lblOgrenciNo.Size = new Size(100, 20);
            this.lblOgrenciNo.TabIndex = 1;
            this.lblOgrenciNo.Text = "Öğrenci No:";
            // 
            // txtOgrenciNo
            // 
            txtOgrenciNo.Location = new Point(140, 70);
            txtOgrenciNo.Name = "txtOgrenciNo";
            txtOgrenciNo.Size = new Size(200, 31);
            txtOgrenciNo.TabIndex = 2;
            // 
            // lblAd
            // 
            this.lblAd.Location = new Point(30, 110);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new Size(100, 20);
            this.lblAd.TabIndex = 3;
            this.lblAd.Text = "Ad:";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(140, 110);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(200, 31);
            txtAd.TabIndex = 4;
            // 
            // lblSoyad
            // 
            this.lblSoyad.Location = new Point(30, 150);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new Size(100, 20);
            this.lblSoyad.TabIndex = 5;
            this.lblSoyad.Text = "Soyad:";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(140, 150);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(200, 31);
            txtSoyad.TabIndex = 6;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new Point(30, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(100, 20);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(140, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 31);
            txtEmail.TabIndex = 8;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = Color.Green;
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.Location = new Point(140, 230);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(80, 30);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += this.BtnKaydet_Click;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = Color.Gray;
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(240, 230);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(80, 30);
            this.btnIptal.TabIndex = 10;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += this.BtnIptal_Click;
            // 
            // OgrenciKayitForm
            // 
            ClientSize = new Size(411, 418);
            Controls.Add(this.lblBaslik);
            Controls.Add(this.lblOgrenciNo);
            Controls.Add(txtOgrenciNo);
            Controls.Add(this.lblAd);
            Controls.Add(txtAd);
            Controls.Add(this.lblSoyad);
            Controls.Add(txtSoyad);
            Controls.Add(this.lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(this.btnKaydet);
            Controls.Add(this.btnIptal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OgrenciKayitForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Yeni Öğrenci Kayıt";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Doğrulama
            if (string.IsNullOrWhiteSpace(txtOgrenciNo.Text))
            {
                MessageBox.Show("Öğrenci numarası boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOgrenciNo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Ad boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAd.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Soyad boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoyad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("E-mail boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            // Öğrenci var mı kontrol et
            if (ogrenciYonetici.OgrenciVarMi(txtOgrenciNo.Text.Trim()))
            {
                MessageBox.Show("Bu öğrenci numarası zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOgrenciNo.Focus();
                return;
            }

            // Öğrenci oluştur ve kaydet
            var yeniOgrenci = new Ogrenci(
                txtOgrenciNo.Text.Trim(),
                txtAd.Text.Trim(),
                txtSoyad.Text.Trim(),
                txtEmail.Text.Trim()
            );

            if (ogrenciYonetici.OgrenciEkle(yeniOgrenci))
            {
                MessageBox.Show("Öğrenci başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Öğrenci kaydedilirken hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}