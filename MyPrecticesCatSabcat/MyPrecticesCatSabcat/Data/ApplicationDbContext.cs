using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPrecticesCatSabcat.Models;

namespace MyPrecticesCatSabcat.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyPrecticesCatSabcat.Models.Category> Category { get; set; }
        public DbSet<MyPrecticesCatSabcat.Models.SubCategory> SubCategory { get; set; }
        public DbSet<MyPrecticesCatSabcat.Models.test> test { get; set; }
    }
}