using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TraningManagementServices.Implementation;

namespace TraningManagementServices.Contract
{
    public interface ITraingCourses
    {
        List<TraningCourses> GetAllCourses();
        bool AddNewCourse(TraningCourses course);
    }
}