using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Of_Sale.BL
{
    class Admin
    {
        public void AddProduct(Product Source)
        {
            ProductCRUD.AddProduct(Source);
        }
        public Product getHigestPriceProduct()
        {
            return ProductCRUD.getProductOfHighestPrice();
        }
    }
}
