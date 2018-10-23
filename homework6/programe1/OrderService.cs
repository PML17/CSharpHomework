using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace programe1
{
    [Serializable]
    public class OrderService
    {
        public static List<Order> myOrders = new List<Order>();
        public static bool Import(string xmlPath) //从Xml文件导入 
          { 
              try 
              { 
                  using (XmlReader reader = XmlReader.Create(xmlPath)) 
                  { 
                      XmlSerializer xz = new XmlSerializer(myOrders.GetType()); 
                      myOrders = (List<Order>) xz.Deserialize(reader); 
                      Console.WriteLine(reader.ToString()); 
                 } 
                  return true; 
              } 
              catch 
              { 
                  return false; 
              } 
          } 
          public static bool Export(string xmlPath) //导出为xml文件 
          { 
              try 
              { 
                  XmlDocument xd = new XmlDocument(); 
                  using (StringWriter sw = new StringWriter()) 
                  { 
                      XmlSerializer xz = new XmlSerializer(myOrders.GetType()); 
                      xz.Serialize(sw, myOrders); 
                      Console.WriteLine(sw.ToString()); 
                      xd.LoadXml(sw.ToString()); 
                      xd.Save(xmlPath); 
                  } 
                  return true; 
              } 
              catch 
              { 
                  return false; 
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
                        where myOrder.GetAllPrice() > 10000
                        select myOrder;
            foreach (Order order in query)
            {
                Console.WriteLine();
                Console.WriteLine();
                order.ShowOrder();
            }
            return query.Count();
        }
        public static int FindOrderByClientName(string ClientName)     //根据客户名称查找订单，该若无订单返回0，有n订单返回n 
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
            for (int i = 0; i < myOrders.Count; i++)
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
            for (int i = 0; i < myOrders.Count; i++)
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
            for (int i = 0; i < myOrders.Count; i++)
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
            for (int i = 0; i < myOrders.Count; i++)
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
            foreach (Order myOrder in myOrders)
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
            if (i < 0 || i > myOrders.Count)
            {
                return false;
            }
            myOrders[i].ClientName = clientName;
            return true;
        }
        public static bool ChangeOrderProductNum(int flag, int num, int productNum)           //根据位置修改订单条目产品的数目 
        {
            if (flag < 0 || flag > myOrders.Count)
            {
                return false;
            }
            return myOrders[flag].ChangeProductNum(num, productNum);
        }
        public static bool ChangeOrderProduct(int flag, int num, string productName)           //根据位置修改订单条目产品的名字 
        {
            if (flag < 0 || flag > myOrders.Count)
            {
                return false;
            }
            return myOrders[flag].ChangeProduct(num, productName);

        }
        public static bool ChangeOrderProduct(int flag, int num, float productPrice)           //根据位置修改订单条目产品的价格 
        {
            if (flag < 0 || flag > myOrders.Count)
            {
                return false;
            }
            return myOrders[flag].ChangeProduct(num, productPrice);
        }
    }
}
