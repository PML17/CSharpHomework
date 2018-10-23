using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programe1
{
    class OrderDetails
    {
        public Product myProduct;                                                   //商品 
        public int ProductNum { get; set; }                                         //商品数量 

        public OrderDetails()
        {
            myProduct = new Product();
            ProductNum = 0;
            }

        public OrderDetails(int productNum, string productName, float productPrice)  //构造函数 
        {
            myProduct = new Product(productName, productPrice);
            ProductNum = productNum;
            GetProductPriceSum();


        }
        public OrderDetails(int productNum, Product product)                          //构造函数 
        {
            myProduct = new Product(product);
            ProductNum = productNum;
            GetProductPriceSum();
        }
        public float GetProductPriceSum()                                           //返回总价 
        {
            return (myProduct.ProductPrice * ProductNum);
        }


        public void ShowOrderDetails()                                              //显示订单细节 
        {
            Console.WriteLine();
            myProduct.ShowProduct();
            Console.WriteLine("{0,-15}", "x" + ProductNum);
            Console.WriteLine();
            Console.WriteLine("商品总价：" + GetProductPriceSum());


        }
        public override bool Equals(object obj)                                     //重写Equals 
        {
            if (obj == null || this.GetType() != obj.GetType())           //为空或类型不同返回false 
            {
                return false;
            }
            OrderDetails tmp = (OrderDetails)obj;
            if (obj == null || this.GetType() != obj.GetType() || this.ProductNum != tmp.ProductNum || !this.myProduct.Equals(tmp))
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()                                           //重写GetHashCode 
        {
            return (int)GetProductPriceSum();
        }
    }
}
