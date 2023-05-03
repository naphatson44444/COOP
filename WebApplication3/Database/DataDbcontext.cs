using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Database
{
    public class DataDbcontext : DbContext
    {
        // Constructure Method
        public DataDbcontext(DbContextOptions<DataDbcontext> options) : base(options) { }

        //Table Manufacturers
        public DbSet<manufacturers> manufacturers { get; set; }

        //Table Device
       public DbSet<devices> devices { get; set; }
    }
}