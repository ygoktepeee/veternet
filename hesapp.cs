using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veternet
{
    public partial class hesapp : Form
    {
        public hesapp()
        {
            InitializeComponent();
        }
        double sayi, sayi2, sonuc;
        string islem;

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "0")
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text += "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text += "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text += "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text += "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text += "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text += "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text += "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text += "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text += "9";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text += "0";
            }
        }

        void sayiYaz1()
        {
            if(textBox1.Text != "")
            {
                sayi = Convert.ToDouble(textBox1.Text);
                label1.Text = sayi.ToString() + islem.ToString();
                textBox1.Text = "";
            }
            else
            {
                label1.Text = "Sayi Bos Bir Deger Alamaz";
            }
            
        }

        void sayiYaz2()
        {
            label1.Text = sayi.ToString() + islem.ToString() + sayi2.ToString() + "=" + sonuc.ToString();
            textBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            islem = "+";
            sayiYaz1();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            islem = "x";
            sayiYaz1();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            islem = "/";
            sayiYaz1();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.Text == "Gecmisi Göster")
            {
                groupBox1.Visible = true;
                this.Size = new Size(448, 362);
                button17.Text = "Gecmisi Gizle";
            }
            else
            {
                groupBox1.Visible = false;
                this.Size = new Size(220, 362);
                button17.Text = "Gecmisi Göster";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            islem = "-";
            sayiYaz1();

        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "") sayi2 = Convert.ToDouble(textBox1.Text);
            else label1.Text = "Sayi Girmediniz...";
            switch (islem)
            {
                case "+":
                    sonuc = sayi + sayi2;
                    sayiYaz2();
                    break;

                case "-":
                    sonuc = sayi - sayi2;
                    sayiYaz2();
                    break;

                case "/":
                    sonuc = sayi / sayi2;
                    sayiYaz2();
                    break;

                case "x":
                    sonuc = sayi * sayi2;
                    sayiYaz2();
                    break;
            }
            listBox1.Items.Add(label1.Text);
        }
    }
}
