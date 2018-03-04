using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TraningManagementServices.Contract;
using TraningManagementServices.Implementation;

namespace TraniningManagementAPI.Controllers
{
    [AllowAnonymous]
    
    [EnableCors(origins: "*", headers:"*",methods:"*")]
    public class TrainingCoursesAPIController : ApiController
    {
        private ITraingCourses _trainingCourses;
        private ILogger _log;
        public TrainingCoursesAPIController()
        {
            _trainingCourses = new TraningCourses();
            _log = new Logger();
        }

        // GET: api/TrainingManagement
        [HttpGet]
        [Route("api/TrainingManagement/GetTrainingCourses")]
        public HttpResponseMessage GetTrainingCourses()
        {
            try
            {
                List<TraningCourses> courses = new List<TraningCourses>();
                courses = _trainingCourses.GetAllCourses();
                if(courses.Count>0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, courses);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No Courses available.");
                }
            }
            catch(Exception ex)
            {
                _log.LogError(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong, Please try again!!");
            }
        }

        // POST: api/TrainingManagement
        [HttpPost]
        [Route("api/TrainingManagement/AddCourse")]
        public HttpResponseMessage AddCourse(TraningCourses course)
        {
            try
            {
                var result = _trainingCourses.AddNewCourse(course);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Course added successfully!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured while adding course");
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong, Please try again!!");
            }
        }
    }
}
