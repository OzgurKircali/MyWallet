using EntityLayer.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RepetitiveTransaction
    {
        [Key]
        public int RepetitiveTransactionID { get; set; }

        [Required(ErrorMessage ="'Miktar' kısmı boş bırakılamaz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal RepetitiveTransactionAmount { get; set; }

        [Required(ErrorMessage ="'Tarih' kısmı boş bırakılamaz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime RepetitiveTransactionDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime RepetitiveTransactionNextDate { get; set; }

        [StringLength(30,ErrorMessage ="'Açıklama' 30 karakterden fazla olamaz!")]
        public string RepetitiveTransactionDescription { get; set; }

        [Required(ErrorMessage = "'Ne kadar sürede bir?' kısmı boş bırakılamaz!")]
        public int PeriodAmount { get; set; }

        public int PeriodTypeID { get; set; } //DAY;WEEK;MONTH;YEAR
        public virtual PeriodType PeriodType { get; set; }


        public string Id { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

        public int TypeID { get; set; }
        public virtual TransactionType TransactionType { get; set; }

        public int CategoryID { get; set; }
        public virtual TransactionCategory TransactionCategory { get; set; }

    }
}
