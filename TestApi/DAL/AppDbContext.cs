using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasData(
                new Post {Id=1,Title="Ferid",Content="FrontEnd Developer" },
                new Post { Id = 2, Title = "Tural", Content = "Python Developer" },
                new Post { Id = 3, Title = "Sebuhi", Content = "BackEnd Developer" }
                );
        }
    }
}
