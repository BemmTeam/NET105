

using System.Collections.Generic;
using NET105.Entities;

namespace NET105.Areas.MockData 
{
    public class MockCategory 
    {
        private List<Category> categories = new()
        {
            new Category() {Name = "Đồ ăn" , ImageUrl="doan.png" },
            new Category() {Name = "Đồ uống", ImageUrl ="douong.png"},
            new Category() {Name = "Đồ chay", ImageUrl ="rau.png"},
            new Category() {Name = "Tráng miệng" ,ImageUrl="banh.png"},

        };

        public List<Category> GetCategories(){

            return categories;
        }
    }
}