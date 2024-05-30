using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {
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
            
            // Stel de prijslijst in aan de rechter kant.
            ShopManager.SetShopPriceList("Prijzen:\nFoto 10x15: €2.55");

            // Stel de bon in onderaan het scherm
            ShopManager.SetShopReceipt("Eindbedrag\n€");

            // Vul de productlijst met producten
            ShopManager.Products.Add(new KioskProduct() { Name = "Foto 10x15" });
            
            
            // Update dropdown met producten
            ShopManager.UpdateDropDownProducts();


            
        }

        
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            string selectedProduct = ((ComboBoxItem)cbProducts.SelectedItem)?.Content.ToString();
            if (selectedProduct == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            double price = 0;
            if (selectedProduct == "Foto 10x15")
            {
                chosenProducts.Add("Foto 10x15");
                price = 2.55;
            }
            else if (selectedProduct == "Mok")
            {
                chosenProducts.Add("Mok");
                price = 4.99;
            }
            else if (selectedProduct == "Shirt")
            {
                chosenProducts.Add("Shirt");
                price = 499.99;
            }

            totalPrice += price;
            UpdateReceiptAndPrice();
        }

        private void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            chosenProducts.Clear();
            totalPrice = 0;
            UpdateReceiptAndPrice();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            lbReceipt.Content = string.Join(", ", chosenProducts);
            lbPrices.Content = $"Total Price: {totalPrice:C}";
        }

        private void UpdateReceiptAndPrice()
        {
            lbReceipt.Content = string.Join(", ", chosenProducts);
            lbPrices.Content = $"Total Price: {totalPrice:C}";
        }
        }
        }

    }
}
