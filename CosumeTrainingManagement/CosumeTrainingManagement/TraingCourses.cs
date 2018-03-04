using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosumeTrainingManagement
{
    public class TraingCourses
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public string CourseDurationHrs { get; set; }
        public Nullable<decimal> CourseFee { get; set; }
    }
}
