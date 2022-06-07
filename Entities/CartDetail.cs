
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET105.Entities
{
    public class CartDetail 
    {

        [Key]
        public string CartDetailId {get;set;}

        [Display(Name = "Số lượng sản phẩm")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        public int Quantity {get;set;}

        [Display(Name = "Giá sản phẩm")]
        public float Price {get;set;}

        public Guid CartId {get;set;}

        [ForeignKey("CartId")]
        [Display(Name = "Đơn hàng")]
        [Required(ErrorMessage = "{0} là phải chọn")]
        public Cart Cart {get;set;}
        public Guid ProductId {get;set;}

        [ForeignKey("ProductId")]
        [Display(Name = "Sản phẩm")]
        [Required(ErrorMessage = "{0} là phải chọn")]
        public Product Product {get;set;}

    }
}