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
    public partial class randevu : Form
    {
        public randevu()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");

        void clean()
        {
            dateTimePicker1.Text = "";
            maskedTextBox1.Text = "";
            richTextBox1.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Focus();
        }


        private void randevu_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'veternetDataSet1.appointment2' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            label5.Text = dateTimePicker1.Value.ToString();
            



        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.Open();
            SqlCommand commandinsert = new SqlCommand("insert into appointment2(date,clock,note) values(@i2,@i3,@i4)", connection);
          
            commandinsert.Parameters.AddWithValue("@i2", label5.Text);
            commandinsert.Parameters.AddWithValue("@i3", maskedTextBox1.Text.ToString());
            commandinsert.Parameters.AddWithValue("@i4", richTextBox1.Text);
            commandinsert.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Randevu Kaydedildi");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.appointment2TableAdapter.Fill(this.veternetDataSet1.appointment2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commanddelete = new SqlCommand("DELETE From appointment2 Where id_ap=@d1", connection);
            commanddelete.Parameters.AddWithValue("@d1", textBox1.Text);
            commanddelete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Randevu Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choose = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[choose].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[choose].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[choose].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[choose].Cells[3].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commandupdate = new SqlCommand("Update appointment2 Set date=@u1,clock=@u2,note=@u3 where id_ap=@u4", connection);
            commandupdate.Parameters.AddWithValue("@u1", label5.Text);
            commandupdate.Parameters.AddWithValue("@u2", maskedTextBox1.Text);
            commandupdate.Parameters.AddWithValue("@u3", richTextBox1.Text);
            commandupdate.Parameters.AddWithValue("@u4", textBox1.Text);
            commandupdate.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Güncellendi");
        }
    }
}
