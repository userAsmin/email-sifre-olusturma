using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Email_ve_Şifre_Kayıt_Etmek
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> kullaniciVerileri = new Dictionary<string, string>();
        public Form1()
        {

            InitializeComponent();

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string KayitMail = txtMail.Text;
            string KayitSifre = txtSifre.Text;
            string[] isaretler = { ".", "?", "_", "%" };
            string[] trkKarakter = { "İ", "ı", "ö", "Ö", "ü", "Ü", "ç", "Ç", "ğ", "Ğ", "ş", "Ş" };


            foreach (char karakter in KayitSifre)
            {
                if (trkKarakter.Contains(karakter.ToString()))
                {
                    MessageBox.Show("Uygun olmayan karakter girdiniz");
                    return;
                }
            }
            foreach (char karakter in KayitSifre)
            {
                if (!char.IsLetterOrDigit(karakter) && !isaretler.Contains(karakter.ToString()))
                {
                    MessageBox.Show("Uygun olmayan karakter girdiniz");
                    return;
                }
            }
            

                if (KayitSifre.Length < 8)
                {
                MessageBox.Show("8 veya daha fazla karakter giriniz");
                }
            if (!kullaniciVerileri.ContainsKey(KayitMail))
            {
                kullaniciVerileri.Add(KayitMail, KayitSifre);
                MessageBox.Show("Hesap başarıyla oluşturuldu!");
            }
            else
            {
                MessageBox.Show("Bu e-posta adresi zaten kayıtlı.");
            }
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string GirisMail = txtGirisMail.Text;
            string GirisSifre = txtGirisSifre.Text;

            if (kullaniciVerileri.ContainsKey(GirisMail) && kullaniciVerileri[GirisMail] == GirisSifre)
            {
                MessageBox.Show("Giriş başarılı!");
            }
            else
            {
                MessageBox.Show("E-posta veya şifre hatalı!");
            }
        }
    }
}


        



