
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity; 

namespace NET105.Entities 
{

 
    public class User : IdentityUser
    {   
        public enum Role {
            Admin = 1 , 
            Staff = 2
        }
        [Display(Name = "Họ và tên")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(100 , ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự" , MinimumLength = 4)]
        public string FullName {get;set;}

        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(200 , ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự" , MinimumLength = 4)]
        public string Address {get;set;}


        [NotMapped]
         [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        public string Password {get;set;}

        [NotMapped]
        [Display(Name = "Quyền truy cập")]
        public Role RoleType {get;set;}

    }
}