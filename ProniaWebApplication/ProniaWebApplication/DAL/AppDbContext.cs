using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.DAL
{
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }

                public DbSet<Slide> Sliders { get; set; }
                public DbSet<Product> Products { get; set; }

                public DbSet<Color> Colors { get; set;  }
                public DbSet<Size> Sizes { get; set; }
              
        }
    }


