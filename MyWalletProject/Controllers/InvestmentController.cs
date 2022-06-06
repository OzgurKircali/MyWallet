using DataAccessLayer.Concrete;
using DevExpress.Web.Mvc;
using EntityLayer.Concrete;
using MyWalletProject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using System.Xml;

namespace MyWalletProject.Controllers
{
    [Authorize]
    public class InvestmentController : Controller
    {
        Context DbContext = new Context();
        public ActionResult InvestmentView()
        {
            if (Session["idsession"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                CurrencyModel model = new CurrencyModel();
                model = GetCurrencyXml();
                string IdHldr = Session["idSession"].ToString();
                decimal DolarAsTL, EuroAsTL, PoundAsTL;


                if (DbContext.Investments.Where(x => x.Id == IdHldr && x.CurrencyID == 1).Count() == 0)
                {
                    DolarAsTL = 0;
                }
                else
                {
                    DolarAsTL = DbContext.Investments.Where(x => x.Id == IdHldr && x.CurrencyID == 1).Sum(x => x.InvestmentAmount) * model.DolarCurrency;
                }


                if (DbContext.Investments.Where(x => x.Id == IdHldr && x.CurrencyID == 2).Count() == 0)
                {
                    EuroAsTL = 0;
                }
                else
                {
                    EuroAsTL = DbContext.Investments.Where(x => x.Id == IdHldr && x.CurrencyID == 2).Sum(x => x.InvestmentAmount) * model.EuroCurrency;
                }


                if (DbContext.Investments.Where(x => x.Id == IdHldr && x.CurrencyID == 3).Count() == 0)
                {
                    PoundAsTL = 0;
                }
                else
                {
                    PoundAsTL = DbContext.Investments.Where(x => x.Id == IdHldr && x.CurrencyID == 3).Sum(x => x.InvestmentAmount) * model.PoundCurrency;
                }


                decimal TotalAsTL = DolarAsTL + EuroAsTL + PoundAsTL;
                ViewBag.TotalAsTL = "₺" + string.Format("{0:n}", TotalAsTL);

                return View(model);
            }
        }

        public List<SelectListItem> GetCurrencies()
        {
            List<SelectListItem> values = (from i in DbContext.Currencies.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CurrencName,
                                               Value = i.CurrencyID.ToString()
                                           }).ToList();

            return values;
        }

        private CurrencyModel GetCurrencyXml()
        {
            try
            {


                XmlDocument doc1 = new XmlDocument();
                doc1.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                XmlElement root = doc1.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Currency");
                CurrencyModel model = new CurrencyModel();

                foreach (XmlNode node in nodes)
                {
                    if (node["CurrencyName"].InnerText == "US DOLLAR")
                    {
                        model.DolarCurrency = Math.Round(decimal.Parse(node["ForexBuying"].InnerText, CultureInfo.InvariantCulture), 2, MidpointRounding.AwayFromZero);

                    }
                    if (node["CurrencyName"].InnerText == "EURO")
                    {
                        model.EuroCurrency = Math.Round(decimal.Parse(node["ForexBuying"].InnerText, CultureInfo.InvariantCulture), 2, MidpointRounding.AwayFromZero);

                    }
                    if (node["CurrencyName"].InnerText == "POUND STERLING")
                    {
                        model.PoundCurrency = Math.Round(decimal.Parse(node["ForexBuying"].InnerText, CultureInfo.InvariantCulture), 2, MidpointRounding.AwayFromZero);

                    }

                }
                return model;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            
        }

            [HttpGet]
        public ActionResult AddInvestment()
        {
            ViewBag.Currencies = GetCurrencies();
            return PartialView();

        }


        [HttpPost]
        public ActionResult AddInvestment(decimal? InvestmentAmount, Currency m)
        {
            if (InvestmentAmount == null)
            {
                TempData["AddInvestmentError"] = "<script>alert('Miktar kısmı boş bırakılamaz!');</script>";
            }
            else
            {

                ViewBag.Currencies = GetCurrencies();

                int CurID = int.Parse(m.CurrencName);

                var model = DbContext.Investments;
                Investment item = new Investment();


                item.InvestmentID = 1;
                string IdHldr = Session["idSession"].ToString();



                if (ModelState.IsValid)
                {

                    item.Id = IdHldr;
                    item.InvestmentAmount = InvestmentAmount ?? 0;
                    item.CurrencyID = CurID;


                    model.Add(item);

                    DbContext.SaveChanges();
                }
                else
                {
                    ViewData["EditError"] = "hata:";
                }
            }
            return RedirectToAction("InvestmentView");
        }




        [ValidateInput(false)]
        public ActionResult _InvestmentViewPartial()
        {

            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.Investments.Where(x => x.Id == IdHldr);

            return PartialView("~/Views/Investment/_InvestmentViewPartial.cshtml", model.ToList());
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult InvestmentViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] EntityLayer.Concrete.Investment item)
        {
            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.Investments.Where(x => x.Id == IdHldr);
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.InvestmentID == item.InvestmentID);
                    if (modelItem != null)
                    {
                        modelItem.InvestmentAmount = item.InvestmentAmount;
                        modelItem.CurrencyID = item.CurrencyID;
                                       
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
            return PartialView("~/Views/Investment/_InvestmentViewPartial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult InvestmentViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int InvestmentID)
        {
            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.Investments;
            
            if (InvestmentID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.InvestmentID == InvestmentID);
                    if (item != null)
                        model.Remove(item);
                    DbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
                
            }
            var modelList = DbContext.Investments.Where(x => x.Id == IdHldr);
            return PartialView("~/Views/Investment/_InvestmentViewPartial.cshtml", modelList.ToList());
        }
    }
}