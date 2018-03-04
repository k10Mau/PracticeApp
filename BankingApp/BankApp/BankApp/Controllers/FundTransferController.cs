using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankApp.Controllers
{
    [Authorize(Roles ="Customer")]
    public class FundTransferController : Controller
    {
        private BankDBEntities dbcontext = new BankDBEntities();
        // GET: FundTransfer
        public ActionResult Index()
        {
            return View();
        }

        // GET: FundTransfer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FundTransfer/Create
        public ActionResult TransferFund()
        {
            var currentCustomer = dbcontext.AspNetUsers.FirstOrDefault(u => u.Email == User.Identity.Name);
            var model = dbcontext.TransactionHistories.FirstOrDefault(t => t.Customer.UserId == currentCustomer.Id);
            ViewBag.TransferType = new SelectList(dbcontext.TransactionTypes.Select(a => new { TransferType = a.Id, TypeName = a.TypeName }).ToList(), "TransferType", "TypeName"); 
            return View(model);
        }

        // POST: FundTransfer/Create
        [HttpPost]
        public ActionResult TransferFund([Bind(Include= "CustomerId, MoneyTransfered, TransferType")]TransactionHistory transactiondetail)
        {
            try
            {
                // TODO: Add insert logic here
                var currentUser = dbcontext.AspNetUsers.FirstOrDefault(u => u.Email == User.Identity.Name);
                //  transactiondetail.Customer = ;
                transactiondetail.Customer = dbcontext.Customers.FirstOrDefault(c => c.UserId == currentUser.Id);
                transactiondetail.CustomerId = transactiondetail.Customer.Id;
                dbcontext.TransactionHistories.Add(transactiondetail);
                if (transactiondetail.TransferType == 1)
                {
                    transactiondetail.Customer.AccountBalance -= transactiondetail.MoneyTransfered;
                }
                else
                {
                    transactiondetail.Customer.AccountBalance += transactiondetail.MoneyTransfered;
                }
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: FundTransfer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FundTransfer/Edit/5
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

        // GET: FundTransfer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FundTransfer/Delete/5
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
