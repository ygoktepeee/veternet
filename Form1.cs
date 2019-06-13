using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Veternet
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                Thread t = new Thread(new ThreadStart(SplashScreen));
                t.Start();
                Thread.Sleep(5000);
                InitializeComponent();
                t.Abort();
            }
            catch (Exception)
            {

                return;
            }

        }
        public void SplashScreen()
        {
            try
            {
                Application.Run(new SplashScreen());
            }
            catch (Exception)
            {

                return;
            }
            
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");


        private void button2_Click(object sender, EventArgs e)
        {
            bring();
            connection.Open();
            SqlCommand command = new SqlCommand("select * from p_user where user_name='" + textBox1.Text + "' and password ='" + textBox2.Text + "'", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                Form2 form2 = new Form2();
                form2.kulid = dataReader["id"].ToString();
                this.Visible = false;
                form2.Show();
                


            }
            else
            {
                MessageBox.Show("Kullanici Adi Veya Sifre Yanlis");
            }
            connection.Close();
        }
        public static string name;
        public static string surname;
        public static string id;
    private void bring()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select id , name , surname from p_user where user_name='" + textBox1.Text + "' and password='" + textBox2.Text + "'", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                id = dataReader[0].ToString();
                name = dataReader[1].ToString();
                surname = dataReader[2].ToString();
            }
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["Form1"] == null)
                {
                    Form1 form = new Form1();
                    form.ShowDialog();
                }
                else
                {
                    Application.OpenForms["Form1"].Activate();
                }
            }
            catch (Exception)
            {

                return;
            }

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sifremi_unuttum sifremi_unuttum = new sifremi_unuttum();
            sifremi_unuttum.Show();


        }
        Point İlkkonum; // Bu değişkenler Global olarak tanımlanmalı.
        bool durum = false;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Mouse a tıklandığı anda. Burada sol yada sağ tıklanması farketmeyecektir.
            durum = true;
            this.Cursor = Cursors.SizeAll; // Fareyi taşıma şeklinde seçim yapılmış ikon halini almasını sağladık.
            İlkkonum = e.Location; /* İlk konum olarak fareye tam basıldığında e parametresinin Location özelliğini
                                    * kullanarak konum aldık. X ve Y koordinatlarını almış olduk.*/
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Mouse'u hareket ettirdiğimizde çalışacak kodlar.
            if (durum)
            {
                this.Left = e.X + this.Left - (İlkkonum.X);
                this.Top = e.Y + this.Top - (İlkkonum.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Mouse'u bıraktığımızda çalışacak kodlar.
            durum = false;
            this.Cursor = Cursors.Default; // Fare işaretçisi Default halini aldı.
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Mouse a tıklandığı anda. Burada sol yada sağ tıklanması farketmeyecektir.
            durum = true;
            this.Cursor = Cursors.SizeAll; // Fareyi taşıma şeklinde seçim yapılmış ikon halini almasını sağladık.
            İlkkonum = e.Location; /* İlk konum olarak fareye tam basıldığında e parametresinin Location özelliğini
                                    * kullanarak konum aldık. X ve Y koordinatlarını almış olduk.*/
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // Mouse'u hareket ettirdiğimizde çalışacak kodlar.
            if (durum)
            {
                this.Left = e.X + this.Left - (İlkkonum.X);
                this.Top = e.Y + this.Top - (İlkkonum.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            // Mouse'u bıraktığımızda çalışacak kodlar.
            durum = false;
            this.Cursor = Cursors.Default; // Fare işaretçisi Default halini aldı.
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
