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

        // Wordt uitgevoerd wanneer er op de Toevoegen knop is geklikt
        public void AddButtonClick()
        {
            
        }

        // Wordt uitgevoerd wanneer er op de Resetten knop is geklikt
        public void ResetButtonClick()
        {

        }

        // Wordt uitgevoerd wanneer er op de Save knop is geklikt
        public void SaveButtonClick()
        {
        }

    }
}
