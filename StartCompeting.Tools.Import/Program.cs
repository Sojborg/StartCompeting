using Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;
using Core.Dtos;


namespace StartCompeting.Tools.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("activity.gpx");
            XmlNode headNode = xmlDoc.SelectSingleNode("/gpx");

            XmlNode nameNode = headNode.SelectSingleNode("trk/name");
            var gpsCoordsList = headNode.SelectNodes("trk/trkseg/trkpt");

            var gpsCoordList = new List<GpsCoordDto>();

            foreach(XmlNode node in gpsCoordsList)
            {
                var workoutGpsCoord = new GpsCoordDto();

                var coordTime = node.SelectSingleNode("time");
                var convertedTime = Convert.ToDateTime(coordTime.InnerText);
                workoutGpsCoord.Timestamp = convertedTime;

                var elevation = node.SelectSingleNode("ele");
                var convertedEle = Convert.ToDouble(elevation.InnerText.Replace('.', ','));
                workoutGpsCoord.Elevation = convertedEle;

                var longtitude = node.Attributes.GetNamedItem("lon").Value;
                var convertedLong = Convert.ToDouble(longtitude.Replace('.', ','));
                workoutGpsCoord.Longtitude = convertedLong;

                var latitude = node.Attributes.GetNamedItem("lat").Value;
                var convertedLat = Convert.ToDouble(latitude.Replace('.', ','));
                workoutGpsCoord.Latitude = convertedLat;

                gpsCoordList.Add(workoutGpsCoord);
            }

            var workout = new WorkoutDto();
            workout.Name = nameNode.InnerText;
            workout.StartDateTime = DateTime.Now;
            workout.EndDateTime = DateTime.Now.AddMinutes(30);
            workout.GpsCoords = gpsCoordList;

            var client = new HttpClient();
            var response = client.PostAsJsonAsync("http://localhost:60571/api/workoutimport", workout).Result;

            Console.WriteLine("doc name: " + nameNode.InnerText);

            Console.ReadLine();
        }
    }
}
