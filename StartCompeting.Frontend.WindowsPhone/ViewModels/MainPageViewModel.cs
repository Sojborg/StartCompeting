using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Practices.Prism.Commands;
using NExtra.Geo;
using StartCompeting.Frontend.WindowsPhone.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Windows.Devices.Geolocation;

namespace StartCompeting.Frontend.WindowsPhone.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private GeoCoordinateWatcher _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        private MapPolyline _line;
        private DispatcherTimer _timer = new DispatcherTimer();
        private long _startTime;
        private DateTime _workoutStartTime;
        private List<GeoCoordinate> _workoutCoordinates;
        private double _millisPerKilometer;
        private WorkoutService _workoutService;
        //ID_CAP_LOCATION
        private double _kilometres;
        private long _previousPositionChangeTick;

        public MainPageViewModel(Map map)
        {
            StartCommand = new DelegateCommand<object>(this.OnStart, this.CanStart); 
            ShowMyLocationOnTheMap();
            StartCompetingMap = map;

            // create a line which illustrates the run
            _line = new MapPolyline();
            _line.StrokeColor = Colors.Red;
            _line.StrokeThickness = 5;
            StartCompetingMap.MapElements.Add(_line);
            NotifyPropertyChanged("StartCompetingMap");

            _watcher.PositionChanged += Watcher_PositionChanged;

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _workoutCoordinates = new List<GeoCoordinate>();
            _workoutService = new WorkoutService();
        }

        private Map _map;
        public Map StartCompetingMap
        {
            get { return _map; }
            set
            {
                _map = value;
                NotifyPropertyChanged("StartCompetingMap");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);
            Time = runTime.ToString(@"hh\:mm\:ss");
        }

        public ICommand StartCommand { get; private set; }
        
        private string _tester;

        public string Tester { get { return "Tester"; } }

        private string _time = "00:00:00";
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                NotifyPropertyChanged("Time");
            }
        }

        private string _distance = "0";
        public string Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                NotifyPropertyChanged("Distance");
            }
        }

        private string _calories = "0";
        public string Calories
        {
            get { return _calories; }
            set
            {
                _calories = value;
                NotifyPropertyChanged("Calories");
            }
        }

        private string _pace = "0";
        public string Pace
        {
            get { return _pace; }
            set
            {
                _pace = value;
                NotifyPropertyChanged("Pace");
            }
        }

        private string _startButtonText = "Start";
        public string StartButtonText
        {
            get { return _startButtonText; }
            set
            {
                _startButtonText = value;
                NotifyPropertyChanged("StartButtonText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SaveWorkout()
        {
            // Call web api service to save workout
            TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);
            var workoutViewModel = new WorkoutViewModel();
            workoutViewModel.StartDateTime = _workoutStartTime;
            workoutViewModel.Length = Convert.ToDecimal(_kilometres);
            workoutViewModel.ElapsedHours = runTime.Hours;
            workoutViewModel.ElapsedMinutes = runTime.Minutes;
            workoutViewModel.ElapsedSeconds = runTime.Seconds;
            workoutViewModel.AvgSpeed = Convert.ToDecimal(_millisPerKilometer);
            workoutViewModel.RaceTypeId = 1;

            _workoutService.SaveWorkout(workoutViewModel);
        }

        private void OnStart(object obj)
        {
            if (_timer.IsEnabled)
            {
                _watcher.Stop();
                _timer.Stop();
                SaveWorkout();
                StartButtonText = "Start";
            }
            else
            {
                _watcher.Start();
                _timer.Start();
                _startTime = System.Environment.TickCount;
                _workoutStartTime = DateTime.Now;
                StartButtonText = "Stop";
            }
        }

        private bool CanStart(object arg)
        {
            return true;
        }

        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var coord = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);

            if (_line.Path.Count > 0)
            {
                _workoutCoordinates.Add(coord);
                var previousPoint = _line.Path.Last();
                var distance = coord.GetDistanceTo(previousPoint);
                _millisPerKilometer = (1000.0 / distance) * (System.Environment.TickCount - _previousPositionChangeTick);
                _kilometres += distance / 1000.0;

                Pace = TimeSpan.FromMilliseconds(_millisPerKilometer).ToString(@"mm\:ss");
                Distance = string.Format("{0:f2} km", _kilometres);
                Calories = string.Format("{0:f0}", _kilometres * 65);

                PositionHandler handler = new PositionHandler();
                var heading = handler.CalculateBearing(new Position(previousPoint), new Position(coord));
                StartCompetingMap.SetView(coord, StartCompetingMap.ZoomLevel, heading, MapAnimationKind.Parabolic);

                //ShellTile.ActiveTiles.First().Update(new IconicTileData()
                //{
                //    Title = "startCompeting",
                //    WideContent1 = string.Format("{0:f2} km", _kilometres),
                //    WideContent2 = string.Format("{0:f0} calories", _kilometres * 65),
                //});
            }
            else
            {
                StartCompetingMap.Center = coord;
            }

            _line.Path.Add(coord);
            _previousPositionChangeTick = System.Environment.TickCount;
        }

        private async void ShowMyLocationOnTheMap()
        {
            // Get my current location.
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            GeoCoordinate myGeoCoordinate =
            CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);

            // Make my current location the center of the Map.
            StartCompetingMap.Center = myGeoCoordinate;
            StartCompetingMap.ZoomLevel = 13;

            // Create a small circle to mark the current location.
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;

            // Create a MapOverlay to contain the circle.
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = myGeoCoordinate;

            // Create a MapLayer to contain the MapOverlay.
            MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);

            // Add the MapLayer to the Map.
            StartCompetingMap.Layers.Add(myLocationLayer);
        }
    }
}
