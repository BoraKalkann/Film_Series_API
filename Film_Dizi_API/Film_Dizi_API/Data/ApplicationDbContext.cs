using Film_Dizi_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Film_Dizi_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Series> Series { get; set; }

      
        
    }
}
