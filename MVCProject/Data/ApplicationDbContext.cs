using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
