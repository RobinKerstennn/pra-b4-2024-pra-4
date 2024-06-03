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
    public class KioskPhoto
    {
        public string FilePath { get; set; }
    }
    public class SearchController
    {
        
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }
        
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();
        
        // Start methode die wordt aangeroepen wanneer de zoek pagina opent.
        public void Start()
        {
       
            ShopManager.Instance = Window;


            // Update de fotos
            
        }

        // Wordt uitgevoerd wanneer er op de Zoeken knop is geklikt
        public void SearchButtonClick()
        {
            int day;
            if (int.TryParse(SearchManager.GetSearchInput(), out day))
            {
                // Initializeer de lijst met foto's
                //    SearchManager.bbjb


                // Loop door de directories om foto's te laden
                foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
                {
                    var folderName = Path.GetFileName(dir);
                    var folderDayNumber = folderName.Split('_');

                    if (folderDayNumber.Length > 1)
                    {
                        int dayNumber;
                        if (int.TryParse(folderDayNumber[0], out dayNumber) && dayNumber == day)
                        {
                            DateTime photoTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);

                            // Controleer of de fototijd overeenkomt met de zoekopdrachtijd
                            if (photoTime == searchTime)
                            {
                                
                                if (IsImageFile(file))
                                {
                                   PicturesToDisplay.Add(new KioskPhoto { FilePath = file });
                                }
                            }
                        }
                    }
                }
                

                // Update de foto's op het scherm
                //   UpdateDisplayedPictures();
            }
        }
        public bool IsImageFile(string file)
        {
            string extension = Path.GetExtension(file).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp";
        }

    }
}