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


    public class PictureController
    {
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }


        // De lijst met fotos die we laten zien
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();


        // Start methode die wordt aangeroepen wanneer de foto pagina opent.
        public void Start()
        {
            var now = DateTime.Now;
            int day = (int)now.DayOfWeek;

            DateTime lowerBound = now.AddMinutes(-30);
            DateTime upperBound = now.AddMinutes(-2);

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
                /*string fileName = Path.GetFileNameWithoutExtension(@"../../../fotos");
                var parts = fileName.Split("_");*/



                if (folderDayNumber.Length > 1)
                {
                    int dayNumber;
                    if (int.TryParse(folderDayNumber[0], out dayNumber))
                        if (dayNumber == day)
                        {
                            foreach (string file in Directory.GetFiles(dir))
                            {
                                /**
                                 * file string is de file van de foto. Bijvoorbeeld:
                                 * \fotos\0_Zondag\10_05_30_id8824.jpg
                                 */
                                string fileName = Path.GetFileNameWithoutExtension(file);
                                var parts = fileName.Split("_");

                                if (parts.Length > 0)
                                {
                                    if (int.TryParse(parts[0], out int hour) &&
                                        int.TryParse(parts[1], out int minute) &&
                                        int.TryParse(parts[2], out int seconds))
                                    {
                                        DateTime photoTime = new DateTime(now.Year, now.Month, now.Day, hour, minute,
                                            seconds);

                                        if (photoTime > now)
                                        {
                                            photoTime = photoTime.AddDays(-1);
                                        }

                                        if (photoTime >= lowerBound && photoTime <= upperBound)
                                        {
                                            PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
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
        public void RefreshButtonClick()
        {
                        
        }
    }
}

// Update de fotos
              //  PictureManager.UpdatePictures(PicturesToDisplay);
    //   }

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        //public void RefreshButtonClick()
      //  {
            
    //    }

  //  }
//}




    //public class PictureController
    //{
        // The window displayed on the screen
      //  public static Home Window { get; set; }

        // The list of photos to display
      //  public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start method that is called when the photo page opens.
        //public void Start()
        //{
          //  var now = DateTime.Now;
          //  int day = (int)now.DayOfWeek;
          //  DateTime lowerBound = now.AddMinutes(-30);
          //  DateTime upperBound = now.AddMinutes(-2);
          //  var directoryPath = @"../../../fotos";

            // Initialize the list of photos
            // WARNING. WITHOUT FILTER THIS LOADS EVERYTHING!
          //  foreach (string dir in Directory.GetDirectories(directoryPath))
          //  {
               // var folderName = Path.GetFileName(dir);
               // var folderDayNumber = folderName.Split('_');

                //if (folderDayNumber.Length > 1 && int.TryParse(folderDayNumber[0], out int dayNumber) && dayNumber == day)
              //  {
            //        foreach (string file in Directory.GetFiles(dir))
          //          {
        //                var fileNameParts = Path.GetFileNameWithoutExtension(file).Split('_');
      //                  if (fileNameParts.Length >= 3 && int.TryParse(fileNameParts[0], out int hour) &&
    //                        int.TryParse(fileNameParts[1], out int minute) && int.TryParse(fileNameParts[2], out int second))
  //                      {
//                            DateTime photoTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, second);

      //                      if (photoTime > now)
    //                        {
  //                              photoTime = photoTime.AddDays(-1);
//                            }

//if (photoTime >= lowerBound && photoTime <= upperBound)
//{
 //PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
         //                  }
       //              }
     //          }

// Executed when the Refresh button is clicked
//public void RefreshButtonClick()
//{
//}
    

//}