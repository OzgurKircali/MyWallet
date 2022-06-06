using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AutomaticOrManuel
    {
        public int AutomaticOrManuelID { get; set; }
        public string AutomaticOrManuelName { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
