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
    public partial class ChangeOrderDetailForm : Form
    {
        public ChangeOrderDetailForm()
        {
            DataTable dataTable = null;
                  private bool isTrue = false; 
          private bool haveChanged = false;  //用于判断是否有修改，防止直接点击修改键 
         private int i = 0;         //订单在链表中的位置 
         private int j = 0;         //订单条目在链表中的位置 
         private int k = -1;         //所选单元格的列号 
          string valueString = null; //存储单元格的数据 
          public ChangeOrderDetailForm()
          { 
              InitializeComponent(); 
              FormBorderStyle = FormBorderStyle.FixedSingle; 
             dataTable = new DataTable("OrderDetails"); 
            label5.Text = Form1.S.GetText();//获取选择的订单 
            int n = OrderService.LocatedOrder(label5.Text); 
              dataTable = Form1.ListToTable(OrderService.myOrders.ElementAt(n).myOrderDetails);//将list转为datatable 
              dataGridView2.DataSource = dataTable; 
          } 
  
 
         private void button1_Click(object sender, EventArgs e)       //修改 
         { 
              if (!haveChanged) 
                  return; 
              try 
              { 
                if(k==-1) 
                  { 
                      return; 
                 } 
                 else if (k == 0) 
                 { 
                     isTrue = OrderService.ChangeOrderProduct(i, j, valueString);     //修改商品名称 
                  } 
                 else if (k == 1) 
                 { 
                     float value = float.Parse(valueString); 
                    isTrue = OrderService.ChangeOrderProduct(i, j, value);     //修改商品单价 
                 } 
               else if (k == 2) 
                  { 
                     int value = int.Parse(valueString); 
                     isTrue = OrderService.ChangeOrderProductNum(i, j, value);     //修改商品单价 
                 } 
           } 
           catch 
              { 
             } 
              if (isTrue) 
             { 
                  MessageBox.Show("修改成功！"); 
              }else 
              { 
                 MessageBox.Show("修改失败！"); 
            } 
              haveChanged = false;//重置 
          } 
 
 
         private void button2_Click(object sender, EventArgs e)
        { 
             Form1.S.ReLoad(); 
              Close(); 
         } 
 
 
         private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
          { 
              valueString = dataGridView2.CurrentCell.Value.ToString(); 
              if (valueString == "" || valueString == null) 
                  return; 
             i = OrderService.LocatedOrder(label5.Text);   //订单在链表中的位置 
              j = dataGridView2.CurrentCell.RowIndex;       //订单条目在链表中的位置 
              k = dataGridView2.CurrentCell.ColumnIndex;      //所选单元格的列号 
              haveChanged = true; 
          } 
  
 
          private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
         { 
             MessageBox.Show("输入格式不对"); 
              //当输入不合法时复原，先将表清空再导入新表 
              dataTable.Clear(); 
            int n = OrderService.LocatedOrder(label5.Text); 
              dataTable = Form1.ListToTable(OrderService.myOrders.ElementAt(n).myOrderDetails);//将list转为datatable 
            dataGridView2.DataSource = dataTable; 
         }

      
    }
}
