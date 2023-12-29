
using Abyweb.Model;
using Microsoft.EntityFrameworkCore;

namespace Abyweb.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category_Db { get; set; }
    }
}
