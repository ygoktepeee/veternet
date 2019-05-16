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
namespace Veternet
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bring();
            connection.Open();
            SqlCommand command = new SqlCommand("select * from p_user where user_name='" + textBox1.Text + "' and password ='" + textBox2.Text + "'", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                Form2 form2 = new Form2();
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
          
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
