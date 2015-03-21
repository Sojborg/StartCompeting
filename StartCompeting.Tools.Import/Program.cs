using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

            foreach(XmlNode node in gpsCoordsList)
            {
                var workoutGpsCoord = new WorkoutGpsCoord();

                var coordTime = node.SelectSingleNode("time");
                var convertedTime = Convert.ToDateTime(coordTime.InnerText);
                workoutGpsCoord.TimeStamp = convertedTime;

                var elevation = node.Attributes.GetNamedItem("ele").Value;
                var convertedEle = Convert.ToDecimal(elevation.Replace('.', ','));
                workoutGpsCoord.Elevation = convertedEle;

                var longtitude = node.Attributes.GetNamedItem("lon").Value;
                var convertedLong = Convert.ToDecimal(longtitude.Replace('.', ','));
                workoutGpsCoord.Longtitude = convertedLong;

                var latitude = node.Attributes.GetNamedItem("lat").Value;
                var convertedLat = Convert.ToDecimal(latitude.Replace('.', ','));
                workoutGpsCoord.Latitude = convertedLat;
            }

            Console.WriteLine("doc name: " + nameNode.InnerText);

            Console.ReadLine();
        }
    }
}
