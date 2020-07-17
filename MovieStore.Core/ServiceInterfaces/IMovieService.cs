using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieStore.Core.Entities;

namespace MovieStore.Core.ServiceInterfaces
{
    public interface IMovieService

    {
        //Methods inside of this service interface is depends on the the requriements which means the controller
        //methods in the controller is depends on your business requriements

        Task<IEnumerable<Movie>> GetTop25HighestRevenueMovies();

        //Task<IEnumerable<Movie>> GetTop25RateMovies(); //Homework1: average of rating order by desc get top 25

        Task<Movie> GetMovieById(int d); //Homework2

        Task<Movie> CreateMovie(Movie movie); //Homework3

        Task<Movie> UpdateMovie(Movie movie); //Homework4

        Task<int> GetMoviesCount(string title); //Homework5
        
    }
}
