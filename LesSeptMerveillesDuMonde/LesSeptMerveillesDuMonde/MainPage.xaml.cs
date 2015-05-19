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

            Uri muraille = new Uri("http://fr.wikipedia.org/wiki/Grande_Muraille");
            displayHtml(muraille);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   // Pétra
            myMap.Center = new Location(30.3251734, 35.4425807);
            myMap.ZoomLevel = 18;

            Uri petra = new Uri("http://fr.wikipedia.org/wiki/P%C3%A9tra");
            displayHtml(petra);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {   // Christ
            myMap.Center = new Location(-22.952703, -43.211299);
            myMap.ZoomLevel = 18;

            Uri christ = new Uri("http://fr.wikipedia.org/wiki/Christ_R%C3%A9dempteur");
            displayHtml(christ);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {   // Machu picchu
            myMap.Center = new Location(-13.1631412, -72.5449628);
            myMap.ZoomLevel = 18;

            Uri machu = new Uri("http://fr.wikipedia.org/wiki/Machu_Picchu");
            displayHtml(machu);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {   // Chichen itza
            myMap.Center = new Location(20.6826180, -88.5686445);
            myMap.ZoomLevel = 18;

            Uri itza = new Uri("http://fr.wikipedia.org/wiki/Chich%C3%A9n_Itz%C3%A1");
            displayHtml(itza);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {   //colisée
            myMap.Center = new Location(41.8902102, 12.4922308);
            myMap.ZoomLevel = 19;

            Uri colisee = new Uri("http://fr.wikipedia.org/wiki/Colis%C3%A9e");
            displayHtml(colisee);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {   // Taj Mahal
            myMap.Center = new Location(27.173891, 78.042068);
            myMap.ZoomLevel = 18;

            Uri TajMhal = new Uri("http://fr.wikipedia.org/wiki/Taj_Mahal");
            displayHtml(TajMhal);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {   // Pyramide
            myMap.Center = new Location(29.9757396, 31.1320991);
            myMap.ZoomLevel = 17;

            Uri pyramide = new Uri("http://fr.wikipedia.org/wiki/Pyramide_de_Kh%C3%A9ops");
            displayHtml(pyramide);
        }

        private async void Button_Click_9(object sender, RoutedEventArgs e)
        {   // Search monuments
            string locate = searchBox.Text;

            if(locate != "")
            {
                // Set the address string to geocode
                Bing.Maps.Search.GeocodeRequestOptions requestOptions = new Bing.Maps.Search.GeocodeRequestOptions(locate);

                // Make the geocode request 
                Bing.Maps.Search.SearchManager searchManager = myMap.SearchManager;
                Bing.Maps.Search.LocationDataResponse response = await searchManager.GeocodeAsync(requestOptions);

                myMap.Center = new Location(response.LocationData[0].Location);
                myMap.ZoomLevel = 16;

                //Mise a 0 de l'opacité du webview
                WebContainer.Opacity = 0;
            }
            else
            {
                searchBox.Text = "Marseille";
            }
        }

        private void displayHtml(Uri pageHtml)
        {
            //Affiche la webView avec la page html correspondate !
            WebContainer.Opacity = 0.5;
            WebContainer.Navigate(pageHtml);
        }
    }
}
