using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvControl.API.Models;

namespace TvControl.API.DataLayer
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        // Here we dont use async because we don`t query the context
        // This is also saved in the memory until we actually save changes
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<string> AddMovie(Movie movie) {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return "movie added";
        }

        public Contributor AddContributor(Contributor contributor)
        {
             _context.Contributors.AddAsync(contributor);
             _context.SaveChangesAsync();

            return contributor;
        }

        public void Delete<T>(T entity) where T : class {
            _context.Remove(entity);
        }

        public async Task<Contributor> GetContributor(string contributorName) {
            var contributor = await _context.Contributors.Where(x => x.Name == contributorName).Select(x => x).FirstOrDefaultAsync();

            return await Task.FromResult<Contributor>(contributor);
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync<Movie>();
        }

        public async Task<Movie> GetMovie(int id) {
            return await _context.Movies.Where(m => m.ID == id).Select(m => m).FirstOrDefaultAsync();
        }
    }
}
