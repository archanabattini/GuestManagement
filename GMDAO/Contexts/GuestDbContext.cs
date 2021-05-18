using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMDAO.Models
{
    public class GuestDbContext: DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options) : base(options)
        {

        }
        // Entities        
        public DbSet<GuestDTO> Guests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HARISHDHULIC7DB;Initial Catalog=Hotels;Persist Security Info=True;User ID=archana;Password=sqlserver2021;MultipleActiveResultSets=True;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GuestDTO>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
