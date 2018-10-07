using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderDetails
    {
        public Product myProduct;                                                   
          public int ProductNum { get; set; }                                        
          public OrderDetails(int productNum, string productName, float productPrice)   
         { 
            myProduct = new Product(productName, productPrice); 
            ProductNum = productNum; 
            GetProductPriceSum(); 

 
        } 
        public OrderDetails(int productNum, Product product)                          
       { 
              myProduct = new Product(product); 
            ProductNum = productNum; 
            GetProductPriceSum(); 
         } 
        public float GetProductPriceSum()                                           
        { 
             return (myProduct.ProductPrice* ProductNum); 
         } 

 
         public void ShowOrderDetails()                                              
        { 
            Console.WriteLine(); 
          myProduct.ShowProduct(); 
             Console.WriteLine("{0,-15}", "x"+ProductNum); 
             Console.WriteLine(); 
            Console.WriteLine("商品总价：" + GetProductPriceSum()); 
 
 
        } 
         public override bool Equals(object obj)                                      
        { 
           if (obj == null|| this.GetType() != obj.GetType())           
           {
                   return false;
              } 
           OrderDetails tmp = (OrderDetails)obj; 
             if (obj == null|| this.GetType() != obj.GetType()||this.ProductNum != tmp.ProductNum || !this.myProduct.Equals(tmp)) 
         {
                   return false;
               } 
           return true; 
       } 
        public override int GetHashCode()                                           
         { 
           return (int) GetProductPriceSum(); 
        } 

    }
}
