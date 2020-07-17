using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieStore.Core.Entities;

namespace MovieStore.Core.RepositoryInterfaces
{
    public interface IMovieRepository:IAsyncRepository<Movie>
    {

        Task<IEnumerable<Movie>> GetTop25HighestRevenueMovies();

        //Task<IEnumerable<Movie>> GetTop25RateMovies(); not yet complete

        Task<int> GetMoviesCount(string title); 

        // IAsyncRepository has 8 methods
        // public class MovieRepo: IMovieRepository{

        // 1 + 8 = 9 methods need to be implemented
        //}

        // public class MovieRepo: EfRepository, IMovieRepository{

        // then 1 methods need to be implemented as it inherite the EfRepository which has implementation for the 8 methods
        //}
    }
}
