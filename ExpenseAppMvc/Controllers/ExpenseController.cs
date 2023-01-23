using ExpenseAppMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseAppMvc.Controllers
{
    public class ExpenseController : Controller
    {
        Context c = new Context();
        // GET: Expense
        public ActionResult Index()
        {
            var expense = c.Expenses.Where(x => x.IsDeleted == true).ToList();
            var toplam = c.Expenses.Where(x => x.ExpenseFormId == x.ExpenseFormId && x.IsDeleted == true).Sum(x => x.Amount);
            ViewBag.toplam = "Toplam tutar: " + toplam;

            return View(expense);
        }
        public ActionResult Search(string p)
        {
            var expenses = from x in c.Expenses select x;
            if (!string.IsNullOrEmpty(p))
            {
                //.Where(y => y.Description.Contains(p));
                expenses = expenses.Where(y => y.Description.Contains(p));
            }
            return View(expenses.ToList());
        }

        [HttpGet]
        public ActionResult NewExpense()
        {
            List<SelectListItem> value = (from x in c.ExpenseForms.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Description,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.valueDescription = value;

            return View();
        }
        [HttpPost]
        public ActionResult NewExpense(Expense expense, ExpenseHistory expenseHistory)
        {
            c.Expenses.Add(expense);
            c.SaveChanges();

            c.ExpenseHistories.Add(expenseHistory);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NewExpenseHistory()
        {
            List<SelectListItem> value = (from x in c.ExpenseHistories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ExpenseDescription,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.valueDescription = value;

            return View();
        }
        [HttpPost]
        public ActionResult NewExpenseHistory(ExpenseHistory expenseHistory)
        {
            c.ExpenseHistories.Add(expenseHistory);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExpense(int id)
        {
            var value = c.Expenses.Find(id);
            value.IsDeleted = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ExpenseGetir(int id)
        {
            List<SelectListItem> value = (from x in c.ExpenseForms.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Description,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.valueDescription = value;

            var formvalue = c.Expenses.Find(id);
            return View("ExpenseGetir", formvalue);
        }
        public ActionResult ExpenseUpdate(Expense expense)
        {
            var updateExpense = c.Expenses.Find(expense.Id);
            updateExpense.Description = expense.Description;
            updateExpense.Amount = expense.Amount;
            updateExpense.CreateDate = expense.CreateDate;
            updateExpense.IsDeleted = expense.IsDeleted;
            updateExpense.ExpenseFormId = expense.ExpenseFormId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}