using ExpenseAppMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseAppMvc.Controllers
{
    public class AccountantController : Controller
    {
        Context c = new Context();
        // GET: Accountant
        public ActionResult Index()
        {
            // var expenseForms = c.ExpenseForms.Where(x=> x.IsDeleted == true).ToList();
            var expenseForms = c.ExpenseForms.Where(x => x.ExpenseStatusId == 1).ToList();
            return View(expenseForms.ToList());
        }
        public ActionResult Search(string p)
        {
            var expenseForms = from x in c.ExpenseForms select x;
            if (!string.IsNullOrEmpty(p))
            {
                expenseForms = expenseForms.Where(y => y.Description.Contains(p) || y.RejectReason.Contains(p));
            }
            return View(expenseForms.ToList());
        }

        public ActionResult Payment(int id)
        {
            List<SelectListItem> value = (from x in c.Currencies.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Code,
                                              Value = x.Id.ToString()
                                          }).ToList();

            List<SelectListItem> uservalue = (from x in c.Users.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.Id.ToString()
                                              }).ToList();

            List<SelectListItem> expenseStatusValue = (from x in c.ExpenseStatuses.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.Id.ToString()
                                                       }).ToList();
            ViewBag.newvalue = value;
            ViewBag.newuser = uservalue;
            ViewBag.newExpenseStatusValue = expenseStatusValue;
            var expenseFormValue = c.ExpenseForms.Find(id);
            return View("Payment", expenseFormValue);
        }

        public ActionResult PaymentProcess(int id)
        {
            var value = c.ExpenseForms.Find(id);
            value.ExpenseStatusId = 3;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}