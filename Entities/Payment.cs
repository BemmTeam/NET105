using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET105.Entities 
{
    public class Payment 
    {
        [Key]
        public Guid PaymentId {get;set;}

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên thanh toán")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(100 , ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự" , MinimumLength = 4)]
        public string Name {get;set;}
 
    }
}