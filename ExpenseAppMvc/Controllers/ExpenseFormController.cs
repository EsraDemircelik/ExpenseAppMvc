using ExpenseAppMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseAppMvc.Controllers
{
    public class ExpenseFormController : Controller
    {

        Context c = new Context();
        // GET: ExpenseForm
        [Authorize]
        public ActionResult Index()
        {
            var username = (string)Session["Username"];
            var id = c.Users.Where(x => x.Username == username.ToString()).Select(y => y.Id).FirstOrDefault();
            var expenseForms = from x in c.ExpenseForms select x;
            expenseForms = expenseForms.Where(x => x.UserId == id);

            //var degerler = c.ExpenseForms.Where(x => x.UserId == id).Select(y=>y.IsDeleted == true).ToList();
            //return View(degerler);
            return View(expenseForms.ToList());
        }
        public ActionResult RejectReason()
        {
            var username = (string)Session["Username"];
            var id = c.Users.Where(x => x.Username == username.ToString()).Select(y => y.Id).FirstOrDefault();
            var expenseForms = from x in c.ExpenseForms select x;
            expenseForms = expenseForms.Where(x => x.UserId == id);

            //var degerler = c.ExpenseForms.Where(x => x.UserId == id).Select(y=>y.IsDeleted == true).ToList();
            //return View(degerler);
            return View(expenseForms.ToList());
        }

        public ActionResult Onay()
        {
            var username = (string)Session["Username"];
            var id = c.Users.Where(x => x.Username == username.ToString()).Select(y => y.Id).FirstOrDefault();
            var expenseForms = from x in c.ExpenseForms select x;
            expenseForms = expenseForms.Where(x => x.UserId == id);

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


        [HttpGet]
        public ActionResult NewExpenseForm()
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
            return View();
        }
        [HttpPost]
        public ActionResult NewExpenseForm(ExpenseFormHistory expense)
        {
            c.expenseFormHistories.Add(expense);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NewExpenseFormHistory()
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
            return View();
        }
        [HttpPost]
        public ActionResult NewExpenseFormHistory(ExpenseFormHistory expense)
        {
            c.expenseFormHistories.Add(expense);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExpenseFormDelete(int id)
        {
            var value = c.ExpenseForms.Find(id);
            var historyvalue = c.ExpenseHistories.Find(id);
            value.IsDeleted = false;
            historyvalue.IsExpenseDeleted = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExpenseFormUpdate(int id)
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
            return View("ExpenseFormUpdate", expenseFormValue);
        }

        public ActionResult ExpenseFormInformation(ExpenseForm expenseForm)
        {
            var expenseFormValue = c.ExpenseForms.Find(expenseForm.Id);
            expenseFormValue.Description = expenseForm.Description;
            expenseFormValue.RejectReason = expenseForm.RejectReason;
            expenseFormValue.CreateDate = expenseForm.CreateDate;
            expenseFormValue.IsDeleted = expenseForm.IsDeleted;
            expenseFormValue.CurrencyId = expenseForm.CurrencyId;
            expenseFormValue.ExpenseStatusId = expenseForm.ExpenseStatusId;
            expenseFormValue.UserId = expenseForm.UserId;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult ExpenseFormHistoryUpdate(int id)
        //{
        //    List<SelectListItem> value = (from x in c.Currencies.ToList()
        //                                  select new SelectListItem
        //                                  {
        //                                      Text = x.Code,
        //                                      Value = x.Id.ToString()
        //                                  }).ToList();

        //    List<SelectListItem> uservalue = (from x in c.Users.ToList()
        //                                      select new SelectListItem
        //                                      {
        //                                          Text = x.Name,
        //                                          Value = x.Id.ToString()
        //                                      }).ToList();

        //    List<SelectListItem> expenseStatusValue = (from x in c.ExpenseStatuses.ToList()
        //                                               select new SelectListItem
        //                                               {
        //                                                   Text = x.Name,
        //                                                   Value = x.Id.ToString()
        //                                               }).ToList();
        //    ViewBag.newvalue = value;
        //    ViewBag.newuser = uservalue;
        //    ViewBag.newExpenseStatusValue = expenseStatusValue;
        //    var expenseFormValue = c.ExpenseForms.Find(id);
        //    return View("ExpenseFormHistoryUpdate", expenseFormValue);
        //}

        //public ActionResult ExpenseFormHistoryInformation(ExpenseFormHistory expenseFormHistory)
        //{
        //    var expenseFormValue = c.expenseFormHistories.Find(expenseFormHistory.Id);
        //    expenseFormValue.ExpenseFormDescription = expenseFormHistory.ExpenseFormDescription;
        //    expenseFormValue.ExpenseFormRejectReason = expenseFormHistory.ExpenseFormRejectReason;
        //    expenseFormValue.CreateDate = expenseFormHistory.CreateDate;
        //    expenseFormValue.IsExpenseFormDeleted = expenseFormHistory.IsExpenseFormDeleted;
        //    expenseFormValue.ExpenseFormCurrencyId = expenseFormHistory.ExpenseFormCurrencyId;
        //    expenseFormValue.ExpenseFormStatusId = expenseFormHistory.ExpenseFormStatusId;
        //    expenseFormValue.UserId = expenseFormHistory.UserId;

        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult ApprovalProcess(int id)
        {
            var value = c.ExpenseForms.Find(id);
            value.ExpenseStatusId = 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
