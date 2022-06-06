using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletProject.Controllers
{
    [Authorize]
    public class DailyViewController : Controller
    {
        Context DbContext = new Context();
        public ActionResult DailyView()
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
        public ActionResult DailyViewPartial()
        {

            string IdHldr = Session["idSession"].ToString();
            var model = DbContext.V_DailyView.Where(x => x.Id == IdHldr);

            return PartialView("~/Views/DailyView/_DailyViewPartial.cshtml", model.ToList());
        }

    }
}