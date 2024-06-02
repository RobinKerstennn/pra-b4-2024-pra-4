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
     try
        {
            // Controleer of SearchManager.Instance niet null is voordat je het gebruikt
            if (SearchManager.Instance != null && !string.IsNullOrEmpty(time))
            {
                // Parse de invoertijdreeks naar een DateTime-object
                if (DateTime.TryParseExact(time, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime searchTime))
                {
                    string directoryPath = @"C:\Your\Photo\Directory";

                    // Zoek naar foto's in de map
                    bool photoFound = false;
                    foreach (string file in Directory.GetFiles(directoryPath, "*.jpg"))
                    {
                        // Extraheren van de tijd uit de bestandsnaam
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        if (fileName.Length >= 8 && int.TryParse(fileName.Substring(0, 2), out int hour) &&
                            int.TryParse(fileName.Substring(3, 2), out int minute) &&
                            int.TryParse(fileName.Substring(6, 2), out int second))
                        {
                            DateTime photoTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);

                            // Controleer of de fototijd overeenkomt met de zoekopdrachtijd
                            if (photoTime == searchTime)
                            {
                                // Laat de foto zien
                                ShowPhoto(file);
                                photoFound = true;
                                break; // Stop met zoeken nadat de eerste overeenkomende foto is gevonden
                            }
                        }
                    }

                    if (!photoFound)
                    {
                        Console.WriteLine("Geen foto gevonden voor het opgegeven tijdstip.");
                    }
                }
                else
                {
                    Console.WriteLine("Ongeldige tijdnotatie. Gebruik alstublieft 'HH:mm:ss'.");
                }
            }
            else
            {
                // SearchManager.Instance of time is null of leeg, toon het juiste bericht
                Console.WriteLine("SearchManager.Instance of time is null of leeg. Zorg ervoor dat ze correct zijn geïnitialiseerd.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
        }
    }

    private static void ShowPhoto(string filePath)
    {
        // Laad de afbeelding en laat deze zien
        BitmapImage image = new BitmapImage();
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.UriSource = new Uri(filePath);
        image.EndInit();

        // Controleer of Image control is geïnitialiseerd en stel de bron in
        if (SearchManager.Instance != null && SearchManager.Instance.imgBig != null)
        {
            SearchManager.Instance.imgBig.Source = image;
        }
        else
        {
            Console.WriteLine("SearchManager.Instance of imgBig is null. Zorg ervoor dat ze correct zijn geïnitialiseerd.");
        }
    }
}
