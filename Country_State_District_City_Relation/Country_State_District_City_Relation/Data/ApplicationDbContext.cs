using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Country_State_District_City_Relation.Models;

namespace Country_State_District_City_Relation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country_State_District_City_Relation.Models.Country> Country { get; set; }
        public DbSet<Country_State_District_City_Relation.Models.State> State { get; set; }
        public DbSet<Country_State_District_City_Relation.Models.City> City { get; set; }
        public DbSet<Country_State_District_City_Relation.Models.District> District { get; set; }
    }
}