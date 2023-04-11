using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EFMovieRentalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnivestityRentalData
{
    public class MovieRentalContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-KAP3NP1H; Initial Catalog=MovieRental; persist security info=True; Integrated Security=SSPI;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();  //to use sql server, connection string

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ADD VALIDATION TO OUR TABLES
            modelBuilder.ApplyConfiguration(new MovieConfiguration() );
            modelBuilder.ApplyConfiguration(new TagConfiguration() );
            modelBuilder.ApplyConfiguration(new MovieTagConfiguration() );

        }


        public DbSet<Movie> Movies { get; set; }  //set or rules of reading a table
        public DbSet<Tag> Tags { get; set; }  //set or rules of reading a table
        public DbSet<MovieTag> MovieTags { get; set; }  //set or rules of reading a table
    }
}
