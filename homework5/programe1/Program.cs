using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
 { 
     class Program
      { 
         class Program1
         { 
             static void Main(string[] args)
             {            
                 OrderService.CreateOrderFromXml("../../Orders.xml"); 
                  Menu.OrderMenu(); 
             } 
         } 
      } 
  } 
