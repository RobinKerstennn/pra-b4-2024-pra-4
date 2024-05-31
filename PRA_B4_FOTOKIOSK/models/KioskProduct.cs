using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRA_B4_FOTOKIOSK.magie;



//  kiok lijsten printen
namespace PRA_B4_FOTOKIOSK.models
{
    public class KioskProduct
    {
        // maak get set
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
        
        
        // maak lijsten
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
    
    public class OrderdProduct
    {
        public int PhotoNumber;
        public string ProductName;
        public int Total;
        public double TotalPrice;
        
        public OrderdProduct(int PhotoNumber, string ProductName, int Total, double TotalPrice)
        {
            this.PhotoNumber = PhotoNumber;
            this.ProductName = ProductName;
            this.Total = Total;
            this.TotalPrice = TotalPrice;
        }

        public void AddProduct()
        {
            Console.WriteLine($"Hoeveel {ProductName} wil je kopen?");
            string Decision = Console.ReadLine();
            int DecisionValue = int.Parse(Decision);
            Total += DecisionValue;
        }
        public double getTotalPrice() {
            return this.Total * this.TotalPrice;
        }
        
    }
}
