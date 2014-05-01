using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using StartCompeting.Frontend.WindowsPhone.Resources;
using System.Device.Location;
using System.Windows.Threading;
using NExtra.Geo;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Media;
using Windows.Devices.Geolocation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using StartCompeting.Frontend.WindowsPhone.Services;
using StartCompeting.Frontend.WindowsPhone.ViewModels;

namespace StartCompeting.Frontend.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent(); 
            this.DataContext = new MainPageViewModel(Map);
        }
    }
}