﻿using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using Movie.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain
{
    public interface IMovieService
    {
       
        Task<List<EFMovieRentalDomain.Movie>> Get();
        Task<EFMovieRentalDomain.Movie> Get(int Id);
        Task<EFMovieRentalDomain.Movie> Post(EFMovieRentalDomain.Movie movie);
        Task<string> Delete(int Id);
        Task<string> Update(int Id, EFMovieRentalDomain.Movie newMovie);
    }

    public class MovieService : IMovieService
    {
        private static MovieRentalContext context = new MovieRentalContext();
        public async Task<string> Delete(int Id)
        {
            var movie = await context.Movies.FindAsync(Id);

            if (movie is null)
            {
                throw new MovieNotFoundException($"Movie {Id} - Not Found");
            }

            context.Movies.Remove(movie);
            await context.SaveChangesAsync();

            return $"Movie: {movie.Title} - deleted";
        }

        public async Task<List<EFMovieRentalDomain.Movie>> Get()
        {
            var movies = await context.Movies.ToListAsync();
            return movies;
        }

        public async Task<EFMovieRentalDomain.Movie> Get(int Id)
        {
            var movie = await context.Movies.FindAsync(Id);

            if( movie is null)
            {
                throw new MovieNotFoundException($"Movie {Id} - Not Found");
            }

            return movie;
        }

        public async Task<EFMovieRentalDomain.Movie> Post(EFMovieRentalDomain.Movie movie)
        {
            await context.AddAsync(movie);

            await context.SaveChangesAsync();

            return movie;
        }

        public async Task<string> Update(int Id, EFMovieRentalDomain.Movie newMovie)
        {
            var movie = await context.Movies.FindAsync(Id);

            if (movie is null)
            {
                throw new MovieNotFoundException($"Movie {Id} - Not Found");
            }

            movie.Title = newMovie.Title;
            movie.Description = newMovie.Description;
            movie.PosterStock = newMovie.PosterStock;
            movie.TrailerLink = newMovie.TrailerLink;
            movie.SalePrice = newMovie.SalePrice;
            movie.Likes = newMovie.Likes;
            movie.Availability = newMovie.Availability;
            await context.SaveChangesAsync();

            return $"Movie: {movie.Title} -  updated";
        }

    }
}
