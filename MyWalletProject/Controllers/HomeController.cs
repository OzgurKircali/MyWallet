using DevExpress.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWalletProject.Controllers;
using MyWalletProject.Models;
using System.Windows.Forms;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;


namespace MyWalletProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Context DbContext = new Context();

        [HttpGet]
        public ActionResult Index(int? Year, int? MonthCount)
        {


            try
            {


                decimal MonthlyExpenseHolder;
                decimal MonthlyIncomeHolder;
                decimal MonthlyBalanceHolder;
                decimal BalanceHolder;
                HomePageModel homePageModel = new HomePageModel();

                homePageModel.MonthCount = MonthCount != null ? MonthCount.Value : DateTime.Now.Month;
                homePageModel.Year = Year != null ? Year.Value : DateTime.Now.Year;




                if (Session["idsession"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {

                    string IdHldr = GetUserId();
                    string MonthlyViewId = string.Concat(homePageModel.Year, homePageModel.MonthCount) + IdHldr;



                    if (DbContext.V_MonthlyView.Any(x => x.ViewID == MonthlyViewId) == false)
                    {
                        MonthlyExpenseHolder = 0;
                        MonthlyBalanceHolder = 0;
                        MonthlyIncomeHolder = 0;
                    }
                    else
                    {
                        var MonthlyModel = DbContext.V_MonthlyView.Single(x => x.ViewID == MonthlyViewId);

                        MonthlyExpenseHolder = MonthlyModel.Expense;
                        MonthlyIncomeHolder = MonthlyModel.Income;
                        MonthlyBalanceHolder = MonthlyModel.Balance;
                    }

                    if (DbContext.V_AllTimeBalance.Any(x => x.Id == IdHldr) == false)
                    {
                        BalanceHolder = 0;
                    }
                    else
                    {
                        var BalanceModel = DbContext.V_AllTimeBalance.Single(x => x.Id == IdHldr);
                        BalanceHolder = BalanceModel.Balance;

                    }



                    homePageModel.Balance = "₺" + string.Format("{0:n}", BalanceHolder);
                    homePageModel.MonthlyExpense = "₺" + string.Format("{0:n}", MonthlyExpenseHolder);
                    homePageModel.MonthlyIncome = "₺" + string.Format("{0:n}", MonthlyIncomeHolder);
                    homePageModel.MonthlyBalance = "₺" + string.Format("{0:n}", MonthlyBalanceHolder);

                    if (DateTime.Now.Day < 10)
                    {
                        homePageModel.Date = "0" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    }
                    else
                    {
                        homePageModel.Date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    }



                    Notifications notifications = new Notifications();
                    notifications = InformNotification(homePageModel.Year, homePageModel.MonthCount);

                    ViewBag.DifferenceNotification = notifications.DifferenceNotification;
                    ViewBag.DifferenceBalanceNotification = notifications.DifferenceBalanceNotification;
                    ViewBag.DifferencePreviousBalanceNotification = notifications.DifferencePreviousBalanceNotification;
                    ViewBag.MaxExpenseNotification = notifications.MaxExpenseNotification;
                    ViewBag.MaxCategory = notifications.MaxCategory;




                    if (homePageModel.MonthCount == 1)
                    {
                        homePageModel.Month = "Ocak";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 2)
                    {
                        homePageModel.Month = "Şubat";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 3)
                    {
                        homePageModel.Month = "Mart";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 4)
                    {
                        homePageModel.Month = "Nisan";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 5)
                    {
                        homePageModel.Month = "Mayıs";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 6)
                    {
                        homePageModel.Month = "Haziran";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 7)
                    {
                        homePageModel.Month = "Temmuz";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 8)
                    {
                        homePageModel.Month = "Ağustos";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 9)
                    {
                        homePageModel.Month = "Eylül";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 10)
                    {
                        homePageModel.Month = "Ekim";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 11)
                    {
                        homePageModel.Month = "Kasım";
                        homePageModel.Year = homePageModel.Year;
                    }
                    if (homePageModel.MonthCount == 12)
                    {
                        homePageModel.Month = "Aralık";
                        homePageModel.Year = homePageModel.Year;
                    }

                    return View(homePageModel);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return View();
            }




        }



        public ActionResult MonthDecrease(HomePageModel homePageModel)
        {
            homePageModel.MonthCount -= 1;
            if (homePageModel.MonthCount == 0)
            {
                homePageModel.Year -= 1;
                homePageModel.MonthCount = 12;
            }

            return RedirectToAction("Index", homePageModel);
        }

        public ActionResult MonthIncrease(HomePageModel homePageModel)
        {
            homePageModel.MonthCount += 1;
            if (homePageModel.MonthCount == 13)
            {
                homePageModel.Year += 1;
                homePageModel.MonthCount = 1;
            }
            return RedirectToAction("Index", homePageModel);
        }



        public List<SelectListItem> GetCategories()
        {
            List<SelectListItem> values = (from i in DbContext.TransactionCategories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Category,
                                               Value = i.CategoryID.ToString()
                                           }).ToList();

            return values;
        }

        public List<SelectListItem> GetPeriodTypes()
        {
            List<SelectListItem> values = (from i in DbContext.PeriodTypes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PeriodTypeName,
                                               Value = i.PeriodTypeID.ToString()
                                           }).ToList();

            return values;
        }


        [HttpGet]
        public ActionResult AddExpense()
        {

            ViewBag.Categories = GetCategories();
            return PartialView();

        }

        [HttpPost]
        public ActionResult AddExpense(decimal? ExpenseAmount, DateTime? ExpenseTransactionDate, string ExpenseDescription, TransactionCategory ExpenseCategoryID)
        {
            if (ExpenseAmount == null || ExpenseTransactionDate == null)
            {
                TempData["AddIncomeError"] = "<script>alert('Miktar veya Tarih kısmı boş bırakılamaz');</script>";
            }
            else
            {

                ViewBag.Categories = GetCategories();

                int CatID = int.Parse(ExpenseCategoryID.Category);

                var model = DbContext.Transactions;
                Transaction item = new Transaction();


                item.TransactionID = 1;
                item.TypeID = 2;
                item.AutomaticOrManuelID = 2;
                string IdHldr = GetUserId();






                if (ModelState.IsValid)
                {

                    item.Id = IdHldr;
                    item.TransactionAmount = ExpenseAmount ?? 0;
                    item.CategoryID = CatID;
                    item.TransactionDate = ExpenseTransactionDate ?? DateTime.Now;
                    item.TransactionDescription = ExpenseDescription;

                    model.Add(item);

                    DbContext.SaveChanges();
                }
                else
                {
                    ViewData["EditError"] = "hata:";
                }
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddIncome()
        {

            ViewBag.Categories = GetCategories();
            return PartialView();

        }

        [HttpPost]
        public ActionResult AddIncome(decimal? Amount, DateTime? TransactionDate, string Description, TransactionCategory m)
        {
            

            if (Amount == null || TransactionDate == null)
            {
                TempData["AddIncomeError"] = "<script>alert('Miktar veya Tarih kısmı boş bırakılamaz');</script>";

                

            }
            else { 
                ViewBag.Categories = GetCategories();

                int CatID = int.Parse(m.Category);

                var model = DbContext.Transactions;
                Transaction item = new Transaction();


                item.TransactionID = 1;
                item.TypeID = 1;
                item.AutomaticOrManuelID = 2;
                string IdHldr = GetUserId();




                if (ModelState.IsValid)
                {

                    item.Id = IdHldr;
                    item.TransactionAmount = Amount??0;
                    item.CategoryID = CatID;
                    item.TransactionDate = TransactionDate??DateTime.Now;
                    item.TransactionDescription = Description;

                    model.Add(item);

                    DbContext.SaveChanges();
                }
                else
                {
                    ViewData["EditError"] = "hata:";
                }

                
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult ExpenseViewPartial(HomePageModel homePageModel)
        {
            CheckModelEmpty(homePageModel);
            

            string IdHldr = GetUserId();
            var modelExpense = DbContext.Transactions.Where(x => x.Id == IdHldr && x.TypeID == 2 && x.TransactionDate.Year == homePageModel.Year && x.TransactionDate.Month == homePageModel.MonthCount);
            
            return PartialView("~/Views/Home/_ExpenseViewPartial.cshtml", modelExpense.ToList());
        }

        
        public ActionResult IncomeViewPartial(HomePageModel homePageModel)
        {
            CheckModelEmpty(homePageModel);

            string IdHldr = GetUserId();
            var modelIncome = DbContext.Transactions.Where(x => x.Id == IdHldr && x.TypeID == 1 && x.TransactionDate.Year == homePageModel.Year && x.TransactionDate.Month == homePageModel.MonthCount);

            return PartialView("~/Views/Home/_IncomeViewPartial.cshtml", modelIncome.ToList());
        }

        public ActionResult RepetitiveIncomeViewPartial()
        {
            string IdHldr = GetUserId();
            var modelRepetitiveIncome = DbContext.RepetitiveTransactions.Where(x => x.Id == IdHldr && x.TypeID == 1 && x.RepetitiveTransactionNextDate > DateTime.Now).OrderBy(x => x.RepetitiveTransactionNextDate).Take(5);
            return PartialView("~/Views/Home/_RepetitiveIncomeViewPartial.cshtml", modelRepetitiveIncome.ToList());
        }
        public ActionResult RepetitiveExpenseViewPartial()
        {
            string IdHldr = GetUserId();
            var modelRepetitiveExpense = DbContext.RepetitiveTransactions.Where(x => x.Id == IdHldr && x.TypeID == 2 && x.RepetitiveTransactionNextDate > DateTime.Now).OrderBy(x => x.RepetitiveTransactionNextDate).Take(5);
            return PartialView("~/Views/Home/_RepetitiveExpenseViewPartial.cshtml", modelRepetitiveExpense.ToList());
        }


        public ActionResult ExpensePieChart(HomePageModel homePageModel)
        {

            CheckModelEmpty(homePageModel);


            string IdHldr = GetUserId();
            var PieChartModel = DbContext.V_ExpenseCategorySums.Where(x => x.Id == IdHldr && x.Year == homePageModel.Year && x.Month == homePageModel.MonthCount).OrderBy(x => x.Sum);
  



            return PartialView("~/Views/Home/ExpensePieChart.cshtml", PieChartModel.ToArray());
        }

       


        [HttpGet]
        public ActionResult AddRepetitiveIncome()
        {

            ViewBag.Categories = GetCategories();
            ViewBag.PeriodTypeNames = GetPeriodTypes();

            return PartialView();

        }

        [HttpPost]
        public ActionResult AddRepetitiveIncome(decimal? RepetitiveIncomeAmount, DateTime? RepetitiveIncomeDate, string RepetitiveIncomeDescription, ForRepetitive RepetitiveIncomeCaretgoryID, int? RepetitiveIncomePeriod, ForRepetitive RepetitiveIncomePeriodTypeID)
        {
            if (RepetitiveIncomePeriod == null || RepetitiveIncomeDate == null || RepetitiveIncomeAmount == null)
            {
                TempData["AddRepetitiveIncomeError"] = "<script>alert('Miktar, Tarih veya Ne kadar sürede bir? kısmı boş bırakılamaz');</script>";
            }
            else
            {



                ViewBag.Categories = GetCategories();
                ViewBag.PeriodTypeNames = GetPeriodTypes();

                int CatID = int.Parse(RepetitiveIncomeCaretgoryID.TransactionCategory.Category);
                int PerID = int.Parse(RepetitiveIncomePeriodTypeID.PeriodType.PeriodTypeName);

                var model = DbContext.RepetitiveTransactions;
                var transactionModel = DbContext.Transactions;
                RepetitiveTransaction item = new RepetitiveTransaction();
                Transaction transactionItem = new Transaction();

                DateTime DateTemp = RepetitiveIncomeDate ?? DateTime.Now;
                int PeriodTemp = RepetitiveIncomePeriod ?? 0;
                item.RepetitiveTransactionID = 1;
                item.TypeID = 1;
                string IdHldr = GetUserId();

                if (PerID == 1)
                {
                    item.RepetitiveTransactionNextDate = DateTemp.AddDays(PeriodTemp);
                }
                if (PerID == 2)
                {
                    item.RepetitiveTransactionNextDate = DateTemp.AddDays(PeriodTemp * 7);
                }
                if (PerID == 3)
                {
                    item.RepetitiveTransactionNextDate = DateTemp.AddMonths(PeriodTemp);
                }
                if (PerID == 4)
                {
                    item.RepetitiveTransactionNextDate = DateTemp.AddYears(PeriodTemp);
                }





                if (ModelState.IsValid)
                {

                    item.Id = IdHldr;
                    item.RepetitiveTransactionAmount = RepetitiveIncomeAmount ?? 0;
                    item.CategoryID = CatID;
                    item.RepetitiveTransactionDate = RepetitiveIncomeDate ?? DateTime.Now;
                    item.RepetitiveTransactionDescription = RepetitiveIncomeDescription;
                    item.PeriodAmount = RepetitiveIncomePeriod ?? 0;
                    item.PeriodTypeID = PerID;

                    model.Add(item);

                    if (RepetitiveIncomeDate == DateTime.Now.Date)
                    {
                        transactionItem.TransactionID = 1;
                        transactionItem.Id = IdHldr;
                        transactionItem.TransactionAmount = RepetitiveIncomeAmount ?? 0;
                        transactionItem.CategoryID = CatID;
                        transactionItem.TransactionDate = RepetitiveIncomeDate ?? DateTime.Now;
                        transactionItem.TransactionDescription = RepetitiveIncomeDescription;
                        transactionItem.TypeID = 1;
                        transactionItem.AutomaticOrManuelID = 1;

                        transactionModel.Add(transactionItem);
                    }

                    DbContext.SaveChanges();
                }
                else
                {
                    ViewData["EditError"] = "hata:";
                }
            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult AddRepetitiveExpense()
        {

            ViewBag.Categories = GetCategories();
            ViewBag.PeriodTypeNames = GetPeriodTypes();

            return PartialView();

        }

        [HttpPost]
        public ActionResult AddRepetitiveExpense(decimal? RepetitiveExpenseAmount, DateTime? RepetitiveExpenseDate, string RepetitiveExpenseDescription, ForRepetitive RepetitiveExpenseCaretgoryID, int? RepetitiveExpensePeriod, ForRepetitive RepetitiveExpensePeriodTypeID)
        {
            if (RepetitiveExpenseAmount == null || RepetitiveExpenseDate == null || RepetitiveExpensePeriod == null)
            {
                TempData["AddRepetitiveIncomeError"] = "<script>alert('Miktar, Tarih veya Ne kadar sürede bir? kısmı boş bırakılamaz!');</script>";
            }
            else
            {

                ViewBag.Categories = GetCategories();
                ViewBag.PeriodTypeNames = GetPeriodTypes();

                int CatID = int.Parse(RepetitiveExpenseCaretgoryID.TransactionCategory.Category);
                int PerID = int.Parse(RepetitiveExpensePeriodTypeID.PeriodType.PeriodTypeName);

                var model = DbContext.RepetitiveTransactions;
                var transactionModel = DbContext.Transactions;
                RepetitiveTransaction item = new RepetitiveTransaction();
                Transaction transactionItem = new Transaction();

                DateTime DateTemp = RepetitiveExpenseDate ?? DateTime.Now;
                int PeriodTemp = RepetitiveExpensePeriod ?? 0;
                item.RepetitiveTransactionID = 1;
                item.TypeID = 2;
                string IdHldr = GetUserId();

                if (PerID == 1)
                {
                    item.RepetitiveTransactionNextDate = DateTemp.AddDays(PeriodTemp);
                }
                if (PerID == 2)
                {
                    item.RepetitiveTransactionNextDate = DateTemp.AddDays(PeriodTemp * 7);
                }
                if (PerID == 3)
                {
                    item.RepetitiveTransactionNextDate = DateTemp.AddMonths(PeriodTemp);
                }
                if (PerID == 4)
                {
                    item.RepetitiveTransactionNextDate = DateTemp.AddYears(PeriodTemp);
                }



                if (ModelState.IsValid)
                {

                    item.Id = IdHldr;
                    item.RepetitiveTransactionAmount = RepetitiveExpenseAmount ?? 0;
                    item.CategoryID = CatID;
                    item.RepetitiveTransactionDate = RepetitiveExpenseDate ?? DateTime.Now;
                    item.RepetitiveTransactionDescription = RepetitiveExpenseDescription;
                    item.PeriodAmount = RepetitiveExpensePeriod ?? 0;
                    item.PeriodTypeID = PerID;

                    model.Add(item);

                    if (RepetitiveExpenseDate == DateTime.Now.Date)
                    {
                        transactionItem.TransactionID = 1;
                        transactionItem.Id = IdHldr;
                        transactionItem.TransactionAmount = RepetitiveExpenseAmount ?? 0;
                        transactionItem.CategoryID = CatID;
                        transactionItem.TransactionDate = RepetitiveExpenseDate ?? DateTime.Now;
                        transactionItem.TransactionDescription = RepetitiveExpenseDescription;
                        transactionItem.TypeID = 2;
                        transactionItem.AutomaticOrManuelID = 1;

                        transactionModel.Add(transactionItem);
                    }

                    DbContext.SaveChanges();
                }
                else
                {
                    ViewData["EditError"] = "hata:";
                }
            }
            return RedirectToAction("Index");
        }


        public Notifications InformNotification(int Year, int MonthCount)
        {
            Notifications notifications = new Notifications();

            string IdHldr = GetUserId();
            string MonthlyViewId = string.Concat(Year, MonthCount) + IdHldr;
            string PreviousMonthlyViewId = GetPreviousMonthlyViewId(Year, MonthCount);
            decimal DifferenceMonthsExpense;
            decimal MaxExpense;


            if (DbContext.V_MonthlyView.Any(x => x.ViewID == MonthlyViewId) && DbContext.V_MonthlyView.Any(x => x.ViewID == PreviousMonthlyViewId))
            {
                DifferenceMonthsExpense = (DbContext.V_MonthlyView.Single(x => x.ViewID == MonthlyViewId).Expense) - (DbContext.V_MonthlyView.Single(x => x.ViewID == PreviousMonthlyViewId).Expense);
            }
            else
            {
                if (DbContext.V_MonthlyView.Any(x => x.ViewID == MonthlyViewId))
                {
                    DifferenceMonthsExpense = (DbContext.V_MonthlyView.Single(x => x.ViewID == MonthlyViewId).Expense);
                }
                else
                {
                    if (DbContext.V_MonthlyView.Any(x => x.ViewID == PreviousMonthlyViewId))
                    {
                        DifferenceMonthsExpense = -(DbContext.V_MonthlyView.Single(x => x.ViewID == PreviousMonthlyViewId).Expense);
                    }
                    else
                    {
                        DifferenceMonthsExpense = 0;
                    }
                }


            }

            if (DbContext.Transactions.Any(x => x.Id == IdHldr && x.TypeID == 2 && x.TransactionDate.Year == Year && x.TransactionDate.Month == MonthCount))
            {
                MaxExpense = DbContext.Transactions.Where(x => x.Id == IdHldr && x.TypeID == 2 && x.TransactionDate.Year == Year && x.TransactionDate.Month == MonthCount).Max(x => x.TransactionAmount);
            }
            else
            {
                MaxExpense = 0;
            }



            if (DifferenceMonthsExpense < 0)
            {
                DifferenceMonthsExpense = -DifferenceMonthsExpense;
                notifications.DifferenceNotification = "Bir önceki ay, bu aya göre " + DifferenceMonthsExpense + "₺ kadar fazla harcadın.";
            }
            else
            {
                notifications.DifferenceNotification = "Bu ay, bir önceki aya göre " + DifferenceMonthsExpense + "₺ kadar fazla harcadın.";
            }

            if (DbContext.V_MonthlyView.Any(x => x.ViewID == MonthlyViewId))
            {
                if ((DbContext.V_MonthlyView.Single(x => x.ViewID == MonthlyViewId).Balance) < 0)
                {
                    notifications.DifferenceBalanceNotification = "Harcamaların kazançlarından daha fazla!";
                }
                else
                {
                    notifications.DifferenceBalanceNotification = "Kanzançların harcamalarından daha fazla.";
                }
            }
            else
            {
                notifications.DifferenceBalanceNotification = "";
            }

            if (DbContext.V_MonthlyView.Any(x => x.ViewID == PreviousMonthlyViewId))
            {
                if ((DbContext.V_MonthlyView.Single(x => x.ViewID == PreviousMonthlyViewId).Balance) < 0)
                {
                    notifications.DifferencePreviousBalanceNotification = "Bir önceki ay harcamaların, kazançlarından daha fazlaydı. Bu ay dikkat et!";
                }
                else
                {
                    notifications.DifferencePreviousBalanceNotification = "";
                }

            }
            else
            {
                notifications.DifferencePreviousBalanceNotification = "";
            }
            notifications.MaxExpenseNotification = "Bu ay en çok " + MaxExpense + "₺ kadar harcama yaptın.";

            if (FindMaxCategory(MonthCount, Year) == "")
            {
                notifications.MaxCategory = "Bu ay henüz harcama yapmadınız.";
            }
            else
            {
                notifications.MaxCategory = "Bu ay en çok harcaman '" + FindMaxCategory(MonthCount, Year) + "' kategorisinden.";
            }



            return notifications;


        }


        public string GetPreviousMonthlyViewId(int Year, int Month)
        {
            string IdHldr = GetUserId();

            Month -= 1;
            if (Month == 0)
            {
                Month = 12;
                Year -= 1;
            }

            string ViewId = string.Concat(Year, Month) + IdHldr;

            return ViewId;
        }

        public string GetUserId()
        {
                string IdHldr = Session["idSession"].ToString();
                return IdHldr;
           
        }

        public string FindMaxCategory(int Month, int Year)
        {
            string IdHldr = GetUserId();
            decimal MaxValue = 1;
            int MaxCategory = 0;
            int CategoryID = 1;


            while (CategoryID < 22)
            {
                string ViewID = string.Concat(Month, Year, IdHldr, CategoryID);

                if (DbContext.V_ExpenseCategorySums.Any(x => x.ViewID == ViewID))
                {
                    var model = DbContext.V_ExpenseCategorySums.Single(x => x.ViewID == ViewID);

                    if (model.Sum > MaxValue)
                    {
                        MaxValue = model.Sum;
                        MaxCategory = model.CategoryID;
                    }
                }
                CategoryID++;
            }

            if (MaxCategory == 0)
            {
                return "";
            }
            else
            {
                return DbContext.TransactionCategories.Single(x => x.CategoryID == MaxCategory).Category;
            }
        }


        public ActionResult IncomeExpenseChartPartial(HomePageModel homePageModel)
        {
            {
                CheckModelEmpty(homePageModel);
                
                string IdHldr = GetUserId();
                var chartModel = DbContext.V_MonthlyView.Where(x => x.Id == IdHldr && x.Year == homePageModel.Year && x.Month <= homePageModel.MonthCount).OrderBy(x=>x.Month);
                chartModel.Reverse();
                

                return PartialView("~/Views/Home/_IncomeExpenseChartPartial.cshtml", chartModel.ToArray());
            }
        }

        public HomePageModel CheckModelEmpty (HomePageModel homePageModel)
        {
            if (homePageModel.MonthCount == 0)
            {
                homePageModel.MonthCount = DateTime.Now.Month;
            }
            if (homePageModel.Year == 0)
            {
                homePageModel.Year = DateTime.Now.Year;
            }

            return homePageModel;
        }



    }
}