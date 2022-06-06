using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete.Identity
{
    public class AspNetUser:IdentityUser
    {
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<RepetitiveTransaction> RepetitiveTransactions { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Investment> Investments { get; set; }

    }
}