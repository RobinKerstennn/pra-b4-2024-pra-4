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
        // The window displayed on the screen
        public static Home Window { get; set; }

        // The list of photos to display
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start method called when the photo page opens
        public void Start()
        {
            var now = DateTime.Now;
            int day = (int)now.DayOfWeek;

            DateTime lowerBound = now.AddMinutes(-30);
            DateTime upperBound = now.AddMinutes(-2);

            var directoryPath = @"../../../fotos";

            // Lists to store photos for each camera
            var camera1Photos = new List<KioskPhoto>();
            var camera2Photos = new List<KioskPhoto>();

            // Load photos from the main directory
            LoadPhotosFromDirectory(directoryPath, day, lowerBound, upperBound, camera1Photos, camera2Photos);

            // Combine and sort the photos for display
            PicturesToDisplay.AddRange(camera1Photos);
            PicturesToDisplay.AddRange(camera2Photos);
            PicturesToDisplay = PicturesToDisplay.OrderBy(p => p.PhotoTime).ToList();

            // Update the photos on the screen
            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        private void LoadPhotosFromDirectory(string directoryPath, int day, DateTime lowerBound, DateTime upperBound, List<KioskPhoto> camera1Photos, List<KioskPhoto> camera2Photos)
        {
            foreach (string dir in Directory.GetDirectories(directoryPath))
            {
                var folderName = Path.GetFileName(dir);
                var folderDayNumber = folderName.Split('_');

                if (folderDayNumber.Length > 1 && int.TryParse(folderDayNumber[0], out int dayNumber) && dayNumber == day)
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        var fileName = Path.GetFileNameWithoutExtension(file);
                        var parts = fileName.Split('_');

                        if (parts.Length >= 4 && int.TryParse(parts[0], out int hour) &&
                            int.TryParse(parts[1], out int minute) && int.TryParse(parts[2], out int second))
                        {
                            string id = parts[3]; // Extract the ID part
                            DateTime photoTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);

                            if (photoTime > DateTime.Now)
                            {
                                photoTime = photoTime.AddDays(-1);
                            }

                            if (photoTime >= lowerBound && photoTime <= upperBound)
                            {
                                var photo = new KioskPhoto() { Id = 0, Source = file, PhotoTime = photoTime };

                                if (IsCamera1(photoTime))
                                {
                                    camera1Photos.Add(photo);
                                }
                                else
                                {
                                    camera2Photos.Add(photo);
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool IsCamera1(DateTime photoTime)
        {
            // Photos taken at xx:xx:01 and xx:xx:30 (±2 seconds) go to camera1Photos
            var seconds = photoTime.Second;
            return (seconds >= 1 && seconds <= 6) || (seconds >= 55 && seconds <= 65);
        }

        // Method executed when the Refresh button is clicked
        public void RefreshButtonClick()
        {
            // Refresh functionality can be implemented here
        }
    }

    public class KioskPhoto
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public DateTime PhotoTime { get; set; } // Added to store the photo time
    }

    public static class PictureManager
    {
        public static void UpdatePictures(List<KioskPhoto> pictures)
        {
            // Logic to update pictures on the screen
        }
    }
}
