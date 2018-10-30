using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection; 
using program1;


namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
             public static Form1 S = null;      //用于使子窗口调用父窗口 

       public static DataTable ListToTable(List<OrderDetails> orderDetails)
          { 
              Type tp = typeof(OrderDetails); 
              PropertyInfo[] proInfos = tp.GetProperties(); 
            DataTable dt = new DataTable(); 
              foreach (PropertyInfo item in proInfos) 
              { 
                 if(item.Name=="MyProduct") 
                 { 
                      Type tp2 = typeof(Product); 
                      PropertyInfo[] proInfos2 = tp2.GetProperties(); 
                      foreach (PropertyInfo item2 in proInfos2) 
                     { 
                         dt.Columns.Add(item2.Name, item2.PropertyType); //添加列明及对应类型 
                    } 
                 } 
                 else 
                { 
                   dt.Columns.Add(item.Name, item.PropertyType); //添加列明及对应类型 
                  } 
             } 
             foreach (OrderDetails orderdetail in orderDetails) 
              { 
                DataRow dr = dt.NewRow(); 
                 Object obj = null; 
                 foreach (var proInfo in proInfos) 
                 { 
                     if(proInfo.Name=="MyProduct") 
                      { 
                          Type tp2 = typeof(Product); 
                          PropertyInfo[] proInfos2 = tp2.GetProperties(); 
                          foreach (PropertyInfo proInfo2 in proInfos2) 
                          { 
                             obj= proInfo2.GetValue(orderdetail.MyProduct); 
                              if (obj == null) 
                            { 
                                  continue; 
                              } 
                              dr[proInfo2.Name] = obj; 
                        } 
                     } 
                      else 
                      { 
                          obj = proInfo.GetValue(orderdetail); 
                         if (obj == null) 
                         { 
                             continue; 
                        } 
                         dr[proInfo.Name] = proInfo.GetValue(orderdetail); 
                     } 
                 } 
                  dt.Rows.Add(dr); 
             } 
             return dt; 
          } 
          private void SetDataSource()   //为datagridview2设置dataSource 
          { 
             int i = OrderService.LocatedOrder(label1.Text); 
             if(i!=-1) 
              { 
                  dataTable = ListToTable(OrderService.myOrders.ElementAt(i).myOrderDetails);//将list转为datatable 
             } 
              else 
            { 
                 dataTable = new DataTable(); 
                 dataTable.Columns.Add("ProductName"); //添加列 
                  dataTable.Columns.Add("ProductPrice"); //添加列 
                  dataTable.Columns.Add("ProductNum"); //添加列 
              } 
             dataGridView2.DataSource = dataTable; 
         } 
          DataTable dataTable = null; 
         public Form1()
         { 
             InitializeComponent(); 
            FormBorderStyle = FormBorderStyle.FixedSingle; 
             S = this; 
             OrderService.Import("../../../program1/MyOrder.xml"); 
             orderBindingSource.DataSource = OrderService.myOrders; 

             dataTable = new DataTable("OrderDetails"); 
             dataTable = ListToTable(OrderService.myOrders.ElementAt(0).myOrderDetails);//将list转为datatable 
              dataGridView2.DataSource = dataTable;  //指定dataGridView2 
          } 
 
 
          private void button1_Click(object sender, EventArgs e)
         { 
              orderBindingSource.DataSource = OrderService.myOrders; //指定为全部订单 
              SetDataSource();      //刷新dataGridView2 
         } 
  
 
          private void button2_Click(object sender, EventArgs e)  //指定所查询订单 
          { 
              if(textBox1.Text==""||textBox1.Text ==null) 
             { 
                  orderBindingSource.DataSource = new List<Order>(); 
              } 
              else 
             { 
                 try 
                  { 
                     if (radioButton1.Checked == true)                //根据订单号查找 
                     { 
                          orderBindingSource.DataSource = OrderService.FindOrderWindow(textBox1.Text); 
                      } 
                     else if (radioButton2.Checked == true)          //根据日期查找 
                     { 
                         orderBindingSource.DataSource = OrderService.FindOrderWindow(DateTime.ParseExact(textBox1.Text, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)); 
                     } 
                     else if (radioButton3.Checked == true)          //根据客户名称查找 
                      { 
                         orderBindingSource.DataSource = OrderService.FindOrderByClientNameWindow(textBox1.Text); 
                      } 
                      else if (radioButton4.Checked == true)          //根据包含商品名称查找 
                     { 
                          orderBindingSource.DataSource = OrderService.FindOrderByProductNameWindow(textBox1.Text); 
                      } 
                 } 
                 catch 
                 { 
                      orderBindingSource.DataSource = new List<Order>(); 
                 } 
            } 
             SetDataSource();    //刷新dataGridView2 
        } 

 
          private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
          { 
             //为了将订单细节显现（由于details里面包含了一个product对象所有设置datasource时不能兼顾 
              //故采取将表合并为dataTable方式来绑定datagridview 
              SetDataSource(); 
         } 
  
 
         private void button3_Click(object sender, EventArgs e)     //添加订单 
          { 
             OrderAddForm orderAddForm = new OrderAddForm(); 
             orderAddForm.Show(); 
        } 
  
 
          public void ReLoad()           //刷新dataGridView1 
        { 
            orderBindingSource.DataSource = new List<Order>();//重新指定dataGridView1的datasource 
             orderBindingSource.DataSource = OrderService.myOrders;//重新指回原datasource 
              SetDataSource();//刷新dataGridView2 
        } 

 
          private void button5_Click(object sender, EventArgs e)  //删除订单 
        { 
             if (label1.Text == "" || textBox1.Text == null) 
              { 
                 MessageBox.Show("删除失败！"); 
              } 
             else if(MessageBox.Show("确定删除？", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
             { 
                 if(!OrderService.DeleteOrder(label1.Text)) 
                  { 
                      MessageBox.Show("删除失败！"); 
                 } 
                else 
                  { 
                    ReLoad(); 
                  } 
              } 
         } 
          
        public string GetText()        //获取选择订单 
         { 
             return label1.Text; 
         } 
  
 
         private void button8_Click(object sender, EventArgs e)  //删除商品 
          { 
             if (label1.Text == "" || textBox1.Text == null) 
             { 
                 MessageBox.Show("删除失败！"); 
              } 
            else if (MessageBox.Show("确定删除？", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
             { 
                 int i = OrderService.LocatedOrder(label1.Text); 
                  if (i != -1)     //通过流水号锁定订单，-1无此订单 
                 { 
                      string productName = (string)dataGridView2.CurrentRow.Cells[0].Value; 
                      OrderService.DeleteOrderDetails(OrderService.myOrders.ElementAt(i).myOrderDetails, productName); 
                     ReLoad(); 
                 }else 
                { 
                     MessageBox.Show("删除失败！"); 
                  } 
  
 
              } 
        } 
  
 
         private void button4_Click(object sender, EventArgs e) //修改订单 
          { 
             ChangeOrderForm changeOrderForm = new ChangeOrderForm(); 
             changeOrderForm.Show(); 
         } 
 
 
         private void button7_Click(object sender, EventArgs e) //修改商品 
         { 
             ChangeOrderDetailForm changeOrderDetailForm = new ChangeOrderDetailForm(); 
              changeOrderDetailForm.Show(); 
         } 
  
 
          private void button6_Click(object sender, EventArgs e)  //添加商品 
         { 
              OrderDetailsAddForm orderDetailsAddForm = new OrderDetailsAddForm(); 
              orderDetailsAddForm.Show(); 
         } 

    }
}
