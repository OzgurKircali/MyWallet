using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PeriodType
    {
        [Key]
        public int PeriodTypeID { get; set; }

        public string PeriodTypeName { get; set; }

        public ICollection<RepetitiveTransaction> RepetitiveTransaction { get; set; }
    }
}
