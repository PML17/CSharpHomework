using Microsoft.VisualStudio.TestTools.UnitTesting;
using programe1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programe1.Tests
{
   [TestClass()] 
      public class OrderServiceTests
     { 
         [TestMethod()] 
          public void ImportTest()
          { 
              Assert.IsFalse(OrderService.Import("")); 
             Assert.IsTrue(OrderService.Import(@"D:\C#\homework6\program1\MyOrder.xml")); 
             Assert.IsFalse(OrderService.Import(".hsea")); 
          } 
 
 
         [TestMethod()] 
          public void ExportTest()
         { 
             Assert.IsFalse(OrderService.Export("")); 
             Assert.IsTrue(OrderService.Import(@"D:\GitHub\CSharpHomework\homework6\program1\MyOrder.xml")); 
             Assert.IsFalse(OrderService.Import(".hsea")); 
         } 
  
 
         [TestMethod()] 
         public void AddOrderTest()
          { 
              Order myorder = new Order(); 
              Assert.IsFalse(OrderService.AddOrder(null)); 
              Assert.IsTrue(OrderService.AddOrder(myorder)); 
          } 
  
 
          [TestMethod()] 
         public void FindOrderTest()
          { 
             Assert.AreEqual(0,OrderService.FindOrder("")); 
         } 
 
 
         [TestMethod()] 
         public void FindOrderTest1()
        { 
             Assert.AreEqual(0, OrderService.FindOrder(null)); 
          } 
  
 
          [TestMethod()] 
          public void FindOrderByProductNameTest()
         { 
             Assert.AreEqual(0, OrderService.FindOrderByProductName("")); 
             Assert.AreEqual(0, OrderService.FindOrderByProductName("xxx")); 
         } 
  
 
          [TestMethod()] 
          public void FindOrderBySumPriceTest()
          { 
              Assert.AreEqual(0, OrderService.FindOrderBySumPrice()); 
          } 
  
 
         [TestMethod()] 
          public void FindOrderByClientNameTest()
         { 
             Assert.AreEqual(0, OrderService.FindOrderByClientName("")); 
          } 
 
 
        [TestMethod()] 
       public void DeleteOrderTest()
         { 
            Assert.IsFalse(OrderService.DeleteOrder("")); 
             Assert.IsFalse(OrderService.DeleteOrder("xxxx")); 
          } 
 
 
         [TestMethod()] 
         public void DeleteOrderByClientNameTest()
          { 
              Assert.IsFalse(OrderService.DeleteOrderByClientName("")); 
              Assert.IsFalse(OrderService.DeleteOrderByClientName("xxxx")); 
        } 

 
          [TestMethod()] 
         public void DeleteOrderByProductNameTest()
         { 
              Assert.IsFalse(OrderService.DeleteOrderByProductName("")); 
              Assert.IsFalse(OrderService.DeleteOrderByProductName("xxxx")); 
        } 

 
         [TestMethod()] 
        public void DeleteOrderTest1()
          { 
              Assert.IsFalse(OrderService.DeleteOrderByProductName(null)); 
        } 

 
          [TestMethod()] 
        public void CLearOrdersTest()
        { 
              OrderService.CLearOrders(); 
              Assert.AreEqual(0, OrderService.myOrders.Count()); 
          } 
 
 
          [TestMethod()] 
          public void ShowAllOrdersTest()
         { 
            Assert.AreEqual(0, OrderService.myOrders.Count()); 
         } 
 
 
          [TestMethod()] 
          public void LocatedOrderTest()
          { 
             Assert.AreEqual(-1, OrderService.LocatedOrder("")); 
              Assert.AreEqual(-1, OrderService.LocatedOrder("xxx")); 
          } 
  
 
          [TestMethod()] 
          public void ChangeOrderClientNameTest()
          { 
             Assert.IsFalse(OrderService.ChangeOrderClientName(-1,"")); 
             Assert.IsFalse(OrderService.ChangeOrderClientName(-1,"XXX")); 
              Assert.IsFalse(OrderService.ChangeOrderClientName(OrderService.myOrders.Count,"")); 
              Assert.IsFalse(OrderService.ChangeOrderClientName(OrderService.myOrders.Count,"XXX")); 
         } 
  
 
          [TestMethod()] 
          public void ChangeOrderProductNumTest()
          { 
              Assert.IsFalse(OrderService.ChangeOrderProductNum(-1, 1, 1)); 
              Assert.IsFalse(OrderService.ChangeOrderProductNum(-1, 1, 1)); 
             Assert.IsFalse(OrderService.ChangeOrderProductNum(OrderService.myOrders.Count, 1, 1)); 
             Assert.IsFalse(OrderService.ChangeOrderProductNum(OrderService.myOrders.Count, 1, 1)); 
          } 
  
 
        [TestMethod()] 
         public void ChangeOrderProductTest()
         { 
             Assert.IsFalse(OrderService.ChangeOrderProduct(-1, 1, "")); 
              Assert.IsFalse(OrderService.ChangeOrderProduct(-1, 1, "XXX")); 
              Assert.IsFalse(OrderService.ChangeOrderProduct(OrderService.myOrders.Count, 1, "")); 
              Assert.IsFalse(OrderService.ChangeOrderProduct(OrderService.myOrders.Count, 1, "XXX")); 
         } 

 
         [TestMethod()] 
         public void ChangeOrderProductTest1()
         { 
             Assert.IsFalse(OrderService.ChangeOrderProduct(-1, 1, 1)); 
            Assert.IsFalse(OrderService.ChangeOrderProduct(-1, 1, 1)); 
             Assert.IsFalse(OrderService.ChangeOrderProduct(OrderService.myOrders.Count, 1, 1)); 
             Assert.IsFalse(OrderService.ChangeOrderProduct(OrderService.myOrders.Count, 1, 1)); 
         } 
     } 

}