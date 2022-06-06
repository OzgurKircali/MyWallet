using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWalletProject.Models
{
    public class Notifications
    {
        public string DifferenceNotification { get; set; }
        public string DifferenceBalanceNotification { get; set; }
        public string DifferencePreviousBalanceNotification { get; set; }
        public string MaxExpenseNotification { get; set; }
        public string MaxCategory { get; set; }
    }
}