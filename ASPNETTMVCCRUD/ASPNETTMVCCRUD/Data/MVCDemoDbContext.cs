using ASPNETTMVCCRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNETTMVCCRUD.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
