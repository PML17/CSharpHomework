using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programe2
{
    class Program
    {
        [STAThread] 
          static void Main()
         { 
              Application.EnableVisualStyles(); 
              Application.SetCompatibleTextRenderingDefault(false); 
              Application.Run(new Form1()); 
          }

}
}
