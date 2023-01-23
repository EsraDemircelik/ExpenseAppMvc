using ExpenseAppMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseAppMvc.Controllers
{
    public class ManagerController : Controller
    {

        Context c = new Context();
        // GET: Manager
        [Authorize]
        public ActionResult Index()
        {
            ///-------------------
            //var expenseForms = c.ExpenseForms.Where(x => x.ExpenseStatusId == 2).ToList();
            //return View(expenseForms.ToList());

            //var degerler = c.ExpenseForms.Where(x => x.UserId == id).ToList();

            var username = (string)Session["Username"];
            var id = c.Users.Where(x => x.Username == username.ToString()).Select(y => y.Id).FirstOrDefault();
            var employee = c.Users.Where(x => x.ManagerId == id).Select(y => y.Id).FirstOrDefault();
            var degerler = c.ExpenseForms.Where(x => x.UserId == employee).ToList();
            return View(degerler);


            //var username = (string)Session["Username"];
            //var id = c.Users.Where(x => x.Username == username.ToString()).Select(y => y.Id).FirstOrDefault();
            //var employee = c.Users.Where(x => x.ManagerId == id).Select(y => y.Id).ToList();
            //var degerler = c.ExpenseForms.Where(x => x.UserId == employee).ToList();
            //return View(degerler);

            //var username = (string)Session["Username"];
            //var id = c.Users.Where(x => x.Username == username.ToString()).Select(y => y.Id).FirstOrDefault();
            //var employee = c.Users.Where(x => x.ManagerId == id).Select(y => y.Id).ToString();
            //var degerler = c.ExpenseForms.Where(x => x.Id == employee).ToList();
            //return View(degerler);
        }

        public ActionResult Details(int id)
        {
            var value = c.ExpenseForms.Find(id);
            var expense = c.Expenses.Where(x => x.ExpenseFormId == id).ToList();
            return View(expense);
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

        public ActionResult RejectReason(int id)
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
            return View("RejectReason", expenseFormValue);
        }
    }
}