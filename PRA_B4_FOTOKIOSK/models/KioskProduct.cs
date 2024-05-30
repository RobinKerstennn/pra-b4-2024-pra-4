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
        private int PhotoNumber;
        private string ProductName;
        private int Total;
        private double TotalPrice;
        
        public OrderdProduct(int PhotoNumber, string ProductName, int Total, double TotalPrice)
        {
            this.PhotoNumber = PhotoNumber;
            this.ProductName = ProductName;
            this.Total = Total;
            this.TotalPrice = TotalPrice;
        }

        public void AddProduct()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.WriteLine("Welke product wil je?");
                string product = Console.ReadLine();
                if (product == "mok")
                {
                    Total += 
                }
            }
            
            
        }
        
    }
}
