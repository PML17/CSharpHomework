using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace program1
{
    class Menu
    {
        public static void Choose(ref int flag, int i, int j)           //用户输入选择，检查选择的范围是否合法
        {
            //范围在i-j之间
            while (true)
            {
                try
                {
                    Console.Write("请输入您的选择：");
                    flag = int.Parse(Console.ReadLine());
                    if (flag >= i && flag <= j)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("输入非法！请重试！ ");
                    }
                }
                catch
                {
                    Console.WriteLine("输入非法！请重试！ ");
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
                Console.WriteLine("此系统含有几单实验订单，可修改Xml文件来修改订单或批量添加订单");

                Console.WriteLine("         1.添加订单                      2.删除订单  ");

                Console.WriteLine("         3.修改订单                      4.查找订单  ");

                Console.WriteLine("         5.清空所有订单                  6.显示订单");

                Console.WriteLine("         7.从xml文件中导入               8.导出为xml文件");

                Console.WriteLine("         9.退出");

                int choose = 1;

                Choose(ref choose, 1, 9);

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

                        ImportFromXml();

                        break;

                    case 8:

                        ExportAsXml();

                        break;

                    case 9:

                        return;       //退出

                }

            }



        }



        public static void AddOrder()

        {

            string clientName = null;

            string phonenNumber = null;

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

                        while (true)

                        {

                            string pattern = @"1\d{10}";

                            Console.Write("请输入客户电话(1x...xx(11位1开头）：");

                            phonenNumber = Console.ReadLine();

                            if (Regex.IsMatch(phonenNumber, pattern))

                                break;

                            else

                                Console.Write("输入错误！请重试！");

                        }

                        Order tmp = new Order(clientName, phonenNumber);

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

                    Console.WriteLine("5.根据客户电话删除对应所有订单 6.返回主页");

                    int choose = 0;

                    Choose(ref choose, 1, 6);

                    bool haveDeleted = true;

                    switch (choose)

                    {

                        case 1:

                            Console.Write("请输入流水号（格式：2018101010001(年月日+三位号））：");

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

                            string phonenNumber = "";

                            while (true)

                            {

                                string pattern = @"1\d{10}";

                                Console.Write("请输入客户电话(1x...xx(11位1开头）：");

                                phonenNumber = Console.ReadLine();

                                if (Regex.IsMatch(phonenNumber, pattern))

                                    break;

                                else

                                    Console.Write("输入错误！请重试！");

                            }

                            haveDeleted = OrderService.DeleteOrderByClientPhoneNumber(phonenNumber);

                            break;

                        case 6:

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

                    Console.WriteLine("5.查找订单金额大于一万的订单   6.根据客户电话查找对应所有订单");

                    Console.WriteLine("7.返回主页");

                    int choose = 0;

                    Choose(ref choose, 1, 7);    //接收用户的输入，并限制输入的范围

                    int num = 0;         //通过除流水号的其他方式查找的判断num，代表个数



                    switch (choose)

                    {

                        case 1:

                            Console.Write("请输入流水号（格式：2018101010001(年月日+三位号））：");

                            num = OrderService.FindOrder(Console.ReadLine());

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

                            Console.Write("查找订单金额大于一万的订单，请稍等。。。");

                            num = OrderService.FindOrderBySumPrice();

                            break;

                        case 6:

                            string phonenNumber = "";

                            while (true)

                            {

                                string pattern = @"1\d{10}";

                                Console.Write("请输入客户电话(1x...xx(11位1开头）：");

                                phonenNumber = Console.ReadLine();

                                if (Regex.IsMatch(phonenNumber, pattern))

                                    break;

                                else

                                    Console.Write("输入错误！请重试！");

                            }

                            num = OrderService.FindOrderByClientPhoneNumber(phonenNumber);

                            break;

                        case 7:

                            return;         //返回主页

                    }

                    if (num > 0)

                    {

                        Console.WriteLine();

                        Console.WriteLine();

                        Console.WriteLine("共查找到{0}单！", num);

                    }

                    else if (num == 0)

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

                    int choose = 1;

                    Choose(ref choose, 1, 2);

                    if (choose == 1)

                    {

                        int flag = -1;       //通过流水号查找的判断falg，-1无，其他值则表示位置

                        Console.Write("请输入流水号（格式：2018101010001(年月日+三位号））：");

                        flag = OrderService.LocatedOrder(Console.ReadLine());//通过流水号查找的判断falg

                        if (flag != -1)   //查找到

                        {

                            while (true)

                            {

                                Console.WriteLine();

                                Console.WriteLine();

                                Console.WriteLine("----------------订单如上，选择要修改的内容--------------");

                                Console.WriteLine("       1.客户名称  2.客户电话  3.商品  4.返回修改订单页   ");

                                int choice = 1;

                                Choose(ref choice, 1, 4);

                                bool success = false;

                                if (choice == 1)      //修改客户名称

                                {

                                    Console.Write("请输入新的客户名称：");

                                    string clientName = Console.ReadLine();

                                    OrderService.ChangeOrderClientName(flag, clientName);

                                    success = true;

                                }

                                if (choice == 2)      //修改客户电话

                                {

                                    string phonenNumber = "";

                                    while (true)

                                    {

                                        string pattern = @"1\d{10}";

                                        Console.Write("请输入客户电话(1x...xx(11位1开头）：");

                                        phonenNumber = Console.ReadLine();

                                        if (Regex.IsMatch(phonenNumber, pattern))

                                            break;

                                        else

                                            Console.Write("输入错误！请重试！");

                                    }

                                    success = true;

                                }

                                if (choice == 3)      //修改商品

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

                                if (choice == 4)

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

                    if (choose == 2)

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



        public static void ImportFromXml()

        {

            while (true)

            {

                try

                {

                    Console.WriteLine();

                    Console.WriteLine();

                    Console.WriteLine("**************************从XML文件导入**************************");

                    Console.WriteLine("               1.输入路径               2.返回主页");

                    int choose = 1;

                    Choose(ref choose, 1, 2);

                    if (choose == 1)

                    {

                        Console.WriteLine("*********************是否清除现有的订单**********************");

                        Console.WriteLine("                 1.是               2.否");

                        int choose2 = 1;

                        Choose(ref choose2, 1, 2);

                        if (choose2 == 1)

                            OrderService.CLearOrders();

                        Console.Write("请输入需要导入的Xml路径(直接回车表示默认路径即“../../MyOrder.xml”)：");

                        string xmlPath = Console.ReadLine();

                        if (xmlPath == "")

                        {

                            xmlPath = "../../MyOrder.xml";

                        }

                        if (OrderService.Import(xmlPath))

                            Console.WriteLine("导入成功！");

                        else

                            Console.WriteLine("导入失败！");





                    }

                    if (choose == 2)

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



        public static void ExportAsXml()

        {

            while (true)

            {

                try

                {

                    Console.WriteLine();

                    Console.WriteLine();

                    Console.WriteLine("**************************导出为XML文件**************************");

                    Console.WriteLine("               1.输入路径               2.返回主页");

                    int choose = 1;

                    Choose(ref choose, 1, 2);

                    if (choose == 1)

                    {

                        Console.Write("请输入导出的Xml路径(直接回车表示默认路径即“../../MyOrder.xml”)：");

                        string xmlPath = Console.ReadLine();

                        if (xmlPath == "")

                        {

                            xmlPath = "../../MyOrder.xml";

                        }

                        if (OrderService.Export(xmlPath))

                            Console.WriteLine("导出成功！");

                        else

                            Console.WriteLine("导出失败！");



                    }

                    if (choose == 2)

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