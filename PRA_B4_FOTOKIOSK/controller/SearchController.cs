using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class SearchController
    {
        // Het venster dat we op het scherm tonen
        public Home Window { get; set; }

        // De lijst met foto's die we laten zien
        public List<KioskPhoto> PicturesToDisplay { get; set; }

        // Constructor
        public SearchController(Home window)
        {
            Window = window;
            PicturesToDisplay = new List<KioskPhoto>();
            LoadSamplePhotos();
        }

        // Methode die wordt aangeroepen wanneer de zoekknop wordt ingedrukt
        public void SearchButtonClick()
        {
            ImageSearch = SearchManager.GetSearchInput();
            SearchManager.SetPicture(ImageSearch);
        }

        // Methode om foto's te zoeken op basis van datum en tijd
       

        // Methode om foto's op het scherm te tonen
        private void DisplayPhotos(List<KioskPhoto> photos)
        {
            if (photos.Count > 0)
            {
                SearchManager.SetPicture(photos[0].FilePath);
                Window.lbSearchInfo.Content = $"Gevonden foto's: {photos.Count}";
            }
            else
            {
                SearchManager.SetPicture(null);
                Window.lbSearchInfo.Content = "Geen foto's gevonden.";
            }
        }

        // Methode om voorbeeldfoto's te laden vanuit een map
        private void LoadSamplePhotos()
        {
            string directoryPath = Path.GetFullPath(@"../../../fotos");

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Directory '{directoryPath}' does not exist.");
                return;
            }

            string[] photoFiles = Directory.GetFiles(directoryPath, "*.jpg");

            foreach (string filePath in photoFiles)
            {
                DateTime captureDateTime = File.GetCreationTime(filePath);

                PicturesToDisplay.Add(new KioskPhoto
                {
                    Id = 0, Source = file
                });
            }
        }
    }
}


