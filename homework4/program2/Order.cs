using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Order
    {
        private static int orderCount = 0;                                         
          public string OrderNum { get; set; }                                    
         public DateTime OrderDateTime { get; private set; }                    
         private List<OrderDetails> myOrderDetails = new List<OrderDetails>();                              //订单明细 
         private float AllPrice { get; set; }                                   
         public string ClientName { get; set; }                                  
 
 
         public Order(string clientName)                                        
          { 
              Order.orderCount++;                         
              OrderDateTime = new DateTime();             
             OrderDateTime = DateTime.Now;               
             ClientName = clientName;                    
           
            OrderNum = OrderDateTime.Year.ToString()+ "-" + OrderDateTime.Month.ToString()+ "-" + OrderDateTime.Day.ToString()+ "-" + orderCount.ToString(); 
             
             AllPrice = 0; 
       } 

         public Order(string clientName, int productNum, string productName, float productPrice) : this(clientName) 
         { 
             myOrderDetails.Add(new OrderDetails(productNum, productName, productPrice)); 
              AllPrice = GetAllPrice(); 
         } 
         public bool AddOrderDetails(int productNum, string productName, float productPrice)
          { 
            myOrderDetails.Add(new OrderDetails(productNum, productName, productPrice)); 
             AllPrice = GetAllPrice(); 
             return true; 
        } 

 
 
            
         public float GetAllPrice()                                  
         { 
           AllPrice = 0; 
              foreach (OrderDetails orderDetails in myOrderDetails) 
             { 
                 AllPrice += orderDetails.GetProductPriceSum(); 
             } 
              return AllPrice; 
         } 
          public static int GetOrderCount()                           
         { 
              return orderCount; 
          public void ShowOrder()                                     
         { 
             Console.WriteLine("//////////////////////////////////////////"); 
           Console.WriteLine("订单号："+OrderNum); 
             Console.WriteLine("客户名称：" + ClientName); 
             foreach(OrderDetails orderDetails in myOrderDetails) 
             { 
                  orderDetails.ShowOrderDetails(); 
             } 
             Console.WriteLine("订单金额总计：" + AllPrice); 
            Console.WriteLine("订单日期："+OrderDateTime); 
         } 

 
         public override bool Equals(object obj)                    
         { 
            if (obj == null || this.GetType() != obj.GetType())           
             {
                    return false;
              } 
           Order tmp = (Order)obj; 
            if (this.GetAllPrice() != tmp.GetAllPrice() 
                || this.ClientName!=tmp.ClientName 
                ||this.OrderNum!=tmp.OrderNum 
               ||this.OrderDateTime!=tmp.OrderDateTime  
                || this.myOrderDetails.Count != tmp.myOrderDetails.Count) 
             {
                  return false;
              } 
              else 
       {
                  for (int i = 0; i < this.myOrderDetails.Count; i++)
              {
                        if (!this.myOrderDetails.ElementAt(i).Equals(tmp.myOrderDetails.ElementAt(i)))
                           {
                                  return false;
                           }
                       }
                   return true;
           } 
         } 
        public override int GetHashCode()                           
         { 
             return (int) AllPrice; 
         } 

          
          public bool HaveProductByName(string productName)              
          { 
              foreach (OrderDetails orderDetails in myOrderDetails) 
             { 
                if (orderDetails.myProduct.ProductName == productName ) 
                 { 
                    return true; 
                 } 
             } 
              return false; 
          } 
 
 
         public bool ChangeProduct(int i, string productName)           
        { 
           if (i< 0 || i> myOrderDetails.Count) 
            { 
                 return false; 
            } 
             myOrderDetails[i].myProduct.ProductName = productName; 
             return true; 
         } 
        public bool ChangeProduct(int i, float productPrice)         
        { 
           if (i< 0 || i> myOrderDetails.Count) 
           { 
                return false; 
             } 
             myOrderDetails[i].myProduct.ProductPrice = productPrice; 
             return true; 
        } 
 
 
         public bool ChangeProductNum(int i, int productNum)            
          { 
              if (i< 0 || i> myOrderDetails.Count) 
              { 
                  return false; 
              } 
              myOrderDetails[i].ProductNum = productNum; 
              return true; 
        } 

    }
}
