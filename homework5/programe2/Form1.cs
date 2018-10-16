using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        private CayleyTree cayleyTree;
        private Graphics graphic;
        private int x0 = 550;
        private int y0 = 600;
        public Form1()
        {
            InitializeComponent();
            graphic = this.CreateGraphics();
            cayleyTree = new CayleyTree();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cayleyTree.Draw(x0, y0, graphic);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    textBox1.Text = (double.Parse(textBox1.Text) % 91).ToString();
                    cayleyTree.Th1 = double.Parse(textBox1.Text) * Math.PI / 180;
                    this.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!");
                textBox1.Text = "30";
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = (double.Parse(textBox2.Text) % 91).ToString();
                    cayleyTree.Th2 = double.Parse(textBox2.Text) * Math.PI / 180;
                    this.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!");
                textBox2.Text = "20";
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                {
                    cayleyTree.Per1 = double.Parse(textBox3.Text);
                    if (cayleyTree.Per1 > 1)
                    {
                        textBox3.Text = "Error";
                    }
                    this.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!");
                textBox3.Text = "0.6";
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text != "")
                {
                    cayleyTree.Per2 = double.Parse(textBox4.Text);
                    if (cayleyTree.Per2 > 1)
                    {
                        textBox4.Text = "Error";
                    }
                    this.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!");
                textBox4.Text = "0.7";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                {
                    cayleyTree.RootHeight = double.Parse(textBox5.Text);
                    this.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!");
                textBox5.Text = "100";
            }
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text != "")
                {
                    cayleyTree.LayerNum = int.Parse(textBox6.Text);
                    this.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!");
                textBox5.Text = "10";
            }
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text != "")
                {
                    cayleyTree.K = double.Parse(textBox7.Text);
                    this.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!");
                textBox5.Text = "1";
            }
        }
    }
}
