using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWalletProject.Models
{
    public class HomePageModel
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n}")]
        public string Balance { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n}")]
        public string MonthlyIncome { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n}")]
        public string MonthlyBalance { get; set; }
        [DisplayFormat( DataFormatString = "{0:n}")]
        public string MonthlyExpense { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public int MonthCount { get; set; }
        public int Year { get; set; }

    }
}