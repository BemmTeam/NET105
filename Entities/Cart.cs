
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET105.Entities 
{

    public enum StatusType 
    {   
        [Display(Name = "Hoàn Thành")]
        Success = 1,

        [Display(Name = "Đơn hàng bị hủy")]
        Cancel = 2, 


        [Display(Name = "Đang chuẩn bị món")]
        Pending =3 ,

        [Display(Name = "Đang giao hàng")]
        Shipping = 4,
    }
    public class Cart 
    {   
        [Key]
        public Guid CartId {get;set;}

        [Display(Name = "Ngày đặt hàng")]
        public DateTime CreatedDate {get;set;}

        [Display(Name = "Thời gian hoàn thành")]
        public DateTime Completed {get;set;}



        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Địa chỉ giao hàng")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(200 , ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự" , MinimumLength = 4)]
        public string Address {get;set;}

        [Display(Name = "Trạng thái")]
        public StatusType Status {get;set;}

        [Column(TypeName = "text")]
        public string CartDetail_Json {get;set;}

        [NotMapped]
        public CartDetail CartDetail {get;set;}

        // Khóa ngoại
        public string UserId {get;set;}

        [ForeignKey("UserId")]
        [Display(Name = "Khách hàng")]
        public User User {get;set;}

        public Guid PaymentId {get;set;}

        [ForeignKey("PaymentId")]
        [Display(Name = "Phương thức thanh toán")]
        public Payment Payment {get;set;}
    }
}