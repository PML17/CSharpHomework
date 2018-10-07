using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Product
    { 
         public string ProductName { get; set; }                    
          public float ProductPrice { get; set; }                     
 
         public Product(string ProductName, float ProductPrice)      
        { 
             this.ProductName = ProductName; 
             this.ProductPrice = ProductPrice; 
          } 
 
 
        public Product(Product product)                             
        { 
             this.ProductName = product.ProductName; 
            this.ProductPrice = product.ProductPrice; 
        } 
        public void ShowProduct()                                  
        { 
            Console.Write(ProductName+"\t\t\t"); 
            Console.Write("{0,-15}", ProductPrice); 
        } 
         public override bool Equals(object obj)                    
         { 
             if (obj == null || this.GetType() != obj.GetType())           
              {
                   return false;
               } 
             Product tmp = (Product)obj; 
             return (this.ProductName == tmp.ProductName 
                     && this.ProductPrice == tmp.ProductPrice); 
         } 
          public override int GetHashCode()                          
         { 
             return (int) ProductPrice; 
        } 


    }
}
