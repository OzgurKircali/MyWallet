using DevExpress.Web.Mvc;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletProject.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        Context DbContext = new Context();
        public ActionResult TransactionView()
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
        public ActionResult TransactionViewPartial()
        {

            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.Transactions.Where(x => x.Id == IdHldr);

            return PartialView("~/Views/Transaction/_TransactionViewPartial.cshtml", model.ToList());
        }

       
        [HttpPost, ValidateInput(false)]
        public ActionResult TransactionViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] EntityLayer.Concrete.Transaction item)
        {
            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.Transactions.Where(x => x.Id == IdHldr);
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.TransactionID == item.TransactionID);
                    if (modelItem != null)
                    {
                        modelItem.CategoryID = item.CategoryID;
                        modelItem.TypeID = item.TypeID;
                        modelItem.TransactionAmount = item.TransactionAmount;
                        modelItem.TransactionDate = item.TransactionDate;
                        modelItem.TransactionDescription = item.TransactionDescription;

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
            return PartialView("~/Views/Transaction/_TransactionViewPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TransactionViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int TransactionID)
        {
            string IdHldr = Session["idSession"].ToString();

            var model = DbContext.Transactions;
            if (TransactionID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.TransactionID == TransactionID);
                    if (item != null)
                        model.Remove(item);
                    DbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelList = DbContext.Transactions.Where(x => x.Id == IdHldr);
            return PartialView("~/Views/Transaction/_TransactionViewPartial.cshtml", modelList.ToList());
        }
    }
}