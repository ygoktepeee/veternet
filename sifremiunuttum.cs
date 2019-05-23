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
    public partial class sifremiunuttum : Form
    {
        public sifremiunuttum()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("mail@gmail.com");
            //
            ePosta.To.Add(textBox2.Text);

            //
            //ePosta.Attachments.Add(new Attachment(@"C:\deneme.txt"));
            //
            ePosta.Subject = "parola yenile";

            //
            ePosta.Body = "mesaj";
            //
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential("mail@gmail.com", "sifre");
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
        }
    }
    }

