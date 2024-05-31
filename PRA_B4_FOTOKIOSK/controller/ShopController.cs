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
            ShopManager.SetShopPriceList("Prijzen:\nFoto 10x15: €2.55");

            // Stel de bon in onderaan het scherm
            ShopManager.SetShopReceipt("Eindbedrag\n€");

            // Vul de productlijst met producten
            ShopManager.Products.Add(new KioskProduct() { Name = "Foto 10x15" });
            
            
            // Update dropdown met producten
            ShopManager.UpdateDropDownProducts();
<<<<<<< HEAD

        }
=======
>>>>>>> 0e7622f48278ca5d0d094dc5941f74756d7eb661


            
        }

        
        private void AddButtonClick(object sender, RoutedEventArgs e)
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

        private void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            chosenProducts.Clear();
             totalPrice = 0;
            UpdateReceiptAndPrice();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            
            
            //ShopManager.SetShopReceipt(chosenProducts);
            //ShopManager.AddShopReceipt();
            ShopManager.SetShopPriceList($"Total Price: {totalPrice:C}");
        }

        private void UpdateReceiptAndPrice()
        {
            ShopManager.SetShopReceipt(string.Join(", ", chosenProducts));
            //ShopManager.SetShopPriceList($"Total Price: {totalPrice:C}");
        }


    }
}
