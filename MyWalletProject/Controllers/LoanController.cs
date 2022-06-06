using DataAccessLayer.Concrete;
using DevExpress.Web.Mvc;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletProject.Controllers
{
    [Authorize]
    public class LoanController : Controller
    {
        Context DbContext = new Context();
        public ActionResult LoanView()
        {
            if (Session["idsession"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult AddLoan()
        {
            
            return PartialView();
        }


        [HttpPost]
        public ActionResult AddLoan( decimal? LoanAmount, decimal? DebtAmount, DateTime? LoanDate, int? PaymentDate, int? Instalment, string Description )
        {

            if (LoanAmount == null || DebtAmount == null || LoanDate == null || PaymentDate == null || Instalment == null)
            {
                TempData["AddLoanError"] = "<script>alert('Açıklama hariçinde tüm bölümler doldurulmalıdır!');</script>";
            }
            else
            {



                var model = DbContext.Loans;
                var TransactionModel = DbContext.Transactions;
                Loan item = new Loan();
                Transaction TransactionItem = new Transaction();



                item.LoanID = 1;
                string IdHldr = Session["idSession"].ToString();



                if (ModelState.IsValid)
                {

                    item.Id = IdHldr;
                    item.Instalment = Instalment ?? 0;
                    item.LoanAmount = LoanAmount ?? 0;
                    item.LoanDate = LoanDate ?? DateTime.Now;
                    item.LoanDebt = DebtAmount ?? 0;
                    item.PaymentDay = PaymentDate ?? 0;
                    item.LoanDescription = Description;


                    model.Add(item);

                    TransactionItem.Id = IdHldr;
                    TransactionItem.AutomaticOrManuelID = 1;
                    TransactionItem.CategoryID = 26;
                    TransactionItem.TransactionAmount = LoanAmount ?? 0;
                    TransactionItem.TransactionDate = LoanDate ?? DateTime.Now;
                    TransactionItem.TransactionDescription = Description;
                    TransactionItem.TransactionID = 1;
                    TransactionItem.TypeID = 1;

                    TransactionModel.Add(TransactionItem);


                    DbContext.SaveChanges();
                }
                else
                {
                    ViewData["EditError"] = "hata:";
                }

            }
            return RedirectToAction("LoanView");
        }



        [ValidateInput(false)]
        public ActionResult _LoanViewPartial()
        {

            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.Loans.Where(x => x.Id == IdHldr);

            return PartialView("~/Views/Loan/_LoanViewPartial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LoanViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] EntityLayer.Concrete.Loan item)
        {
            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.Loans.Where(x => x.Id == IdHldr);
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.LoanID == item.LoanID);
                    if (modelItem != null)
                    {
                        modelItem.Instalment = item.Instalment;
                        modelItem.LoanAmount = item.LoanAmount;
                        modelItem.LoanDate = item.LoanDate;
                        modelItem.LoanDebt = item.LoanDebt;
                        modelItem.PaymentDay = item.PaymentDay;
                        modelItem.LoanDescription = item.LoanDescription;

                        DbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Loan/_LoanViewPartial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LoanViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int LoanID)
        {
            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.Loans;
            var transactionModel = DbContext.Transactions;

            if (LoanID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.LoanID == LoanID);
                    var transactionItem = transactionModel.Single(x => x.Id == IdHldr && x.TransactionAmount == item.LoanAmount && x.TransactionDate == item.LoanDate);
                    if (item != null)
                    {
                        model.Remove(item);
                        if(transactionItem != null)
                        {
                            transactionModel.Remove(transactionItem);
                        }
                    }
                    DbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }

            }
            var modelList = DbContext.Loans.Where(x => x.Id == IdHldr);
            return PartialView("~/Views/Loan/_LoanViewPartial.cshtml", modelList.ToList());
        }
    }
}