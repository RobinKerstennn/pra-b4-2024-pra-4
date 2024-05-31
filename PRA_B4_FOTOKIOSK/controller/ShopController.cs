using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PRA_B4_FOTOKIOSK;


namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {
        
        // Maak een nieuwe lijst met OrderedProducts
        // Wanneer een items wordt besteld (AddButtonClick) voeg een nieuwe OrderedProduct toe aan de lijst
        // UpdateReceiptEnPrice aanpassen zodat de bon print

        private double totalPrice = 0;
        List<OrderdProduct> chosenProducts = new List<OrderdProduct>();
        public void Cashier()
        {
            
                //product lijsten maken
                OrderdProduct order = new OrderdProduct(1, "Foto", 0, 5.59);
                OrderdProduct order2 = new OrderdProduct(1, "Mok", 0, 4.99);
                OrderdProduct order3 = new OrderdProduct(1, "Tshirt", 0, 499.99);
                
                Console.WriteLine("Wil je foto producten??");
                string product = Console.ReadLine();
                if (product == "ja")
                {
                    // vragen aantal foto's
                    order.AddProduct();
                    order2.AddProduct();
                    order3.AddProduct();
                    double totalPrice = order.getTotalPrice() + order2.getTotalPrice() + order3.getTotalPrice();
                    Console.WriteLine($"Je moet totaal {totalPrice} betalen.");

                }
            }

        public static Home Window { get; set; }

        public void Start()
        {
            List<string> chosenProducts = new List<string>();
            // Stel de prijslijst in aan de rechter kant.
            ShopManager.SetShopPriceList("Prijzen:\nFoto 10x15: €2.55\nMok: €49.99\nTshirt: €499.99");

            // Stel de bon in onderaan het scherm
            ShopManager.SetShopReceipt("Eindbedrag\n€");

            // Vul de productlijst met producten
            ShopManager.Products.Add(new KioskProduct() { Name = "Foto 10x15" });
            ShopManager.Products.Add(new KioskProduct() { Name = "Mok" });
            ShopManager.Products.Add(new KioskProduct() { Name = "Tshirt" });
            
            // Update dropdown met producten
            ShopManager.UpdateDropDownProducts();


            
        }

        
        public void AddButtonClick()
        {

            KioskProduct selectedProduct = ShopManager.GetSelectedProduct();
            if (selectedProduct == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            OrderdProduct product = new OrderdProduct((int)ShopManager.GetFotoId(), selectedProduct.Name,
                (int)ShopManager.GetAmount(), (int)ShopManager.GetAmount() + selectedProduct.Price);

            chosenProducts.Add(product);
            UpdateReceiptAndPrice();
        }

        public void ResetButtonClick()
        {
            chosenProducts.Clear();
             totalPrice = 0;
            UpdateReceiptAndPrice();
        }

        public void SaveButtonClick()
        {
            string path = "text.txt";   
            if (File.Exists(path))
            {
                //writes to file
                System.IO.File.WriteAllText(path,"Text to add to the file\n");
            }
            else
            {
                // Create the file.
                System.IO.File.WriteAllText(path, "Text to add to the file\n");


            }
            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            //ShopManager.SetShopReceipt(chosenProducts);
            //ShopManager.AddShopReceipt();
           // ShopManager.SetShopPriceList($"Total Price: {price:C}");
        }

        private void UpdateReceiptAndPrice()
        {
            foreach (OrderdProduct chosenProduct in chosenProducts)
            {
                if (chosenProduct.ProductName == "Mok")
                {
                    ShopManager.AddShopReceipt($"x{chosenProduct.Total} {chosenProduct.ProductName} price 4.99 euro\n");
                    double totaal = chosenProduct.Total * 4.99;
                    
                    ShopManager.AddShopReceipt($"x {chosenProduct.ProductName} {totaal}\n");
                    
                    totalPrice += totaal;
                    
                }
                else if(chosenProduct.ProductName == "Tshirt")
                {
                    ShopManager.AddShopReceipt($"x{chosenProduct.Total} {chosenProduct.ProductName} price 499.99 euro\n");
                    double totaal = chosenProduct.Total * 499.99;
                    
                    ShopManager.AddShopReceipt($"x {chosenProduct.ProductName} {totaal}\n");
                    
                    totalPrice += totaal;
                }
                else if(chosenProduct.ProductName == "Foto 10x15")
                {
                    double totaal = chosenProduct.Total * 5.59;
                    
                    ShopManager.AddShopReceipt($"x {chosenProduct.ProductName} {totaal}\n");
                    
                    totalPrice += totaal;
                }
                
            }
            
            ShopManager.AddShopReceipt($"totale price is {totalPrice} euro");
        }


    }
}