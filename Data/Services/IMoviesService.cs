using eMovies.Data.Base;
using eMovies.Data.ViewModels;
using eMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eMovies.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
        Task<IEnumerable<Movie>> GetAllOrderedByNameAsync();
        Task<IEnumerable<Movie>> GetAllOrderedByNameAsync(params Expression<Func<Movie, object>>[] includeProperties);
        Task<IEnumerable<Movie>> GetAllOrderedByQuantityAsync();
        Task<IEnumerable<Movie>> GetAllOrderedByQuantityAsync(params Expression<Func<Movie, object>>[] includeProperties);
    }
}
