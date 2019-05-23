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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");
        public string kulid;
        private void Form2_Load(object sender, EventArgs e)
        {


            label1.Text = Form1.name.ToString();
            label2.Text = Form1.surname.ToString();
            label15.Text = kulid;

            //connection.Open();
            //string foto = "select photo from p_user where id='" + label15.Text + "'";
            //SqlCommand command= new SqlCommand(foto, connection);
            // SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            // DataTable dataTable = new DataTable();
            // dataAdapter.Fill(dataTable);

            //connection.Close();


            //pictureBox1.ImageLocation = dataTable.Rows[0]["photo"].ToString();

            //connection.Open();

            //SqlCommand selectcommand = new SqlCommand("select photo from p_user where id=" + label15.Text, connection);


            //SqlDataReader dataReader = selectcommand.ExecuteReader();
            //if (dataReader.Read())
            //{
            //    ImagePath = (dataReader["photo"].ToString());
            //}
            //pictureBox1.ImageLocation = dataReader[0].ToString();
            //connection.Close();

            connection.Open();
            string foto = "select photo from p_user where id=" + label15.Text;
            SqlCommand command = new SqlCommand(foto, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
           
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows[0]["photo"].ToString() != "")
            {
                pictureBox1.ImageLocation = dataTable.Rows[0]["photo"].ToString();
            }


            connection.Close();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width = panel2.Width - 5;
            if (panel2.Width == 55)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            
            panel2.Width = panel2.Width + 5;
            if (panel2.Width == 210)
            {
                timer2.Stop();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 210)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.kulid = kulid;
            form2.Show();
            form2.Close();

        }

       

        

        private void button6_Click_2(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Close();

            petler petler = new petler();
            petler.kid = kulid;
            petler.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            randevu randevu = new randevu();
            randevu.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            randevu_ayar randevu_Ayar = new randevu_ayar();
            randevu_Ayar.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            randevu randevu = new randevu();
            randevu.Show();
        }
    }
}

