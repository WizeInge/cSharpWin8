using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;

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



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LesSeptMerveillesDuMonde
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   // Pétra
            myMap.Center = new Location(30.3251734, 35.4425807);
            myMap.ZoomLevel = 18;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {   // Christ
            myMap.Center = new Location(-22.952703, -43.211299);
            myMap.ZoomLevel = 18;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {   // Machu picchu
            myMap.Center = new Location(-13.1631412, -72.5449628);
            myMap.ZoomLevel = 18;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {   // Chichen itza
            myMap.Center = new Location(20.6826180, -88.5686445);
            myMap.ZoomLevel = 18;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {   //colisée
            myMap.Center = new Location(41.8902102, 12.4922308);
            myMap.ZoomLevel = 19;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {   // Taj Mahal
            myMap.Center = new Location(27.173891, 78.042068);
            myMap.ZoomLevel = 18;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {   // Pyramide
            myMap.Center = new Location(29.9757396, 31.1320991);
            myMap.ZoomLevel = 17;
        }
    }
}
