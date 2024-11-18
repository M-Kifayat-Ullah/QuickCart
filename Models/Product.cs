using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key] 
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public string Product_image { get; set; }
        public string Product_description { get; set; }
        public int cat_id { get; set; }
       
    }
}
