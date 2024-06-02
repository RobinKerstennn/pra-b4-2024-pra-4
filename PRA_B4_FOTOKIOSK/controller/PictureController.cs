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
    //public class PictureController
    //{
        // The window displayed on the screen
      //  public static Home Window { get; set; }

        // The list of photos to display
        //public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start method that is called when the photo page opens.
        //public void Start()
        //{
          //  var now = DateTime.Now;
          //  int day = (int)now.DayOfWeek;
          //  DateTime lowerBound = now.AddMinutes(-30);
           // DateTime upperBound = now.AddMinutes(-2);
           // var directoryPath = @"../../../fotos";

            // Initialize the list of photos
            // WARNING. WITHOUT FILTER THIS LOADS EVERYTHING!
            //foreach (string dir in Directory.GetDirectories(directoryPath))
            //{
              //  var folderName = Path.GetFileName(dir);
                //var folderDayNumber = folderName.Split('_');

                //if (folderDayNumber.Length > 1 && int.TryParse(folderDayNumber[0], out int dayNumber) && dayNumber == day)
                //{
                  //  foreach (string file in Directory.GetFiles(dir))
                    //{
                      //  var fileNameParts = Path.GetFileNameWithoutExtension(file).Split('_');
                        //if (fileNameParts.Length >= 3 && int.TryParse(fileNameParts[0], out int hour) &&
                          //  int.TryParse(fileNameParts[1], out int minute) && int.TryParse(fileNameParts[2], out int second))
                        //{
                          //  Date Time photoTime = new Date Time(now.Year, now.Month, now.Day, hour, minute, second);

                           // if (photoTime > now)
                            //{
                           //     photoTime = photoTime.AddDays(-1);
                            }

//if (photoTime >= lowerBound && photoTime <= upperBound)
//{
// PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
//                           }
//                     }
//               }
public void Start()
{
    try
    {
        var now = DateTime.Now;
        int day = (int)now.DayOfWeek;
        DateTime lowerBound = now.AddMinutes(-30);
        DateTime upperBound = now.AddMinutes(-2);
        var directoryPath = @"../../../fotos";

        // Initialize the list of photos
        foreach (string dir in Directory.GetDirectories(directoryPath))
        {
            var folderName = Path.GetFileName(dir);
            var folderDayNumber = folderName.Split('_');

            if (folderDayNumber.Length > 1 && int.TryParse(folderDayNumber[0], out int dayNumber) && dayNumber == day)
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    var fileNameParts = Path.GetFileNameWithoutExtension(file).Split('_');
                    if (fileNameParts.Length >= 3 && int.TryParse(fileNameParts[0], out int hour) &&
                        int.TryParse(fileNameParts[1], out int minute) && int.TryParse(fileNameParts[2], out int second))
                    {
                        DateTime photoTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, second);

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
        // Update the photos
        PictureManager.UpdatePictures(PicturesToDisplay);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error in Start method: " + ex.Message);
    }
}

// Executed when the Refresh button is clicked
public void RefreshButtonClick()
{
    // Clear the current list of pictures and reload
    PicturesToDisplay.Clear();
}
}
                }
            }
            // Update the photos
            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Executed when the Refresh button is clicked
        public void RefreshButtonClick()
        {
            // Clear the current list of pictures and reload
            PicturesToDisplay.Clear();
        }
    }
}
