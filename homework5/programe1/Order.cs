using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programe1
{
    class Order
    {
        private static int orderCount = 0;                                      //订单数 
         public string OrderNum { get; set; }                                    //订单流水号 
         public DateTime OrderDateTime { get; private set; }                     //订单日期 
         private List<OrderDetails> myOrderDetails = new List<OrderDetails>();                              //订单明细 
          private float AllPrice { get; set; }                                    //总价 
         public string ClientName { get; set; }                                  //客户名称 
  
 
          public Order(string clientName)                                         //构造函数 
         { 
              Order.orderCount++;                         //每有一单就加1 
              OrderDateTime = new DateTime(); 
              OrderDateTime = DateTime.Now;               //初始化订单日期 
              ClientName = clientName;                    //初始化客户名称 
              //生成订单流水号 
              OrderNum = OrderDateTime.Year.ToString() + "-" + OrderDateTime.Month.ToString() + "-" + OrderDateTime.Day.ToString() + "-" + orderCount.ToString(); 
             //初始化订单明细 
             AllPrice = 0; 
          } 
 
 
         public Order(string clientName, int productNum, string productName, float productPrice) : this(clientName) 
          { 
              myOrderDetails.Add(new OrderDetails(productNum, productName, productPrice)); 
              AllPrice = GetAllPrice(); 
          } 
          public bool AddOrderDetails(int productNum, string productName, float productPrice)
          { 
              myOrderDetails.Add(new OrderDetails(productNum, productName, productPrice)); 
              AllPrice = GetAllPrice(); 
              return true; 
          } 
 
 
         public float GetAllPrice()                                  //返回总价 
          { 
              AllPrice = 0; 
             foreach (OrderDetails orderDetails in myOrderDetails) 
             { 
                AllPrice += orderDetails.GetProductPriceSum(); 
             } 
              return AllPrice; 
          } 
          public static int GetOrderCount()                           //返回订单数 
          { 
              return orderCount; 
          } 
         public void ShowOrder()                                     //显示订单 
          { 
              Console.WriteLine("//////////////////////////////////////////"); 
             Console.WriteLine("订单号：" + OrderNum); 
             Console.WriteLine("客户名称：" + ClientName); 
             foreach (OrderDetails orderDetails in myOrderDetails) 
             { 
                 orderDetails.ShowOrderDetails(); 
             } 
             Console.WriteLine("订单金额总计：" + AllPrice); 
             Console.WriteLine("订单日期：" + OrderDateTime); 
         } 

 
          public override bool Equals(object obj)                             //重写Equals 
          { 
              if (obj == null || this.GetType() != obj.GetType())             //为空或类型不同返回false 
             {
                  return false;
             } 
             Order tmp = (Order)obj; 
              if (this.GetAllPrice() != tmp.GetAllPrice() 
                  || this.ClientName != tmp.ClientName 
                 || this.OrderNum != tmp.OrderNum 
                  || this.OrderDateTime != tmp.OrderDateTime 
                 || this.myOrderDetails.Count != tmp.myOrderDetails.Count) 
            {
                 return false;
             } 
              else 
              {
                  for (int i = 0; i < this.myOrderDetails.Count; i++)
                  {
                      if (!this.myOrderDetails.ElementAt(i).Equals(tmp.myOrderDetails.ElementAt(i)))
                      {
                         return false;
                      }
                  }
                 return true;
             } 
          } 
         public override int GetHashCode()                               //重写GetHashCode 
          { 
             return (int) AllPrice; 
          } 
 
 
         public bool HaveProductByName(string productName)               //是否有某一产品(产品名相同即可） 
          { 
              foreach (OrderDetails orderDetails in myOrderDetails) 
              { 
                  if (orderDetails.myProduct.ProductName == productName) 
                  { 
                      return true; 
                  } 
              } 
              return false; 
          } 
  
 
          public bool ChangeProduct(int i, string productName)           //根据位置修改订单条目产品的名字 
          { 
             if (i< 0 || i> myOrderDetails.Count) 
             { 
                 return false; 
             } 
             myOrderDetails[i].myProduct.ProductName = productName; 
              return true; 
         } 
        public bool ChangeProduct(int i, float productPrice)           //根据位置修改订单条目产品的单价 
          { 
              if (i< 0 || i> myOrderDetails.Count) 
              { 
                 return false; 
             } 
             myOrderDetails[i].myProduct.ProductPrice = productPrice; 
              return true; 
         } 
 
 
          public bool ChangeProductNum(int i, int productNum)             //根据位置修改订单条目产品的数目 
          { 
            if (i< 0 || i> myOrderDetails.Count) 
              { 
                  return false; 
             } 
              myOrderDetails[i].ProductNum = productNum; 
              return true; 
          } 

    }
}
