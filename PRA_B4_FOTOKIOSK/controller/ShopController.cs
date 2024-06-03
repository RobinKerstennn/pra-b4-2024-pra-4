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
        
        int countMok = 0;
        int countTshirt = 0;
        int countFoto = 0;
        private double totalPrice = 0;
        List<OrderdProduct> chosenProducts = new List<OrderdProduct>();
        public void Cashier()
        {
            
                //product lijsten maken
                OrderdProduct order = new OrderdProduct(1, "Foto", 0, 2.55);
                OrderdProduct order2 = new OrderdProduct(1, "Mok", 0, 49.99);
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
            //UpdateReceiptAndPrice();
            ShopManager.SetShopReceipt($"totale price is {totalPrice} euro");
        }

        private void UpdateReceiptAndPrice()
        {
            // ShopManager.SetShopReceipt($"totale price is {totalPrice} euro");

            // foreach (OrderdProduct chosenProduct in chosenProducts)
            //{
            //  if (chosenProduct.ProductName == "Mok")
            //{
            //  double totaal = chosenProduct.Total * 4.99;
            //totalPrice += totaal;
            //countMok += chosenProduct.Total;
            //}
            //else if (chosenProduct.ProductName == "Tshirt")
            //{
            //  double totaal = chosenProduct.Total * 499.99;
            //totalPrice += totaal;
            //countTshirt += chosenProduct.Total;
            //}
            //else if (chosenProduct.ProductName == "Foto 10x15")
            //{
            //  double totaal = chosenProduct.Total * 5.59;
            //totalPrice += totaal;
            //countFoto += chosenProduct.Total;
            //}
            //}
            //ShopManager.SetShopReceipt($"Eindbedrag\n€{totalPrice}");
            double totalPrice = 0;

            ShopManager.SetShopReceipt($"totale price is {totalPrice} euro");

            foreach (OrderdProduct chosenProduct in chosenProducts)
            {
                if (chosenProduct.ProductName == "Mok")
                {
                    double totaal = chosenProduct.Total * 49.99;
                    totalPrice += totaal;
                    countMok += chosenProduct.Total;
                    ShopManager.AddShopReceipt($"{chosenProduct.Total} {chosenProduct.ProductName}");
                    
                }
                if (chosenProduct.ProductName == "Tshirt")
                {
                    double totaal = chosenProduct.Total * 499.99;
                    totalPrice += totaal;
                    countTshirt += chosenProduct.Total;
                    ShopManager.AddShopReceipt($"{chosenProduct.Total} {chosenProduct.ProductName}");
                    
                }
                if (chosenProduct.ProductName == "Foto 10x15")
                {
                    double totaal = chosenProduct.Total * 2.59;
                    totalPrice += totaal;
                    countFoto += chosenProduct.Total;
                    ShopManager.AddShopReceipt($"{chosenProduct.Total} {chosenProduct.ProductName}");
                    
               }
            }
            
            ShopManager.SetShopReceipt($"Eindbedrag\n€{totalPrice}");
        }

        public void SaveButtonClick()
        {
            string filePath = @"../text.txt"; // Specify the file path
            string number = Convert.ToString(totalPrice); // Specify the text content
            string content = $"{countMok} mokken {countFoto} fotos {countTshirt} shirts, inkomen {number}\n";
            File.AppendAllText(filePath, content); // Append the content to the file
        }

        }

           

        }
        

   


    