using DataAccessLayer.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletProject.Controllers
{
    public class IDtoNameController : Controller
    {
        Context DbContext = new Context();

        public IEnumerable GetCategoriesData()
        {
            var query = from TransactionCategory in DbContext.TransactionCategories
                        select new
                        {
                            CategoryID = TransactionCategory.CategoryID,
                            Category = TransactionCategory.Category
                        };
            return query.ToList();
        }

        public IEnumerable GetAutomaticOrManuelData()
        {
            var query = from AutomaticOrManuel in DbContext.AutomaticOrManuels
                        select new
                        {
                            AutomaticOrManuelID = AutomaticOrManuel.AutomaticOrManuelID,
                            AutomaticOrManuelName = AutomaticOrManuel.AutomaticOrManuelName
                        };
            return query.ToList();

        }

        public IEnumerable GetTypesData()
        {
            var query = from TransactionType in DbContext.TransactionTypes
                        select new
                        {
                            TypeID=TransactionType.TypeID,
                            Type=TransactionType.Type
                        
                        };
            return query.ToList();

        }

        public IEnumerable GetPeriodTypesData()
        {
            var query = from PeriodType in DbContext.PeriodTypes
                        select new
                        {
                            PeriodTypeID = PeriodType.PeriodTypeID,
                            PeriodTypeName = PeriodType.PeriodTypeName

                        };
            return query.ToList();

        }

        public IEnumerable GetCurrencyData()
        {
            var query = from Currency in DbContext.Currencies
                        select new
                        {
                            CurrencyID = Currency.CurrencyID,
                            CurrencyName = Currency.CurrencName

                        };
            return query.ToList();

        }

    }
}