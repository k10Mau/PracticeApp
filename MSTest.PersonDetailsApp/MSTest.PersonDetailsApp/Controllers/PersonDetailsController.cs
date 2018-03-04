using MSTest.PersonDetailsApp.DAL;
using MSTest.PersonDetailsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSTest.PersonDetailsApp.Controllers
{
    [Authorize]
    public class PersonDetailsController : Controller
    {
        // GET: PersonDetails
        private PersonDetailsService _service;

        public PersonDetailsController()
        {
            this._service = new PersonDetailsService();
        }
        public ActionResult Index()
        {
            IEnumerable<PersonDetail> list = new List<PersonDetail>();
            return View(list);
        }

        // GET: PersonDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonDetails/Create
        public ActionResult Create()
        {
            PersonDetail p = new PersonDetail();
            return View(p);
        }

        // POST: PersonDetails/Create
        [HttpPost]
        public ActionResult Create(PersonDetail model,HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _service.AddPersonDetails(model, file);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
