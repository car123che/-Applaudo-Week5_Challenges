using EFMovieRentalDomain;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMovieRental
{
    internal class Program
    {

        private static MovieRentalContext context = new MovieRentalContext();

        static async Task Main(string[] args)
        {
            await QueryFilter();

            Console.ReadLine();
        }

        private static async Task QueryFilter()
        {
            var movies = await context.Movies.Where(e => e.Title.Contains("n")).ToListAsync();

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Title);
            }

        }
    }
}