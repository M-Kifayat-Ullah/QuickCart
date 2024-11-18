using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Admin
    {
        [Key]
        public int Admin_id { get; set; }
        public string Admin_name  { get; set; }
        public string Admin_Email { get; set; }
        public string  Admin_password{ get; set; }
        public string Admin_image { get; set; }

    }
}
