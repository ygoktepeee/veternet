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
    public partial class petler : Form
    {
        public petler()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");


        private void button4_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();

            form2.kulid = kid;

            form2.Show();
            this.Hide();

            
        }

        

    private void button1_Click(object sender, EventArgs e)
        {
            petler petler = new petler();
            petler.Close();
            Form3 form3 = new Form3();
            form3.Show();

        }
        public string kid;
        private void petler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'veternetDataSet20.pet_save' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.pet_saveTableAdapter1.Fill(this.veternetDataSet20.pet_save);
            this.pet_saveTableAdapter.Fill(this.veternetDataSet2.pet_save);
            label1.Text = Form1.name.ToString();
            label2.Text = Form1.surname.ToString();

            connection.Open();
            string foto = "select photo from p_user where id=" + kid;
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



        private void button14_Click(object sender, EventArgs e)
        {
            hesapp hesapp = new hesapp();
            hesapp.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            stok stok = new stok();
            stok.Show();
        }
    }
}
