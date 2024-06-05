using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                                        DateTime photoTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, seconds);

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

                // Update de fotos
                PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        public void RefreshButtonClick()
        {
            
        }

    }
}

/**
namespace PRA_B4_FOTOKIOSK.controller
{
    public class PictureController
    {
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }

        // De lijst met foto's die we laten zien
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start methode die wordt aangeroepen wanneer de foto pagina opent.
        public void Start()
        {
            var now = DateTime.Now;
            int day = (int)now.DayOfWeek;

            // Calculate the time ranges
            DateTime lowerBound = now.AddMinutes(-30);
            DateTime upperBound = now.AddMinutes(-2);
            DateTime camera1UpperBound = now.AddSeconds(60);
            DateTime camera2UpperBound = camera1UpperBound.AddSeconds(60);

            var directoryPath = @"../../../fotos";

            // Dictionary to hold paired photos
            Dictionary<string, List<KioskPhoto>> pairedPhotos = new Dictionary<string, List<KioskPhoto>>();

            // Initialize the list of photos
            foreach (string dir in Directory.GetDirectories(directoryPath))
            {
                var folderName = Path.GetFileName(dir);
                var folderDayNumber = folderName.Split('_');

                if (folderDayNumber.Length > 1 && int.TryParse(folderDayNumber[0], out int dayNumber) && dayNumber == day)
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        var parts = fileName.Split('_');

                        if (parts.Length >= 4 && int.TryParse(parts[0], out int hour) &&
                            int.TryParse(parts[1], out int minute) &&
                            int.TryParse(parts[2], out int seconds) &&
                            int.TryParse(parts[3], out int id))
                        {
                            DateTime photoTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, seconds);

                            if (photoTime > now)
                            {
                               
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
                    }
                }
            }

            // Flatten the dictionary into the PicturesToDisplay list and order them by photo time
            foreach (var photoPair in pairedPhotos.Values)
            {
                PicturesToDisplay.AddRange(photoPair.OrderBy(photo => ExtractDateTimeFromFileName(photo.Source)));
            }
            PicturesToDisplay = PicturesToDisplay.OrderBy(photo => ExtractDateTimeFromFileName(photo.Source)).ToList();

            // Update the photos
            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Extract DateTime from the file name
        private DateTime ExtractDateTimeFromFileName(string fileName)
        {
            var parts = Path.GetFileNameWithoutExtension(fileName).Split('_');

            if (parts.Length >= 3 && int.TryParse(parts[0], out int hour) &&
                int.TryParse(parts[1], out int minute) &&
                int.TryParse(parts[2], out int seconds))
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, seconds);
            }

            return DateTime.MinValue; // Return minimum value if parsing fails
        }

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        public void RefreshButtonClick()
        {
            // Clear the current list of pictures and reload
            PicturesToDisplay.Clear();
            Start();
        }
    }
}
*/
