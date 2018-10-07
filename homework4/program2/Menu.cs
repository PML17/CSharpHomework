using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Menu
    {
        public static void Choose(ref int f, int i, int j)         
          { 
              while (true) 
             { 
               try 
              { 
                     Console.Write("请输入："); 
                      f = int.Parse(Console.ReadLine()); 
                      if (f >= i && f <= j) 
                      { 
                          break; 
                      } 
                      else 
                     { 
                       Console.WriteLine("请重新输入！ "); 
                      } 
                  } 
                  catch 
                  { 
                      Console.WriteLine("请重新输入！ "); 
                  } 
  
 
             } 
          } 
          public static void OrderMenu()
          { 
              while (true) 
              { 
                  Console.WriteLine(); 
                 Console.WriteLine(); 
                 Console.WriteLine("************************订单管理系统************************"); 
                  Console.WriteLine("此系统含有订单，可修改Xml文件来修改订单或批量添加订单"); 
                 Console.WriteLine("         1.添加订单                      2.删除订单  "); 
                 Console.WriteLine("         3.修改订单                      4.查找订单  "); 
                  Console.WriteLine("         5.清空所有订单                  6.显示订单"); 
                  Console.WriteLine("         7.退出"); 
                  int choose = 0; 
                  Choose(ref choose, 1, 8); 
                 switch (choose) 
                 { 
                      case 1: 
                          AddOrder(); 
                         break; 
                      case 2: 
                         DeleteOrder(); 
                          break; 
                      case 3: 
                         ChangeOrder(); 
                          break; 
                      case 4: 
                         FindOrder(); 
                          break; 
                      case 5: 
                          OrderService.CLearOrders(); 
                          break; 
                     case 6: 
                          OrderService.ShowAllOrders(); 
                         break; 
                      case 7: 
                         return;      
                 } 
             } 
 
 
         }   
 
          public static void AddOrder()
          { 
              string clientName = null; 
              int productNum = 0; 
              string productName = null; 
              float productPrice = 0; 
              while (true) 
              { 
                  try 
                  { 
                    Console.WriteLine(); 
                      Console.WriteLine(); 
                      Console.WriteLine("**************************添加订单**************************"); 
                     Console.WriteLine("             1.继续                      2.返回主页"); 
                     int choose = 0; 
                      Choose(ref choose, 1, 2); 
                      if (choose == 2) 
                      { 
                          return;              //返回主页 
                      } 
                      else 
                     { 
                          Console.Write("请输入客户名称："); 
                         clientName = Console.ReadLine(); 
                          Order tmp = new Order(clientName); 
                          while (true) 
                          { 
                              Console.WriteLine("---------添加商品---------"); 
                              Console.Write("请输入商品名称："); 
                              productName = Console.ReadLine(); 
                              Console.Write("请输入商品数量："); 
                              productNum = int.Parse(Console.ReadLine()); 
                              Console.Write("请输入商品单价："); 
                              productPrice = float.Parse(Console.ReadLine()); 
                              if (tmp.AddOrderDetails(productNum, productName, productPrice)) 
                              { 
                                  Console.WriteLine("添加商品成功！"); 
                              } 
                              Console.Write("是否继续添加商品（1：继续；0：返回添加订单页面）："); 
                             int flag = 0; 
                              Choose(ref flag, 0, 1); 
                            if (flag == 0) 
                             { 
                                 break; 
                              } 
                             else if (flag != 1) 
                           { 
                                 Console.WriteLine(); 
                                  Console.WriteLine(); 
                                  Console.WriteLine("输入错误，退出当前"); 
                                  break;
                            } 
                         } 
                          if (OrderService.AddOrder(tmp)) 
                        { 
                             Console.WriteLine(); 
                            Console.WriteLine(); 
                             Console.WriteLine("添加订单成功！"); 
                          } 
                     } 
                } 
                 catch (Exception e) 
                { 
                      Console.WriteLine(e.Message); 
                    Console.WriteLine("失败，请重试！"); 
                 } 
              } 
        } 
 
 
         public static void DeleteOrder()
         { 
             while (true) 
              { 
                 try 
                 { 
                    Console.WriteLine(); 
                     Console.WriteLine(); 
                  Console.WriteLine("**************************删除订单**************************"); 
                     Console.WriteLine("1.根据流水号删除               2.删除某天对应所有订单"); 
                    Console.WriteLine("3.根据客户名删除对应所有订单   4.根据商品名称删除对应所有订单"); 
                      Console.WriteLine("5.返回主页"); 
                      int choose = 0; 
                      Choose(ref choose, 1, 5); 
                     bool haveDeleted = true; 
                    switch (choose) 
                    { 
                         case 1: 
                             Console.Write("请输入流水号（格式：2018-1-1-1）："); 
                             haveDeleted = OrderService.DeleteOrder(Console.ReadLine()); 
                             break; 
                       case 2: 
                            Console.Write("请输入日期（格式：20180101）："); 
                          haveDeleted = OrderService.DeleteOrder(DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)); 
                             break; 
                          case 3: 
                              Console.Write("请输入客户名称："); 
                           haveDeleted = OrderService.DeleteOrderByClientName(Console.ReadLine()); 
                            break; 
                        case 4: 
                             Console.Write("请输入商品名称："); 
                             haveDeleted = OrderService.DeleteOrderByProductName(Console.ReadLine()); 
                           break; 
                        case 5: 
                            return;          //返回主页 
                    } 
                   if (haveDeleted) 
                     { 
                      Console.WriteLine(); 
                       Console.WriteLine(); 
                        Console.WriteLine("删除成功！"); 
                      } 
                    else 
                    { 
                        Console.WriteLine(); 
                          Console.WriteLine(); 
                         Console.WriteLine("删除失败！"); 
                    } 
                } 
                 catch (Exception e) 
            { 
                 Console.WriteLine(); 
                     Console.WriteLine(); 
               Console.WriteLine(e.Message); 
                    Console.WriteLine("失败，请重试！"); 
               } 
            } 
        } 
 
 
          public static void FindOrder()
          { 
             while (true) 
              { 
                  try 
                  { 
                      Console.WriteLine(); 
                     Console.WriteLine(); 
                      Console.WriteLine("**************************查找订单**************************"); 
                      Console.WriteLine("1.根据流水号查找               2.查找某天对应所有订单"); 
                     Console.WriteLine("3.根据客户名查找对应所有订单   4.根据商品名称查找对应所有订单"); 
                      Console.WriteLine("5.返回主页"); 
                     int choose = 0; 
                      Choose(ref choose, 1, 5);              
                      int num = 0;         //通过其他方式查找的判断num，代表个数 
  
 
                      switch (choose) 
                     { 
                       case 1: 
                            int flag = -1;       //通过流水号查找的判断falg，-1无，其他值则表示位置 
                             Console.Write("请输入流水号（格式：2018-1-1-1）："); 
                              flag = OrderService.FindOrder(Console.ReadLine()); 
                            if(flag==-1) 
                            { 
                                  Console.WriteLine(); 
                                 Console.WriteLine(); 
                                  Console.WriteLine("未查找到！"); 
                            } 
                             else 
                           { 
                                 Console.WriteLine(); 
                                Console.WriteLine(); 
                                Console.WriteLine("共查找到1单！"); 
                             } 
                            break; 
                         case 2: 
                            Console.Write("请输入日期（格式：20180101）："); 
                              num = OrderService.FindOrder(DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)); 
                             break; 
                       case 3: 
                            Console.Write("请输入客户名称："); 
                           num = OrderService.FindOrderByClientName(Console.ReadLine()); 
                           break; 
                         case 4: 
                            Console.Write("请输入商品名称："); 
                           num = OrderService.FindOrderByProductName(Console.ReadLine()); 
                              break; 
                       case 5: 
                             return;         //返回主页 
                   } 
                 if (choose!=1&&num > 0) 
                    { 
                         Console.WriteLine(); 
                        Console.WriteLine(); 
                         Console.WriteLine("共查找到{0}单！", num); 
                    } 
                     else if (choose != 1&&num == 0) 
                      { 
                          Console.WriteLine(); 
                         Console.WriteLine(); 
                          Console.WriteLine("未查找到！"); 
                      } 
                } 
                 catch (Exception e) 
                  { 
                    Console.WriteLine(); 
                      Console.WriteLine(); 
                      Console.WriteLine(e.Message); 
                     Console.WriteLine("失败，请重试！"); 
                } 
            } 
         } 

          public static void ChangeOrder()
        { 
              while (true) 
            { 
                try 
                { 
                      Console.WriteLine(); 
                      Console.WriteLine(); 
                    Console.WriteLine("**************************修改订单**************************"); 
                      Console.WriteLine("     1.通过流水号定位到订单               2.返回主页"); 
                   int choose = 0; 
                      Choose(ref choose, 1, 2); 
                    if (choose == 1) 
                      { 
                         int flag = -1;       //通过流水号查找的判断falg，-1无，其他值则表示位置 
                          Console.Write("请输入流水号（格式：2018-1-1-1）："); 
                         flag = OrderService.FindOrder(Console.ReadLine());//通过流水号查找的判断falg 
                          if (flag != -1)   //查找到 
                         { 
                             while(true) 
                              { 
                                  Console.WriteLine(); 
                               Console.WriteLine(); 
                                  Console.WriteLine("----------------订单如上，选择要修改的内容--------------"); 
                                  Console.WriteLine("       1.客户名称         2.商品         3.返回修改订单页   "); 
                                  int choice = 1; 
                                  Choose(ref choice, 1, 3); 
                                  bool success = false; 
                                  if (choice == 1)
                                {
                                    Console.Write("请输入新的客户名称："); 
                                    string clientName = Console.ReadLine(); 
                                      OrderService.ChangeOrderClientName(flag, clientName); 
                                      success = true; 
                                  } 
                                 if (choice == 2)      //修改商品 
                                 { 
                                     while (true) 
                                  { 
                                        try 
                                         { 
                                              Console.Write("-------请输入商品编号(从上到下，从1开始编号）："); 
                                            int num = int.Parse(Console.ReadLine()) - 1; 
                                           Console.WriteLine(); 
                                             Console.WriteLine(); 
                                             Console.WriteLine("----------------选择修改商品的哪个属性----------------"); 
                                             Console.WriteLine("1.商品名称2.商品价格3.商品价格4.返回选择要修改的内容页 "); 
                                              int which = 0; 
                                             Choose(ref which, 1, 4); 
                                            if (which == 1) 
                                            { 
                                                      Console.Write("请输入商品新名称："); 
                                                      string productName = Console.ReadLine(); 
                                                      success = OrderService.ChangeOrderProduct(flag, num, productName); 
                                              } 
                                              if (which == 2) 
                                             { 
                                                      Console.Write("请输入商品新单价："); 
                                                      float productPrice = float.Parse(Console.ReadLine()); 
                                                      success = OrderService.ChangeOrderProduct(flag, num, productPrice); 
                                              } 
                                              if (which == 3) 
                                              { 
                                                      Console.Write("请输入商品新数目："); 
                                                     int productNum = int.Parse(Console.ReadLine()); 
                                                     success = OrderService.ChangeOrderProductNum(flag, num, productNum); 
                                             } 
                                           else 
                                              { 
                                                    break; 
                                             } 
                                             if (success) 
                                             { 
                                                     Console.WriteLine(); 
                                                      Console.WriteLine(); 
                                                    Console.Write("修改成功！"); 
                                             } 
                                            else 
                                             { 
                                                    Console.WriteLine(); 
                                                      Console.WriteLine(); 
                                                      Console.Write("修改失败！"); 
                                              }                                                                                                                                       
                                         } 
                                         catch (Exception e) 
                                         { 
                                             Console.WriteLine(); 
                                             Console.WriteLine(); 
                                              Console.WriteLine(e.Message); 
                                              Console.WriteLine("失败，请重试！"); 
                                         } 

 
                                     } 
                                } 
                                 if(choice==3) 
                                 { 
                                     break; 
                                  } 
                                  if (success) 
                                  { 
                                     Console.WriteLine(); 
                                     Console.WriteLine(); 
                                    Console.Write("修改成功！"); 
                                  } 
                                else 
                                 { 
                                    Console.WriteLine(); 
                                      Console.WriteLine(); 
                                      Console.Write("修改失败！"); 
                                  } 
                           } 
                       } 
                        else 
                        { 
                            Console.WriteLine(); 
                             Console.WriteLine(); 
                             Console.WriteLine("无此订单！"); 
                         } 
                     } 
                     if(choose==2)     
                    { 
                         return;         //返回主页 
                     } 
                  } 
                catch (Exception e) 
               { 
                     Console.WriteLine(); 
                      Console.WriteLine(); 
                      Console.WriteLine(e.Message); 
                      Console.WriteLine("失败，请重试！"); 
                  } 
              } 
          } 
    } 
 
 

   
}
