using EntityLayer.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }

        [Required(ErrorMessage = "'Miktar' kısmı boş bırakılamaz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "'Borç' kısmı boş bırakılamaz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal LoanDebt { get; set; }

        [Required(ErrorMessage = "'Tarih' kısmı boş bırakılamaz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime LoanDate { get; set; }

        [Required(ErrorMessage = "'Taksit' kısmı boş bırakılamaz!")]
        public int Instalment { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "'Ödeme günü' 1 ve 31 arasında olmalıdır.")]
        public int PaymentDay { get; set; }
       
        [StringLength(30,ErrorMessage = "'Açıklama' kısmı 30 karakterden fazla olamaz!")]
        public string LoanDescription { get; set; }

        public string Id { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }



    }
}
