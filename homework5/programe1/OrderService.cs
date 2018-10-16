using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programe1
{
    class OrderService
    {
        private static List<Order> myOrders = new List<Order>(); 
  
 
         public static void CreateOrderFromXml(string xmlPath)               //从Xml文件创建 
         { 
              string clientName = null; 
              int productNum = 0; 
             string productName = null; 
             float productPrice = 0; 
             XmlDocument xml = new XmlDocument(); 
             xml.Load(xmlPath); 
             XmlNode rootNode = xml.SelectSingleNode("OrderService"); 
             XmlNodeList orderList = rootNode.ChildNodes; 
              foreach (XmlNode node in orderList) 
             { 
                  if (node.HasChildNodes) 
                 { 
                     XmlNode clientNameNode = node.SelectSingleNode("ClientName"); 
                      clientName = clientNameNode.InnerText; 
                      Order tmp = new Order(clientName); 
                      XmlNodeList orderDetailList = node.SelectNodes("OrderDetails"); 
                      foreach (XmlNode node2 in orderDetailList) 
                     { 
                         if (node2.HasChildNodes) 
                         { 
                              XmlNode productNumNode = node2.SelectSingleNode("ProductNum"); 
                             productNum = int.Parse(productNumNode.InnerText); 
                             XmlNode productNameNode = node2.SelectSingleNode("ProductName"); 
                             productName = productNameNode.InnerText; 
                             XmlNode productPriceNode = node2.SelectSingleNode("ProductPrice"); 
                              productPrice = float.Parse(productPriceNode.InnerText); 
                             tmp.AddOrderDetails(productNum, productName, productPrice); 
                          } 
  
 
                      } 
                     myOrders.Add(tmp); 
                  } 
             } 
          } 
          public static bool AddOrder(Order order)                            //添加订单 
         { 
             if (order == null) 
              { 
                 return false; 
              } 
              myOrders.Add(order); 
              return true; 
          } 
  
 
          public static int FindOrder(string orderNum) //根据流水号查找是否有订单若无订单返回0，有n订单返回n 
          {           
             var query = myOrders 
                       .Where(myOder => myOder.OrderNum == orderNum); 
              foreach (Order order in query) 
              { 
                  Console.WriteLine(); 
                  Console.WriteLine(); 
                  order.ShowOrder(); 
              } 
              return query.Count(); 
          } 
 
 
         public static int FindOrder(DateTime dateTime)//根据日期查找订单，该日期若无订单返回0，有n订单返回n 
          { 
                    var query = from myOrder in myOrders 
                        where myOrder.OrderDateTime.Day == dateTime.Day 
                        where myOrder.OrderDateTime.Month == dateTime.Month 
                         where myOrder.OrderDateTime.Year == dateTime.Year 
                        select myOrder; 
             foreach (Order order in query) 
              { 
                  Console.WriteLine(); 
                  Console.WriteLine(); 
                  order.ShowOrder(); 
              } 
             return query.Count(); 
          } 
           
         public static int FindOrderByProductName(string productName)     //根据商品名称查找订单，该若无订单返回0，有n订单返回n 
         {            
           var query = from myOrder in myOrders 
           where myOrder.HaveProductByName(productName) 
           select myOrder; 
             foreach (Order order in query) 
            { 
                  Console.WriteLine(); 
                Console.WriteLine(); 
                  order.ShowOrder(); 
              } 
              return query.Count(); 
          } 
  
 
          public static int FindOrderBySumPrice()     //查找订单金额大于10000的订单 
          { 
              var query = from myOrder in myOrders 
           where myOrder.GetAllPrice()>10000 
          select myOrder; 
              foreach (Order order in query) 
              { 
                 Console.WriteLine(); 
                  Console.WriteLine(); 
                 order.ShowOrder(); 
              } 
              return query.Count(); 
          } 
          public static int FindOrderByClientName(string clientName)     //根据客户名称查找订单，该若无订单返回0，有n订单返回n 
       { 
              var query = myOrders 
         .Where(myOder => myOder.ClientName == ClientName); 
          foreach (Order order in query) 
              { 
                  Console.WriteLine(); 
                 Console.WriteLine(); 
                  order.ShowOrder(); 
             } 
             return query.Count(); 
         } 
           
        public static bool DeleteOrder(string orderNum)       //根据订单流水号删除订单 
         { 
             for (int i = 0; i<myOrders.Count; i++) 
              { 
                  if (myOrders[i].OrderNum == orderNum) 
                 { 
                     myOrders.RemoveAt(i); 
                      return true; 
                  } 
             } 
             return false; 
         } 
          
          public static bool DeleteOrderByClientName(string clientName)  //根据客户名称删除订单 
          { 
              bool isTrue = false; 
          for (int i = 0; i<myOrders.Count; i++) 
            { 
                  if (myOrders[i].ClientName == clientName) 
               { 
                      myOrders.RemoveAt(i); 
                     i--; 
                     isTrue = true; 
                  } 
              } 
             return isTrue; 
         } 
        public static bool DeleteOrderByProductName(string productName)       //包含有商品名称则删除该订单 
          { 
              bool isTrue = false; 
              for (int i = 0; i<myOrders.Count; i++) 
           { 
                 if (myOrders[i].HaveProductByName(productName)) 
                { 
                      myOrders.RemoveAt(i); 
                      i--; 
                     isTrue = true; 
                 } 
             } 
             return isTrue; 
         } 
         public static bool DeleteOrder(DateTime dateTime)                   //根据日期删除订单 
          { 
             bool isTrue = false; 
              for (int i = 0; i<myOrders.Count; i++) 
              { 
                 if (myOrders[i].OrderDateTime.Day == dateTime.Day 
                     && myOrders[i].OrderDateTime.Month == dateTime.Month 
                     && myOrders[i].OrderDateTime.Year == dateTime.Year) 
                 { 
                      myOrders.RemoveAt(i); 
                      i--; 
                      isTrue = true; 
                 } 
             } 
             return isTrue; 
         } 
         public static void CLearOrders()                        //清除所有订单 
        { 
              myOrders.Clear(); 
             Console.WriteLine(); 
              Console.WriteLine(); 
             Console.WriteLine("全部清除成功！"); 
          } 
         public static void ShowAllOrders()                      //显示所有订单 
        { 
              Console.WriteLine(); 
            Console.WriteLine(); 
            if (myOrders.Count == 0) 
                { 
                 Console.WriteLine("当前无订单！"); 
                  return; 
             } 
           foreach (Order myOrder in myOrders) 
              { 
                  myOrder.ShowOrder(); 
                Console.WriteLine(); 
              } 
          } 

          public static int LocatedOrder(string orderNum)         //根据流水号定位订单,若无则返回-1 
          { 
              int count = 0; 
             foreach(Order myOrder in myOrders) 
              { 
                  if (myOrder.OrderNum == orderNum) 
                 { 
                      myOrder.ShowOrder(); 
                     return count; 
                  } 
                  count++;     
             } 
             return -1; 
         } 
         public static bool ChangeOrderClientName(int i, string clientName)           //根据位置修改对应订单的客户名称 
        { 
             if (i< 0 || i> myOrders.Count) 
             { 
                  return false; 
             } 
             myOrders[i].ClientName = clientName; 
             return true; 
          } 
         public static bool ChangeOrderProductNum(int flag, int num, int productNum)           //根据位置修改订单条目产品的数目 
          { 
            if (flag< 0 || flag> myOrders.Count) 
              { 
                return false; 
             } 
              return myOrders[flag].ChangeProductNum(num, productNum); 
          } 
          public static bool ChangeOrderProduct(int flag, int num, string productName)           //根据位置修改订单条目产品的名字 
         { 
              if (flag< 0 || flag> myOrders.Count) 
              { 
                  return false; 
             } 
             return myOrders[flag].ChangeProduct(num, productName); 

         } 
          public static bool ChangeOrderProduct(int flag, int num, float productPrice)           //根据位置修改订单条目产品的价格 
         { 
              if (flag< 0 || flag> myOrders.Count) 
              { 
                  return false; 
              } 
              return myOrders[flag].ChangeProduct(num, productPrice); 
          } 
    }
}
