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
    public partial class randevu_ayar : Form
    {
        public randevu_ayar()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5QOG73H;Initial Catalog=Veternet;Integrated Security=True");

        void clean()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            label11.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label13.Text = "";

            textBox2.Focus();
        }


        private void randevu_ayar_Load(object sender, EventArgs e)
        {
            this.pet_saveTableAdapter1.Fill(this.veternetDataSet19.pet_save);

            this.ilcelerTableAdapter.Fill(this.veternetDataSet17.ilceler);
            this.illerTableAdapter.Fill(this.veternetDataSet16.iller);
           

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            label11.Text = dateTimePicker1.Value.ToString();
        }



        

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commandinsert = new SqlCommand("insert into pet_save(pet_name,pet_sex,pet_race,birth_date,weight,province,district,customer_name,customer_surname,image) values(@i2,@i3,@i4,@i5,@i6,@i7,@i8,@i9,@i10,@i11)", connection);
            commandinsert.Parameters.AddWithValue("@i2", textBox2.Text);
            commandinsert.Parameters.AddWithValue("@i3", label13.Text);
            commandinsert.Parameters.AddWithValue("@i4", maskedTextBox1.Text);
            commandinsert.Parameters.AddWithValue("@i5", label11.Text);
            commandinsert.Parameters.AddWithValue("@i6", textBox3.Text.Replace(",","."));
            commandinsert.Parameters.AddWithValue("@i7", comboBox1.Text);
            commandinsert.Parameters.AddWithValue("@i8", comboBox2.Text);
            commandinsert.Parameters.AddWithValue("@i9", textBox4.Text);
            commandinsert.Parameters.AddWithValue("@i10", textBox5.Text);
            commandinsert.Parameters.AddWithValue("@i11", textBox6.Text);

            commandinsert.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Eklendi");
            this.pet_saveTableAdapter1.Fill(this.veternetDataSet19.pet_save);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            clean();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commanddelete = new SqlCommand("DELETE From pet_save Where pet_id=@d1", connection);
            commanddelete.Parameters.AddWithValue("@d1", textBox1.Text);
            commanddelete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Silindi");
            this.pet_saveTableAdapter1.Fill(this.veternetDataSet19.pet_save);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commandupdate = new SqlCommand("Update pet_save Set pet_name=@u1,pet_sex=@u2,pet_race=@u3,birth_date=@u4,weight=@u5,province=@u6,district=@u7,customer_name=@u8,customer_surname=@u9,image=@u10 where pet_id=@u11", connection);
            commandupdate.Parameters.AddWithValue("@u1", textBox2.Text);
            commandupdate.Parameters.AddWithValue("@u2", label13.Text);
            commandupdate.Parameters.AddWithValue("@u3", maskedTextBox1.Text);
            commandupdate.Parameters.AddWithValue("@u4", label11.Text);
            commandupdate.Parameters.AddWithValue("@u5", textBox3.Text);
            commandupdate.Parameters.AddWithValue("@u6", comboBox1.Text);
            commandupdate.Parameters.AddWithValue("@u7", comboBox2.Text);
            commandupdate.Parameters.AddWithValue("@u8", textBox4.Text);
            commandupdate.Parameters.AddWithValue("@u9", textBox5.Text);
            commandupdate.Parameters.AddWithValue("@u10", textBox6.Text);
            commandupdate.Parameters.AddWithValue("@u11", textBox1.Text);
            commandupdate.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Güncellendi");
            this.pet_saveTableAdapter1.Fill(this.veternetDataSet19.pet_save);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox6.Text = openFileDialog1.FileName;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "Erkek";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "Disi";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choose = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[choose].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[choose].Cells[1].Value.ToString();
            label13.Text = dataGridView1.Rows[choose].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[choose].Cells[3].Value.ToString();
            label11.Text = dataGridView1.Rows[choose].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[choose].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[choose].Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[choose].Cells[7].Value.ToString();
            textBox4.Text = dataGridView1.Rows[choose].Cells[8].Value.ToString();
            textBox5.Text = dataGridView1.Rows[choose].Cells[9].Value.ToString();
            textBox6.Text = dataGridView1.Rows[choose].Cells[10].Value.ToString();
            if (label13.Text=="Disi")
            {
                radioButton2.Checked = true;
            }
            if (label13.Text == "Erkek")
            {
                radioButton1.Checked = true;
            }
            
            pictureBox1.ImageLocation = dataGridView1.Rows[choose].Cells[10].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label11.Text = dateTimePicker1.Text;

        }


        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT ilce FROM ilceler where sehir = " + comboBox1.SelectedValue;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["ilce"]);

                }
                connection.Close();
            }
            catch (Exception)
            {

                return;
            }
            


        }

      

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

       
    }
}
