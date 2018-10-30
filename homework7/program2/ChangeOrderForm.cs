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
    public partial class ChangeOrderForm : Form
    {
        public ChangeOrderForm()
        {
            InitializeComponent();
            label5.Text = Form1.S.GetText();   //接收所选订单的订单号 
            19          } 
 
 
          private void button1_Click(object sender, EventArgs e)
        { 
             if (textBox1.Text != "" && textBox1.Text != null) 
              { 
                 int i = OrderService.LocatedOrder(label5.Text); 
                 if(i!=-1) 
                 { 
                      if (OrderService.ChangeOrderClientName(i, textBox1.Text)) 
                     { 
                        MessageBox.Show("修改成功!"); 
                         return; 
                    } 
                } 
                MessageBox.Show("输入错误!"); 
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
              Close(); 
          } 

    }
}
