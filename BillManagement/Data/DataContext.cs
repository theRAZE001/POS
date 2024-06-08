using BillManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BillManagement.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Dcproduct> Dcproducts { get; set; }
        public DbSet<Dctable> Dctables { get; set; }
    }
}
