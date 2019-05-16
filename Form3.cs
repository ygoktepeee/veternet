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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");

        void clean()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox2.Focus();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.p_userTableAdapter.Fill(this.veternetDataSet.p_user);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commandinsert = new SqlCommand("insert into p_user(user_name,password,name,surname,photo) values(@i2,@i3,@i4,@i5,@i6)", connection);
            commandinsert.Parameters.AddWithValue("@i2", textBox2.Text);
            commandinsert.Parameters.AddWithValue("@i3", textBox3.Text);
            commandinsert.Parameters.AddWithValue("@i4", textBox4.Text);
            commandinsert.Parameters.AddWithValue("@i5", textBox5.Text);
            commandinsert.Parameters.AddWithValue("@i6", textBox6.Text);
            commandinsert.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Eklendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choose = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[choose].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[choose].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[choose].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[choose].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[choose].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[choose].Cells[5].Value.ToString();

            pictureBox1.ImageLocation = dataGridView1.Rows[choose].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commanddelete = new SqlCommand("DELETE From p_user Where id=@d1", connection);
            commanddelete.Parameters.AddWithValue("@d1", textBox1.Text);
            commanddelete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commandupdate = new SqlCommand("Update p_user Set user_name=@u1,password=@u2,name=@u3,surname=@u4,photo=@u5 where id=@u6", connection);
            commandupdate.Parameters.AddWithValue("@u1", textBox2.Text);
            commandupdate.Parameters.AddWithValue("@u2", textBox3.Text);
            commandupdate.Parameters.AddWithValue("@u3", textBox4.Text);
            commandupdate.Parameters.AddWithValue("@u4", textBox5.Text);
            commandupdate.Parameters.AddWithValue("@u5", textBox6.Text);
            commandupdate.Parameters.AddWithValue("@u6", textBox1.Text);
            commandupdate.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Güncellendi");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox6.Text = openFileDialog1.FileName;

        }
    }
}
