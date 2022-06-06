using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class V_IncomeCategorySums
    {
        public string ViewID { get; set; }
        public string Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int CategoryID { get; set; }
        public decimal Sum { get; set; }
    }
}
