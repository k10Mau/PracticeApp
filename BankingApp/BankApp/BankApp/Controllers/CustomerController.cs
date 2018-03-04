using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankApp.Controllers
{
    [Authorize (Roles ="Banker")]
    public class CustomerController : Controller
    {
        // GET: Customer
        private BankDBEntities dbcontext =new BankDBEntities();
        public ActionResult Index()
        {
            //todo: display all customers in grid
            var model = dbcontext.Customers.Where(c => c.IsActive).ToList();
            return View(model);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            //todo: dispaly single customer details
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.UserList = new SelectList(dbcontext.AspNetUsers.Where(a => a.AspNetRoles.All(r => r.Name == "Customer"))
                .Select(a => new { UserId = a.Id, Name = a.UserName })
                .ToList(), "UserId", "Name");
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "AccountNumber, AccountBalance,UserId")]Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    customer.IsActive = true;
                    customer.CreateDate = DateTime.Now;
                    dbcontext.Customers.Add(customer);
                    dbcontext.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
