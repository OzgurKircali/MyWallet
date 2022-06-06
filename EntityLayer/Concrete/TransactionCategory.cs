using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TransactionCategory
    {
        [Key]
        public int CategoryID { get; set; }
        public String Category { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<RepetitiveTransaction> RepetitiveTransactions { get; set; }
    }
}
