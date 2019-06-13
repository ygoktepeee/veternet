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
    public partial class stok : Form
    {
        public stok()
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
            textBox1.Focus();
        }

        private void stok_Load(object sender, EventArgs e)
        {
            this.stockTableAdapter3.Fill(this.veternetDataSet15.stock);
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commandinsert = new SqlCommand("insert into stock(product_barcode,product_name,product_stock,product_image) values(@i1,@i2,@i3,@i4)", connection);
            commandinsert.Parameters.AddWithValue("@i1", textBox1.Text);
            commandinsert.Parameters.AddWithValue("@i2", textBox2.Text);
            commandinsert.Parameters.AddWithValue("@i3", textBox3.Text);
            commandinsert.Parameters.AddWithValue("@i4", textBox4.Text);
            commandinsert.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Eklendi");
            this.stockTableAdapter3.Fill(this.veternetDataSet15.stock);

        }

        private void button3_Click(object sender, EventArgs e)
        {



            connection.Open();
            SqlCommand commandupdate = new SqlCommand("Update stock Set product_name=@u2,product_stock=@u3,product_image=@u4,product_barcode=@u1 where product_id=@u5", connection);
            commandupdate.Parameters.AddWithValue("@u1", textBox1.Text);
            commandupdate.Parameters.AddWithValue("@u2", textBox2.Text);
            commandupdate.Parameters.AddWithValue("@u3", textBox3.Text);
            commandupdate.Parameters.AddWithValue("@u4", textBox4.Text);
            commandupdate.Parameters.AddWithValue("@u5", textBox5.Text);

            commandupdate.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Güncellendi");
            this.stockTableAdapter3.Fill(this.veternetDataSet15.stock);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            clean();

        }

        private void button6_Click(object sender, EventArgs e)
        {



            connection.Open();
            SqlCommand commanddelete = new SqlCommand("DELETE From stock Where product_id=@d1", connection);
            commanddelete.Parameters.AddWithValue("@d1", textBox5.Text);
            commanddelete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Silindi");
            this.stockTableAdapter3.Fill(this.veternetDataSet15.stock);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
            textBox4.Text = openFileDialog1.FileName;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choose = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[choose].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[choose].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[choose].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[choose].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[choose].Cells[4].Value.ToString();


            pictureBox2.ImageLocation = dataGridView1.Rows[choose].Cells[3].Value.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
    }

