using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TraningManagementServices.Contract;
using TraningManagementServices.DataAccess;

namespace TraningManagementServices.Implementation
{
    public class TraningCourses :ITraingCourses,IDisposable
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public string CourseDurationHrs { get; set; }
        public Nullable<decimal> CourseFee { get; set; }

        private TrainingManagementDBEntities _dbContext;
        private ILogger _log;
        
        public TraningCourses()
        {
            _dbContext = new TrainingManagementDBEntities();
            _log = new Logger();
            
        }
        public List<TraningCourses> GetAllCourses()
        {
            var list = new List<TraningCourses>();
            try
            {
                using (_dbContext)
                {
                    var courses = _dbContext.Courses.ToList();
                   // Mapper.Configuration(c => c.CreateMap<Course, TraningCourses>());
                    list = Mapper.Map<List<Course>, List<TraningCourses>>(courses);
                }
                return list;
            }
            catch(Exception ex)
            {
                _log.LogError(ex);
                return list;
            }
        }

        public bool AddNewCourse(TraningCourses traingcourse)
        {
            try
            {
                using (_dbContext)
                {
                   
                    var course = Mapper.Map<TraningCourses, Course>(traingcourse);
                    _dbContext.Courses.Add(course);
                    _dbContext.SaveChanges();
                    return true;
                }                
            }
            catch(Exception ex)
            {
                _log.LogError(ex);
                return false;
            }
        }

        public void Dispose()
        {
           //TODO: dispose resources
        }
    }
}