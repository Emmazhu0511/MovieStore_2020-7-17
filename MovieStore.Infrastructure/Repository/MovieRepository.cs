using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Entities;
using MovieStore.Core.RepositoryInterfaces;
using MovieStore.Infrastructure.Data;

namespace MovieStore.Infrastructure.Repository
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository  // first comes with class inheritance then with interface
    {
        public MovieRepository(MovieStoreDbContext dbContext) : base(dbContext)
        {


        }

        public async Task<int> GetMoviesCount(string title)
        {
            var count = await _dbContext.Movies.CountAsync(m=> m.Title.Contains(title));
            
            return count;
        }




        //select top 25 from Movies order by Revenu desc;
        public async Task<IEnumerable<Movie>> GetTop25HighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(25).ToListAsync();
            
            return movies;
        }

        /*public async Task<IEnumerable<Movie>> GetTop25RateMovies() {

            var movies = await(from r in _dbContext.Reviews
                          join m in _dbContext.Movies
                          on r.MovieId equals m.Id
                          group r by m.Id into temp
                          orderby (temp.Average(x => x.Rating)) descending
                          select temp).Take(25).ToListAsync();

            return movies;

        }*/
    }
}
