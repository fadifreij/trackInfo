using Microsoft.EntityFrameworkCore;
using SearchEngine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<SearchInfo> SearchInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Engine>().HasData(
                new Engine
                {
                    Id = 1,
                    EngineName = "Google engine",
                    EngineUrl = "https://www.google.co.uk/",
                    EngineSearchParameter = "search?num={num}&q={keywords}",
                    IsActive = true
                }
            ); ;

           
        }
       
    }
}
