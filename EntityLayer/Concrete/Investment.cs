using EntityLayer.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Investment
    {
        [Key]
        public int InvestmentID { get; set; }

        [Required(ErrorMessage = "'Miktar' kısmı boş bırakılamaz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        public decimal InvestmentAmount { get; set; }
        [Required]
        public int CurrencyID { get; set; }
        public virtual Currency Currency { get; set; }


        public string Id { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

    }
}
