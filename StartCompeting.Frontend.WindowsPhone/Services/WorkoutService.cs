using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StartCompeting.Frontend.WindowsPhone.Services
{
    public class WorkoutService
    {
        const string apiUrl = @"http://192.168.0.14/StartCompeting/api/Workout";

        public void SaveWorkout(WorkoutViewModel workoutViewModel)
        {
            var wc = new WebClient();
            wc.UploadStringCompleted += new UploadStringCompletedEventHandler(webClient_SaveWorkoutCompleted);

            var json = JsonConvert.SerializeObject(workoutViewModel);
            var uri = new Uri(apiUrl, UriKind.Absolute);
            wc.Headers[HttpRequestHeader.Accept] = "application/json";
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.UploadStringAsync(uri, "POST", json);
            
        }

        private void webClient_SaveWorkoutCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Console.WriteLine("Saved!");
        }
    }
}
