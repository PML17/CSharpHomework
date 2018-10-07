using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderService
    {
        private static List<Order> myOrders = new List<Order>(); 
  
 
        public static void CreateOrderFromXml(string xmlPath)             
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
                  if(node.HasChildNodes) 
                 { 
                    XmlNode clientNameNode = node.SelectSingleNode("ClientName"); 
                     clientName = clientNameNode.InnerText; 
                     Order tmp = new Order(clientName); 
                     XmlNodeList orderDetailList = node.SelectNodes("OrderDetails"); 
                    foreach(XmlNode node2 in orderDetailList) 
                  { 
                         if(node2.HasChildNodes) 
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
        public static bool AddOrder(Order order)                            
         { 
             if (order == null) 
             { 
                 return false; 
            } 
             myOrders.Add(order); 
            return true; 
         }
        public static int FindOrder(string orderNum) 
         { 
             int i = 0; 
             foreach (Order myOrder in myOrders) 
             { 
               if (myOrder.OrderNum == orderNum) 
                 { 
                     Console.WriteLine(); 
                      Console.WriteLine(); 
                    Console.WriteLine("查找到！"); 
                     myOrder.ShowOrder(); 
                     return i; 
                  } 
                 i++; 
             } 
             return -1; 
          } 
  
 
         public static int FindOrder(DateTime dateTime)
          { 
              int count = 0; 
             foreach (Order myOrder in myOrders) 
             { 
                if (myOrder.OrderDateTime.Day == dateTime.Day 
                     && myOrder.OrderDateTime.Month == dateTime.Month 
                    && myOrder.OrderDateTime.Year == dateTime.Year) 
                 { 
                     myOrder.ShowOrder(); 
                    count++; 
                 } 
              } 
             return count; 
         }
        public static int FindOrderByProductName(string productName)     
          { 
              int count = 0; 
            foreach (Order myOrder in myOrders) 
              { 
                  if(myOrder.HaveProductByName(productName)) 
                  { 
                    myOrder.ShowOrder(); 
                   count++; 
                }                
            }            
            return count; 
        } 
         public static int FindOrderByClientName(string clientName)     
         { 
              int count = 0; 
             foreach (Order myOrder in myOrders) 
              { 
                 if (myOrder.ClientName==clientName) 
                  { 
                     myOrder.ShowOrder(); 
                     count++; 
                } 
             } 
              return count; 
       }

        public static bool DeleteOrder(string orderNum)      
        {
              for(int i=0;i<myOrders.Count;i++) 
             { 
                  if (myOrders[i].OrderNum == orderNum) 
            { 
                     myOrders.RemoveAt(i); 
                    return true; 
                  } 
            } 
             return false; 
       }
        public static bool DeleteOrderByClientName(string clientName)          
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
          public static bool DeleteOrderByProductName(string productName)       
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
        public static bool DeleteOrder(DateTime dateTime)                  
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
          public static void CLearOrders()                         
          { 
              myOrders.Clear(); 
              Console.WriteLine(); 
              Console.WriteLine(); 
             Console.WriteLine("全部清除成功！"); 
        } 
        public static void ShowAllOrders()                      
         { 
             Console.WriteLine(); 
             Console.WriteLine(); 
              if (myOrders.Count==0) 
             { 
                 Console.WriteLine("当前无订单！"); 
                return; 
             } 
             foreach(Order myOrder in myOrders) 
             { 
                 myOrder.ShowOrder(); 
                  Console.WriteLine(); 
             } 
         } 

         public static bool ChangeOrderClientName(int i, string clientName)           
         { 
             if(i<0||i> myOrders.Count) 
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
