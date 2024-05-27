using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRA_B4_FOTOKIOSK.magie;

namespace PRA_B4_FOTOKIOSK.models
{
    public class KioskProduct
    {

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
        
        public void SetShopPriceList()
        {
            foreach (KioskProduct product in ShopManager.Products)
            {
                StringBuilder priceList = new StringBuilder();

                priceList.AppendLine($"{product.Name}: {product.Price:C} - {product.Description}");
            }
        }
        public void AddShopPriceList()
        {
            foreach (KioskProduct product in ShopManager.Products)
            {
                StringBuilder priceList = new StringBuilder();

                priceList.AppendLine($"{product.Name}: {product.Price:C} - {product.Description}");
            }
        }
        public void GetShopPriceList()
        {
            foreach (KioskProduct product in ShopManager.Products)
            {
                StringBuilder priceList = new StringBuilder();

                priceList.AppendLine($"{product.Name}: {product.Price:C} - {product.Description}");
            }
        }

    }

    public class OrderdProduct()
    {
        private int PhotoNumber;
        private string;
    }
}
