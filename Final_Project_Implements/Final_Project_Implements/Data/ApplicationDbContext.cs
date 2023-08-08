using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Final_Project_Implements.Areas.Admin.Models;
using Final_Project_Implements.Models;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Implements.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Final_Project_Implements.Areas.Admin.Models.PostRegion> PostRegion { get; set; }
        public DbSet<Final_Project_Implements.Models.Category> Category { get; set; }
        public DbSet<Final_Project_Implements.Models.SubCategory> SubCategory { get; set; }
        public DbSet<Final_Project_Implements.Models.Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Category", Description = "put value",});
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { Id = 1,CategoryId=1 ,Title = "SubCateory1", Description = "put null value", },
                new SubCategory { Id = 2, CategoryId = 1, Title = "SubCateory2", Description = "put null value", });
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, ParentId = null, Title = "seed Data", Description = "put null value", });
            modelBuilder.Entity<Areas.Admin.Models.PostRegion>().HasData(
                new Areas.Admin.Models.PostRegion { Id = 1,Title = "PostRegion", Description = "postRegin", });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Final_Project_Implements.Models.Post> Post { get; set; }


    }
}