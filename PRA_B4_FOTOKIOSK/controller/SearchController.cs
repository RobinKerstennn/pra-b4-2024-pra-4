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
            ShopManager.Instance = Window;



        }

        public void SearchButtonClick()
        {
            // plaat een if-statement
            // plaats een foreach loop
            var now = DateTime.Now;
            int day = (int)now.DayOfWeek;

            DateTime lowerBound = now.AddMinutes(-30);
            DateTime upperBound = now.AddMinutes(-2);

            // Initializeer de lijst met fotos
            // WAARSCHUWING. ZONDER FILTER LAADT DIT ALLES!
            // foreach is een for-loop die door een array loopt
            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                var folderName = Path.GetFileName(dir);
                var folderDayNumber = folderName.Split('_');

                if (folderDayNumber.Length > 1)
                {
                    int dayNumber;
                    if (int.TryParse(folderDayNumber[0], out dayNumber))
                        if (dayNumber == day)
                        {
                            foreach (string file in Directory.GetFiles(dir))
                            {

                                string fileName = Path.GetFileNameWithoutExtension(file);
                                var parts = fileName.Split("_");

                                if (parts.Length > 0)
                                {
                                    if (int.TryParse(parts[0], out int hour) &&
                                        int.TryParse(parts[1], out int minute) &&
                                        int.TryParse(parts[2], out int seconds))
                                    {
                                        DateTime photoTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, seconds);

                                        DateTime searchInputDateTime;
                                        bool isParsed = DateTime.TryParse(SearchManager.GetSearchInput(), out searchInputDateTime);

                                        if (isParsed && searchInputDateTime == photoTime)
                                        {
                                            SearchManager.SetPicture(@"../../../fotos");
                                        }

                                    }
                                }
                            }
                        }

                    {

                    }
                }


            }


        }
    }
}
