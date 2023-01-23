using ExpenseAppMvc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ExpenseAppMvc.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        //// GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var expenseForms = c.expenseFormHistories.Where(x => x.IsExpenseFormDeleted == true).ToList();
            return View(expenseForms);
        }

        public ActionResult ExpenseHistory()
        {

            var expense = c.ExpenseHistories.Where(x => x.IsExpenseDeleted == true).ToList();
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

        public ActionResult Report()
        {
            var value1 = c.ExpenseForms.Count().ToString();
            ViewBag.v1 = value1;


            var value2 = (from x in c.Expenses orderby x.Amount descending select x.Description).FirstOrDefault();
            ViewBag.v2 = value2;

            var value3 = (from x in c.Expenses orderby x.Amount ascending select x.Description).FirstOrDefault();
            ViewBag.v3 = value3;

            var value4 = c.Expenses.Sum(x => x.Amount).ToString();
            ViewBag.v4 = value4;

            DateTime today = DateTime.Today;
            var value5 = c.Expenses.Count(x => x.CreateDate == today).ToString();
            ViewBag.v5 = value5;

            var value6 = c.Expenses.Where(x => x.CreateDate == today).Sum(y => y.Amount).ToString();
            ViewBag.v6 = value6;

            return View();
        }

        public ActionResult Grafik()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = c.Expenses.ToList();
            result.ToList().ForEach(x=> xvalue.Add(x.Description));
            result.ToList().ForEach(x=> xvalue.Add(x.Amount));
            var grafik = new Chart(width: 800,height:800)
                .AddTitle("Grafik")
                .AddSeries(chartType:"Column",name:"Amount"
                ,xValue:xvalue,
                yValues:yvalue);
            return File(grafik.ToWebImage().GetBytes(),"image/jpeg");
        }
    }
}