using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{
    public class MyContex: DbContext
    {
        public MyContex(DbContextOptions<MyContex> options): base(options)
        {
            
        }
        public DbSet<Admin> tbl_admin { get; set; }
        public DbSet<Customer> tbl_Customer { get; set; }
        public DbSet<Category> tbl_catgegory{ get; set; }
        public DbSet<Product> tbl_product { get; set; }
        public DbSet<Cart> tbl_cart { get; set; }
        public DbSet<Feedback> tbl_feedback { get; set; }


    }
}
