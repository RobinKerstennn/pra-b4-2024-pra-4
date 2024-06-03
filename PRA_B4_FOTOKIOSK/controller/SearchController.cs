using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class SearchController
    {
        public static Home Window { get; set; }
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        public void Start()
        {
            SearchManager.Instance = Window;
            // You can add any initialization logic here if needed
        }

        public void SearchButtonClick()
        {
            string input = SearchManager.GetSearchInput();
            DateTime inputValue;
            string[] formats = { "MM/dd/yyyy", "dd-MM-yyyy" }; // example formats

            bool isValid = DateTime.TryParseExact(input, formats, null, System.Globalization.DateTimeStyles.None, out inputValue);
            try
            {
                var searchTimeInput = SearchManager.GetSearchInput();
                if (DateTime.TryParseExact(searchTimeInput, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime searchTime))
                {
                    var directoryPath = @"../../../fotos";
                    bool photoFound = false;

                    foreach (string dir in Directory.GetDirectories(directoryPath))
                    {
                        foreach (string file in Directory.GetFiles(dir, "*.jpg"))
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file);
                            if (fileName.Length >= 8 && int.TryParse(fileName.Substring(0, 2), out int hour) &&
                                int.TryParse(fileName.Substring(3, 2), out int minute) &&
                                int.TryParse(fileName.Substring(6, 2), out int second))
                            {
                                DateTime photoTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);
                                if (photoTime == inputValue) 
                                {
                                    PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
                                    
                                }
                            }
                        }

                        if (photoFound)
                        {
                            break;
                        }
                    }

                    if (!photoFound)
                    {
                        Console.WriteLine("No photo found for the given time.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid time format. Please use 'HH:mm:ss'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in SearchButtonClick: " + ex.Message);
            }
        }

        private static void ShowPhoto(string filePath)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(filePath);
                image.EndInit();

                if (SearchManager.Instance != null && SearchManager.Instance.imgBig != null)
                {
                    SearchManager.Instance.imgBig.Source = image;
                }
                else
                {
                    Console.WriteLine("SearchManager.Instance or imgBig is null. Ensure they are properly initialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ShowPhoto: " + ex.Message);
            }
        }

        public bool IsImageFile(string file)
        {
            string extension = Path.GetExtension(file).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp";
        }
    }
}
