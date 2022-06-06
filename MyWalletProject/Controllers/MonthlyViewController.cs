using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletProject.Controllers
{
    [Authorize]
    public class MonthlyViewController : Controller
    {
        Context DbContext = new Context();

        public ActionResult MonthlyView()
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
        public ActionResult MonthlyViewPartial()
        {
            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.V_MonthlyView.Where(x => x.Id == IdHldr);

            return PartialView("~/Views/MonthlyView/_MonthlyViewPartial.cshtml", model.ToList());
        }

    }
}