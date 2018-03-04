using MSTest.PersonDetailsApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MSTest.PersonDetailsApp.Contract
{
    public interface IPersonDetailsService
    {
        bool AddPersonDetails(PersonDetail objPerson, HttpPostedFileBase objFile);
    }
}
