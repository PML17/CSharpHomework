using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using program1;

namespace program2
{
    public partial class OrderAddForm : Form
    {
        public OrderAddForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
                  } 
  
 
          private void button1_Click(object sender, EventArgs e)
          { 
             if (textBox1.Text != "" && textBox1.Text != null) 
            { 
                  if (OrderService.AddOrder(new Order(textBox1.Text))) 
                 { 
                     MessageBox.Show("添加成功!"); 
                } 
                 else 
                 { 
                     MessageBox.Show("输入错误!"); 
                } 
             } 
             else 
              { 
                  MessageBox.Show("输入错误!"); 
             } 
         } 
  
 
         private void button2_Click(object sender, EventArgs e)
         { 
             Form1.S.ReLoad(); 
             this.Close(); 
         } 

        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
