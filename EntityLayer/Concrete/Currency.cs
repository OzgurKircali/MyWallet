using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Currency
    {
        [Key]
        public int CurrencyID { get; set; }
        public string CurrencName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal CurrencyValue { get; set; }
        public ICollection<Investment> Investments { get; set; }
    }
}
