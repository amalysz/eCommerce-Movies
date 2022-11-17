using eMovies.Data.Base;
using eMovies.Data.ViewModels;
using eMovies.Models;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eMovies.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context; 
        public MoviesService(AppDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllOrderedByNameAsync() => await _context.Movies.OrderBy(n => n.Name).ToListAsync();

        public async Task<IEnumerable<Movie>> GetAllOrderedByNameAsync(params Expression<Func<Movie, object>>[] includeProperties)
        {
            IQueryable<Movie> query = _context.Set<Movie>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.OrderBy(n => n.Name).ToListAsync();

        }

        public async Task<IEnumerable<Movie>> GetAllOrderedByQuantityAsync() => await _context.Movies.OrderBy(n => n.Quantity).ToListAsync();

        public async Task<IEnumerable<Movie>> GetAllOrderedByQuantityAsync(params Expression<Func<Movie, object>>[] includeProperties)
        {
            IQueryable<Movie> query = _context.Set<Movie>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.OrderBy(n => n.Quantity).ToListAsync();

        }
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _context.Movies
                .Include(c => c.Media)
                .Include(p => p.Director)
                .Include(am => am.Movies_Actors).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return await movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Medias = await _context.Medias.OrderBy(n => n.Name).ToListAsync(),
                Directors = await _context.Directors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                MediaId = data.MediaId,
                Year = data.Year,
                Quantity = data.Quantity,
                MovieCategory = data.MovieCategory,
                DirectorId = data.DirectorId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newMovieActor = new Movie_Actor()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Movies_Actors.AddAsync(newMovieActor);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.MediaId = data.MediaId;
                dbMovie.Year = data.Year;
                dbMovie.Quantity = data.Quantity;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.DirectorId = data.DirectorId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors from Movies_Actors table
            var existingActorsDb = _context.Movies_Actors.Where(n => n.MovieId == data.Id).ToList();
            _context.Movies_Actors.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Movie_Actor()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Movies_Actors.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }     
}
