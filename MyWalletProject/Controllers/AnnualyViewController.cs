using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletProject.Controllers
{
    [Authorize]
    public class AnnualyViewController : Controller
    {
        Context DbContext = new Context();

        public ActionResult AnnualyView()
        {
            if (Session["idsession"] == null)
            {
                return RedirectToAction("Login","Account");  
            }
            else
            {
                return View();
            }
        }

        [ValidateInput(false)]
        public ActionResult AnnualyViewPartial()
        {
            
                string IdHldr = Session["idSession"].ToString();
                var model = DbContext.V_AnnualyView.Where(x => x.Id == IdHldr);

                return PartialView("~/Views/AnnualyView/_AnnualyViewPartial.cshtml", model.ToList());
            
        }

    }
}