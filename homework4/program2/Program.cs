using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Order order = new Order("Monna", 3, "homework", 5); 
            //OrderService.AddOrder(order); 
            //order = new Order("Monna2", 3, "homework", 5); 
            //OrderService.AddOrder(order); 
            //order = new Order("Monna3", 3, "homework", 5); 
            //OrderService.AddOrder(order); 
            //order = new Order("Monna4", 3, "homework", 5); 
            //OrderService.AddOrder(order); 
            //order = new Order("Monna5", 3, "homework", 5); 
            //OrderService.AddOrder(order); 
            //order = new Order("Monna6", 3, "homework", 5); 
            //OrderService.AddOrder(order); 
            OrderService.CreateOrderFromXml("../../Orders.xml");
            Menu.OrderMenu();
            //OrderService.ShowAllOrders(); 
            //OrderService.DeleteOrder("2018-10-7-4"); 
            //OrderService.ShowAllOrders(); 

        }
    }
}
