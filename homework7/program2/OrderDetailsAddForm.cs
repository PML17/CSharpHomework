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
    public partial class OrderDetailsAddForm : Form
    {
        DataTable dataTable = null;
        public OrderDetailsAddForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            dataTable = new DataTable("OrderDetails");
            label5.Text = Form1.S.GetText();//获取选择的订单 
            int n = OrderService.LocatedOrder(label5.Text);
            dataTable = Form1.ListToTable(OrderService.myOrders.ElementAt(n).myOrderDetails);//将list转为datatable 
            dataGridView2.DataSource = dataTable;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form1.S.ReLoad();
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "" || textBox1.Text == null) && (textBox2.Text == "" || textBox2.Text == null) && (textBox3.Text == "" || textBox3.Text == null))
            {
                MessageBox.Show("数据为空！");
                return;
            }
            try
            {
                string productName = textBox1.Text;
                float productPrice = float.Parse(textBox2.Text);
                int productNum = int.Parse(textBox3.Text);
                int i = OrderService.LocatedOrder(label5.Text);
                if (OrderService.myOrders.ElementAt(i).AddOrderDetails(productNum, productName, productPrice))
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch
            {
                MessageBox.Show("输入数据格式错误！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            //刷新 
            dataTable.Clear();
            int n = OrderService.LocatedOrder(label5.Text);
            dataTable = Form1.ListToTable(OrderService.myOrders.ElementAt(n).myOrderDetails);//将list转为datatable 
            dataGridView2.DataSource = dataTable;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OrderDetailsAddForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "OrderDetailsAddForm";
            this.Load += new System.EventHandler(this.OrderDetailsAddForm_Load);
            this.ResumeLayout(false);

        }

        private void OrderDetailsAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
