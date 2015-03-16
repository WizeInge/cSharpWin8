using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;

using Bing.Maps;
using Bing.Maps.Search;
using Newtonsoft.Json;


namespace LesSeptMerveillesDuMonde
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {   //Muraille
            myMap.Center = new Location(40.440023, 117.257423); // Centre la carte au coord.
            myMap.ZoomLevel = 18;

            convertUrl("La%20grande%20muraille%20de%20Chine");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   // Pétra
            myMap.Center = new Location(30.3251734, 35.4425807);
            myMap.ZoomLevel = 18;

            convertUrl("Petra");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {   // Christ
            myMap.Center = new Location(-22.952703, -43.211299);
            myMap.ZoomLevel = 18;

            convertUrl("Christ%20redempteur");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {   // Machu picchu
            myMap.Center = new Location(-13.1631412, -72.5449628);
            myMap.ZoomLevel = 18;

            convertUrl("Machu%20Picchu");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {   // Chichen itza
            myMap.Center = new Location(20.6826180, -88.5686445);
            myMap.ZoomLevel = 18;

            convertUrl("Chichen%20Itza");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {   //colisée
            myMap.Center = new Location(41.8902102, 12.4922308);
            myMap.ZoomLevel = 19;

            convertUrl("Colisée");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {   // Taj Mahal
            myMap.Center = new Location(27.173891, 78.042068);
            myMap.ZoomLevel = 18;

            convertUrl("Taj%20Mahal");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {   // Pyramide
            myMap.Center = new Location(29.9757396, 31.1320991);
            myMap.ZoomLevel = 17;

            convertUrl("Les%20pyramide%20de%20Kheops");
        }

        private async void Button_Click_9(object sender, RoutedEventArgs e)
        {   // Search monuments
            string locate = searchBox.Text;

            // Set the address string to geocode
            Bing.Maps.Search.GeocodeRequestOptions requestOptions = new Bing.Maps.Search.GeocodeRequestOptions(locate);

            // Make the geocode request 
            Bing.Maps.Search.SearchManager searchManager = myMap.SearchManager;
            Bing.Maps.Search.LocationDataResponse response = await searchManager.GeocodeAsync(requestOptions);

            myMap.Center = new Location(response.LocationData[0].Location);
            myMap.ZoomLevel = 16;
        }

        private async void convertUrl(string monuments)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://fr.wikipedia.org/w/api.php?format=json&action=query&prop=revisions&rvprop=content&rvsection=0&rvparse&titles=" + monuments);
            using (HttpWebResponse response = (HttpWebResponse)(await myRequest.GetResponseAsync()))
            {
                string ResponseText;
                string[] ResponseArray;
                string test;
                string tests;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    ResponseText = reader.ReadToEnd();
                    ResponseArray = ResponseText.Split(new string[] { "\"pageid\"" }, StringSplitOptions.None);
                    test = "{ \"pageid\"" + ResponseArray[1];
                    tests = test.Replace("}]}}}}", "}]}");

                   /* Debug.WriteLine(string.Join(", ", ResponseText));
                    Debug.WriteLine(string.Join(", ", tests));*/
                    InfoMonuments objJson = new InfoMonuments();

                    objJson = JsonConvert.DeserializeObject<InfoMonuments>(tests);

                }
            }
        }
    }
}
