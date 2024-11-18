using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Category { 


        [Key]
        public int Category_id { get; set; }
        public String name { get; set; }
    }
}
