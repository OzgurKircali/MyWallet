using EntityLayer.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        [Required(ErrorMessage ="'Miktar' kısmı boş bırakılamaz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal TransactionAmount { get; set; }

        [Required(ErrorMessage ="'Tarih' kısmı boş bırakılamaz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime TransactionDate { get; set; }

        
        [StringLength(30,ErrorMessage ="Açıklama 30 karakterden fazla olamaz!")]
        public string TransactionDescription { get; set; }


        public string Id { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

        public int TypeID { get; set; }
        public virtual TransactionType TransactionType { get; set; } 

        public int CategoryID { get; set; }
        public virtual TransactionCategory TransactionCategory { get; set; }

        public int AutomaticOrManuelID { get; set; }
        public virtual AutomaticOrManuel AutomaticOrManuel { get; set; }




    }
}
