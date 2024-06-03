using PRA_B4_FOTOKIOSK.models;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace PRA_B4_FOTOKIOSK.magie
{
    public class SearchManager
    {
        public static Home Instance { get; set; }

        public static void SetPicture(string path)
        {
            try
            {
                Instance.imgBig.Source = PathToImage(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in SetPicture: " + ex.Message);
            }
        }

        public static BitmapImage PathToImage(string path)
        {
            try
            {
                var stream = new MemoryStream(File.ReadAllBytes(path));
                var img = new BitmapImage();

                img.BeginInit();
                img.StreamSource = stream;
                img.EndInit();

                return img;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in PathToImage: " + ex.Message);
                return null;
            }
        }

        public static string GetSearchInput()
        {
            return Instance?.tbZoeken.Text ?? string.Empty;
        }

        public static void SetSearchImageInfo(string text)
        {
            if (Instance != null)
            {
                Instance.lbSearchInfo.Content = text;
            }
        }

        public static string GetSearchImageInfo()
        {
            return Instance?.lbSearchInfo.Content as string ?? string.Empty;
        }

        public static void AddSearchImageInfo(string text)
        {
            SetSearchImageInfo(GetSearchImageInfo() + text);
        }
    }
}
