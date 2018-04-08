using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Расчет_зарплаты
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double NDFL;
                int myKredid;
                double matvigoda;
                double vichet;
                double otpusknie;

                double myAvans = double.Parse(textBox2.Text);

                double MyOklad = double.Parse(textBox1.Text);

                double MyISN = double.Parse(textBox4.Text);

                double dinner = double.Parse(textBox5.Text);

                if (checkBox4.Checked == true)
                {
                    otpusknie = double.Parse(textBox12.Text);
                }
                else if (checkBox4.Checked == false)
                {
                    otpusknie = 0;
                }
                else
                {
                    otpusknie = 0;
                }

                if (checkBox1.Checked == true)
                {
                    matvigoda = double.Parse(textBox8.Text);
                }
                else if (checkBox1.Checked == false)
                {
                    matvigoda = 0;
                }
                else
                {
                    matvigoda = 0;
                }

                if (checkBox2.Checked == true)
                {
                    myKredid = int.Parse(textBox3.Text);
                }
                else if (checkBox2.Checked == false)
                {               
                    myKredid = 0;
                }
                else
                {
                    myKredid = 0;
                }

                if (checkBox3.Checked == true)
                {
                    vichet = double.Parse(textBox10.Text);
                }
                else if (checkBox3.Checked == false)
                {
                    vichet = 0;
                }
                else
                {
                    vichet = 0;
                }

                double vsegogry = MyISN + MyOklad + otpusknie;

                NDFL = 0.13 * (vsegogry - vichet);
                matvigoda = 0.35 * matvigoda;
                NDFL = NDFL + matvigoda;

                double vsegochistimi = vsegogry - NDFL - dinner - myKredid - myAvans;

                textBox6.Text = NDFL.ToString();
                textBox7.Text = vsegogry.ToString();
                textBox9.Text = vsegochistimi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //MessageBox.Show(DateTime.Now.ToString().Split('.')[0]);
            if (DateTime.Now.ToString().Split('.')[0] == "1")
            {
                t.MyDinners.Clear();
            }

            label9.Enabled = false;
            textBox3.Enabled = false;
            label3.Enabled = false;
            textBox8.Enabled = false;            
            label10.Enabled = false;
            textBox10.Enabled = false;
            label12.Enabled = false;
            textBox12.Enabled = false;


            //label1.Font = new Font("Введи свой оклад:", 10, FontStyle.Regular);
            //label2.Font = new Font("Введи свой аванс:", 10, FontStyle.Regular);
            //label4.Font = new Font("Введи свой ИСН:", 10, FontStyle.Regular);
            //label5.Font = new Font("Сколько удержано за обеды:", 10, FontStyle.Regular);
            //label3.Font = new Font("Введи мат. выгода по займам:", 10, FontStyle.Regular);
            //label6.Font = new Font("НДФЛ исчисленный:", 10, FontStyle.Regular);
            //label7.Font = new Font("Всего начислено грязными:", 10, FontStyle.Regular);
            //label8.Font = new Font("Всего начислено чистыми:", 10, FontStyle.Regular);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                label3.Enabled = true;
                textBox8.Enabled = true;
            }
            if (checkBox1.Checked == false)
            {
                label3.Enabled = false;
                textBox8.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label9.Enabled = true;
                textBox3.Enabled = true;
            }
            if (checkBox2.Checked == false)
            {
                label9.Enabled = false;
                textBox3.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                label10.Enabled = true;
                textBox10.Enabled = true;
            }
            if (checkBox3.Checked == false)
            {
                label10.Enabled = false;
                textBox10.Enabled = false;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        Sum_Dinner t = new Sum_Dinner();
        private void button2_Click(object sender, EventArgs e)
        {
            t.MyNewDineer = double.Parse(textBox11.Text);
           
            t.MyDinners.Add(t.MyNewDineer);
            BinaryFormatter binFormat = new BinaryFormatter();

            Stream fStream = new FileStream("MyObject.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            binFormat.Serialize(fStream, this.t);
            fStream.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            Stream fStream = File.OpenRead("MyObject.bin");

            this.t = (Sum_Dinner)binFormat.Deserialize(fStream);

            fStream.Close();
            textBox11.Text = t.MyDinners.Sum().ToString();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                label12.Enabled = true;
                textBox12.Enabled = true;
            }
            if (checkBox4.Checked == false)
            {
                label12.Enabled = false;
                textBox12.Enabled = false;
            }
        }
    }
}
