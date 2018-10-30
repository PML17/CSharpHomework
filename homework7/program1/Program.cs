using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace program1
{
    class Program
    {
        class Program1
        {
            static void Main(string[] args)
            {
                OrderService.Import("../../MyOrder.xml");
                Menu.OrderMenu();
            }
        }
    }
}
