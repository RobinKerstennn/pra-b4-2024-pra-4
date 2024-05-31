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
    public class SearchController
    {
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }
        

        // Start methode die wordt aangeroepen wanneer de zoek pagina opent.
        public void Start()
        {
            int day = lbSearchInfo;

            // Initializeer de lijst met fotos
            // WAARSCHUWING. ZONDER FILTER LAADT DIT ALLES!
            // foreach is een for-loop die door een array loopt
            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                /**
                 * dir string is de map waar de fotos in staan. Bijvoorbeeld:
                 * \fotos\0_Zondag
                 */
                var folderName = Path.GetFileName(dir);
                var folderDayNumber = folderName.Split('_');

                
                if (folderDayNumber.Length > 1)
                {
                    int dayNumber;
                    if (int.TryParse(folderDayNumber[0], out dayNumber))
                        if (dayNumber == lbSearchInfo)
                        {
                            foreach (string file in Directory.GetFiles(dir))
                            {
                                /**
                                 * file string is de file van de foto. Bijvoorbeeld:
                                 * \fotos\0_Zondag\10_05_30_id8824.jpg
                                 */

                                PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
                            }
                        }
                    {
                       
                    }
                }
                
            }

            // Update de fotos
            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Wordt uitgevoerd wanneer er op de Zoeken knop is geklikt
        public void SearchButtonClick()
        {
            
        }

    }
}
