using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvControl.API.Models;

namespace TvControl.API.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<ContributorType> ContributorTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contributor>().HasMany(m => m.Movies);
            builder.Entity<Movie>().HasMany(c => c.Contributors);

            builder.Entity<Genre>().HasMany(m => m.Movies);
           
        }
    }
}
