using DataAccessLayer.Concrete;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletProject.Controllers
{
    [Authorize]
    public class RepetitiveTransactionController : Controller
    {
        Context DbContext = new Context();
        public ActionResult RepetitiveTransactionView()
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


        [ValidateInput(false)]
        public ActionResult _RepetitiveTransactionViewPartial()
        {

            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.RepetitiveTransactions.Where(x => x.Id == IdHldr);

            return PartialView("~/Views/RepetitiveTransaction/_RepetitiveTransactionViewPartial.cshtml", model.ToList());
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult RepetitiveTransactionViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] EntityLayer.Concrete.RepetitiveTransaction item)
        {
            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.RepetitiveTransactions.Where(x => x.Id == IdHldr);
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.RepetitiveTransactionID == item.RepetitiveTransactionID);
                    if (modelItem != null)
                    {
                        modelItem.CategoryID = item.CategoryID;
                        modelItem.TypeID = item.TypeID;
                        modelItem.RepetitiveTransactionAmount = item.RepetitiveTransactionAmount;
                        modelItem.RepetitiveTransactionDate = item.RepetitiveTransactionDate;
                        modelItem.RepetitiveTransactionDescription = item.RepetitiveTransactionDescription;
                        modelItem.PeriodAmount = item.PeriodAmount;
                        modelItem.PeriodTypeID = item.PeriodTypeID;

                        if (modelItem.PeriodTypeID == 1)
                        {
                            modelItem.RepetitiveTransactionNextDate = modelItem.RepetitiveTransactionDate.AddDays(modelItem.PeriodAmount);
                        }
                        if (modelItem.PeriodTypeID == 2)
                        {
                            modelItem.RepetitiveTransactionNextDate = modelItem.RepetitiveTransactionDate.AddDays(modelItem.PeriodAmount * 7);
                        }
                        if (modelItem.PeriodTypeID == 3)
                        {
                            modelItem.RepetitiveTransactionNextDate = modelItem.RepetitiveTransactionDate.AddMonths(modelItem.PeriodAmount);
                        }
                        if (modelItem.PeriodTypeID == 4)
                        {
                            modelItem.RepetitiveTransactionNextDate = modelItem.RepetitiveTransactionDate.AddYears(modelItem.PeriodAmount);
                        }

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
            return PartialView("~/Views/RepetitiveTransaction/_RepetitiveTransactionViewPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RepetitiveTransactionViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int RepetitiveTransactionID)
        {
            string IdHldr = Session["idSession"].ToString();

            var model = DbContext.RepetitiveTransactions;
            if (RepetitiveTransactionID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.RepetitiveTransactionID == RepetitiveTransactionID);
                    if (item != null)
                        model.Remove(item);
                    DbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelList = DbContext.RepetitiveTransactions.Where(x => x.Id == IdHldr);
            return PartialView("~/Views/RepetitiveTransaction/_RepetitiveTransactionViewPartial.cshtml", modelList.ToList());
        }
  
    }
}