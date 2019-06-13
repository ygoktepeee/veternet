using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Veternet
{
    public partial class sifremi_unuttum : Form
    {
        public sifremi_unuttum()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");
        private string password;

        public bool Gonder(string eposta,string kullaniciadi,string sifre)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("vveternet@gmail.com");
            //
            ePosta.To.Add(eposta);
            

            ePosta.Subject = "Şifre Yenileme";
            ePosta.Body = "Kullanıcı Adınız:"+kullaniciadi+" Şifreniz:"+sifre;

            SmtpClient smtp = new SmtpClient();

            smtp.Credentials = new System.Net.NetworkCredential("vveternet@gmail.com", "11223346Aa");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;

        }

        private void Yolla_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {

                MessageBox.Show("Bos Gecme");
            }
            else
            {


                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("Select * from p_user where  mail='" + textBox2.Text.ToString() + "'", connection);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {

                    password = dataReader["password"].ToString();

                    string kullaniciadi = dataReader["user_name"].ToString();
                    MessageBox.Show("Şifreniz Mail adresinize yollandi");
                    Gonder(textBox2.Text, kullaniciadi, password);
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Eposta sistemimizde kayitli degil");
                }
                connection.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        Point İlkkonum; // Bu değişkenler Global olarak tanımlanmalı.
        bool durum = false;
        private void sifremi_unuttum_MouseDown(object sender, MouseEventArgs e)
        {
            durum = true;
            this.Cursor = Cursors.SizeAll; 
            İlkkonum = e.Location; 
        }

        private void sifremi_unuttum_MouseMove(object sender, MouseEventArgs e)
        {
            if (durum)
            {
                this.Left = e.X + this.Left - (İlkkonum.X);
                this.Top = e.Y + this.Top - (İlkkonum.Y);
            }
        }

        private void sifremi_unuttum_MouseUp(object sender, MouseEventArgs e)
        {
            durum = false;
            this.Cursor = Cursors.Default;
        }
    }
}
