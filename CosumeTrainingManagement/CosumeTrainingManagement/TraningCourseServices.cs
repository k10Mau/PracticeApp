using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CosumeTrainingManagement
{
    public class TraningCourseServices
    {
        private static string _apiUrl = "http://localhost:52274/api/TrainingManagement/";

        public static async Task saveCourse()
        {
            using (var client = new HttpClient())
            {
                TraingCourses course = new TraingCourses();
                course.CourseTitle = "MVC basic";
                course.CourseDescription = "This is course for beginners";
                course.CourseDurationHrs = "4";
                course.CourseFee = 5000;
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.PostAsJsonAsync("AddCourse", JsonConvert.SerializeObject(course));
                if(result.IsSuccessStatusCode)
                {
                    Console.WriteLine(result.Content);
                }
                else
                {
                    Console.WriteLine(result.StatusCode);
                }
                Console.ReadLine();
            }
        }
        public static async Task GetCourses()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("GetTrainingCourses");
                result.EnsureSuccessStatusCode();
                if(result.IsSuccessStatusCode)
                {
                    List<TraingCourses> courses = await result.Content.ReadAsAsync<List<TraingCourses>>();
                    foreach (var course in courses)
                    {
                        Console.WriteLine(course.CourseTitle, course.CourseDescription);
                    }
                }
                else
                {
                    Console.WriteLine("error!!");
                }
                
                //Console.ReadLine();
            }
        }
    }
}
