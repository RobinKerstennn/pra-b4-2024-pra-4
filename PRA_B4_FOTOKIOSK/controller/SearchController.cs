using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
            SearchManager.Instance = Window;
            //int day;
            //if (int.TryParse(SearchManager.GetSearchInput(), out day))
            //{
            // Initializeer de lijst met foto's
            //PicturesToDisplay.Clear();

            // Loop door de directories om foto's te laden
            //foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            //{
            //var folderName = Path.GetFileName(dir);
            //var folderDayNumber = folderName.Split('_');

            // if (folderDayNumber.Length > 1)
            //  {
            //  int dayNumber;
            //  if (int.TryParse(folderDayNumber[0], out dayNumber) && dayNumber == day)
            //    {
            //          foreach (string file in Directory.GetFiles(dir))
            //            {
            //                PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
            //                }
            //              }
            //            }
            //          }

            // Update de foto's op het scherm
            //   UpdateDisplayedPictures();
            //       }

            // Update de fotos

        }

        // Wordt uitgevoerd wanneer er op de Zoeken knop is geklikt
        public void SearchButtonClick()
        {
            // Zoeken door de lijst met fotos, naar een foto die string bevat
            string search = SearchManager.GetSearchInput();
            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    if (file.Contains(search))
                    {
                        SearchManager.SetPicture(file);

                        SearchManager.SetSearchImageInfo(file);

                        
                            // Haal de bestandsnaam op zonder het pad
                            string filename = Path.GetFileName(file);

                            // Splits de bestandsnaam op '_', '.'
                            string[] delen = filename.Split(new char[] { '_', '.' },
                                StringSplitOptions.RemoveEmptyEntries);

                            if (delen.Length >= 5) // Controleer of er minstens 5 delen zijn
                            {
                                // Stel de datum samen
                                string datum = $"{delen[0]}/{delen[1]}/{delen[2]}";
                                // Haal het ID op, assuming delen[3] is "id2442"
                                string ID = delen[3].Substring(2); // Remove the "id" prefix from delen[3]

                                // Gebruik de bestandsnaam
                                

                                // Print de gegevens
                                SearchManager.SetSearchImageInfo($"Datum: {datum}\n ID: {ID}\nBestandsnaam: {filename}");
                            }
                            
                        }

                    }
                }
            }
        }
    }
//}
                        
        
    

