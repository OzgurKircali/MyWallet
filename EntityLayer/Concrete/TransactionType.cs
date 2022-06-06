using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TransactionType
    {
        [Key]
        public int TypeID { get; set; }

        public string Type { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<RepetitiveTransaction> RepetitiveTransaction { get; set; }
    }
}
