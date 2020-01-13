using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvControl.API.Models;

namespace TvControl.API.DataLayer
{
    public interface IMovieRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<string> AddMovie(Movie movie);
        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovie(int id);

        Task<Contributor> GetContributor(string contributorName);
        Contributor AddContributor(Contributor contributorObj);
    }
}
