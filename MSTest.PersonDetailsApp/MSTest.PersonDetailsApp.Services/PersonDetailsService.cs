using MSTest.PersonDetailsApp.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSTest.PersonDetailsApp.DAL;
using System.Data.Entity;
using System.Web;
using System.IO;
namespace MSTest.PersonDetailsApp.Services
{
    public class PersonDetailsService : IPersonDetailsService
    {
        private readonly IGenericRepository<PersonDetail> _dbPerson;
        private readonly IGenericRepository<PersonFile> _dbFile;
        private readonly IUnitOfWork _unitOfWork;
        private PersonDetailsDBEntities _dbContext;
        public PersonDetailsService()
        {
            _dbContext = new PersonDetailsDBEntities();
            _dbPerson = new GenericRepository<PersonDetail>(_dbContext);
            _dbFile = new GenericRepository<PersonFile>(_dbContext);
            _unitOfWork = new UnitOfWork(_dbContext);
        }
        public bool AddPersonDetails(PersonDetail objPerson, HttpPostedFileBase file)
        {
            var db = new PersonDetailsDBEntities();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                
                try
                {
                    _dbPerson.Insert(objPerson);

                    _unitOfWork.SaveChanges();

                    PersonFile objFile = UploadFile(objPerson, file);

                    _dbFile.Insert(objFile);
                    _unitOfWork.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    //log status

                }
            }
        }

        private static PersonFile UploadFile(PersonDetail objPerson, HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/PersonFiles"), fileName);
            file.SaveAs(path);
            var objFile = new PersonFile()
            {
                FileName = fileName,
                IsActive = true,
                PersonId = objPerson.Id
            };
            return objFile;
        }
    }
}
