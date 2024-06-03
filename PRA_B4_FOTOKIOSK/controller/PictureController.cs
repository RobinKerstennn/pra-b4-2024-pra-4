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

            // Calculate the time range
            DateTime lowerBound = now.AddMinutes(-30);
            DateTime upperBound = now.AddMinutes(-2);
            var directoryPath = @"../../../fotos";

            // Initializeer de lijst met fotos
            foreach (string dir in Directory.GetDirectories(directoryPath))
            {
                var folderName = Path.GetFileName(dir);
                var folderDayNumber = folderName.Split('_');

                if (folderDayNumber.Length > 1 && int.TryParse(folderDayNumber[0], out int dayNumber) && dayNumber == day)
                {
                    List<KioskPhoto> photosForDay = new List<KioskPhoto>();

                    foreach (string file in Directory.GetFiles(dir))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        var parts = fileName.Split('_');

                        if (parts.Length >= 3 && int.TryParse(parts[0], out int hour) &&
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

            // Update de fotos
            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        public void RefreshButtonClick()
        {
            // You can add code here to refresh the photo display if needed
        }
    }
}






/*using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class PictureController
    {
        // The window displayed on the screen
        public static Home Window { get; set; }

        // The list of photos to display
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start method that is called when the photo page opens
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
                        List<KioskPhoto> photosForDay = new List<KioskPhoto>();

                        foreach (string file in Directory.GetFiles(dir))
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file);
                            var parts = fileName.Split('_');

                            if (parts.Length >= 3 && int.TryParse(parts[0], out int hour) &&
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
                                    photosForDay.Add(new KioskPhoto() { Id = 0, Source = file });
                                }
                            }
                        }

                        // Pair photos taken by the two cameras
                        var pairedPhotos = PairPhotos(photosForDay);
                        PicturesToDisplay.AddRange(pairedPhotos);
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

        // Pair photos taken by the two cameras 60 seconds apart
        private List<KioskPhoto> PairPhotos(List<KioskPhoto> photos)
        {
            List<KioskPhoto> pairedPhotos = new List<KioskPhoto>();

            var groupedPhotos = photos
                .Select(photo => new
                {
                    Photo = photo,
                    Time = ExtractDateTimeFromFileName(photo.Source)
                })
                .OrderBy(photo => photo.Time)
                .ToList();

            for (int i = 0; i < groupedPhotos.Count - 1; i++)
            {
                var currentPhoto = groupedPhotos[i];
                var nextPhoto = groupedPhotos[i + 1];

                if (nextPhoto.Time - currentPhoto.Time == TimeSpan.FromSeconds(60))
                {
                    pairedPhotos.Add(currentPhoto.Photo);
                    pairedPhotos.Add(nextPhoto.Photo);
                    i++; // Skip the next photo since it is paired with the current one
                }
                else
                {
                    pairedPhotos.Add(currentPhoto.Photo);
                }
            }

            return pairedPhotos;
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

        // Executed when the Refresh button is clicked
        public void RefreshButtonClick()
        {
            // Clear the current list of pictures and reload
            PicturesToDisplay.Clear();
            Start();
        }
    }
}
*/