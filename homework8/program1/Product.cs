using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace program1

{

    [Serializable]

    public class Product                                                   //产品类

    {

        public string ProductName { get; set; }                     //商品名称

        public float ProductPrice { get; set; }                     //商品单价

        public Product()      //构造函数

        {

            this.ProductName = "";

            this.ProductPrice = 0;

        }



        public Product(string ProductName, float ProductPrice)      //构造函数

        {

            this.ProductName = ProductName;

            this.ProductPrice = ProductPrice;

        }



        public Product(Product product)                             //拷贝构造函数（深拷贝）

        {

            this.ProductName = product.ProductName;

            this.ProductPrice = product.ProductPrice;

        }

        public void ShowProduct()                                   //显示产品信息

        {

            Console.Write(ProductName + "\t\t\t");

            Console.Write("{0,-15}", ProductPrice);

        }

        public override bool Equals(object obj)                     //重写Equals

        {

            if (obj == null || this.GetType() != obj.GetType())           //为空或类型不同返回false

            {

                return false;

            }

            Product tmp = (Product)obj;

            return (this.ProductName == tmp.ProductName

                    && this.ProductPrice == tmp.ProductPrice);

        }

        public override int GetHashCode()                           //重写GetHashCode

        {

            return (int)ProductPrice;

        }



        public override string ToString()

        {

            return ProductName + ProductPrice;

        }



    }

}