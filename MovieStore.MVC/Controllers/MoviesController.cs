using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.Entities;
using MovieStore.Core.ServiceInterfaces;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.MVC.Controllers
{
    public class MoviesController : Controller
    {
        //  var movieService = new MovieService();
        // 5 seconds var movies = await movieService.GetALlMovie(); i/0
        // return a Task for you
        // Improving the scalability of the application, so that you r application can server many concurrent requests properly
        // async/await will prevent thread starvation scenario.
        // I/O bound operation not CPU for belows
        // Database calls, Http calls, over network
        // Task<Movie>, Task<int>
        // in your C# or any Library whenever you see a method with Async in the method name, that means you can await that method
        // EF, two kind of methods, normal sync method, async methods...
        // Async was introduced from .NET 4.5, C# 5 year 2012


        // IOC, ASP.NET Core has built-in IOC/DI
        // In .NET Framework we need yo rely on thrid-party IOC to do dependency injection, autodac, Ninject
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService) {

            _movieService = movieService;
        }

        //  Get localhost/Movie/Index
        [HttpGet]

        public async Task<IActionResult> Index() {

            //call our Movie Service, method, highest grossing method
            var movies = await _movieService.GetTop25HighestRevenueMovies();
            return View(movies);

        }

        [HttpGet]

        public async Task<IActionResult> Search(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            return View(movie);

        }

        public async Task<IActionResult> Count(string title) {

            var count = await _movieService.GetMoviesCount(title);
            return View(count);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie) {

            var result = await _movieService.CreateMovie(movie);

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Movie movie) {

            var result = await _movieService.UpdateMovie(movie);

            return View(result);
        }

        // GET: /<controller>/

        /*public IActionResult Index()
        {

            List<Movie> movies = new List<Movie>() {
                new Movie {Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
                new Movie {Id = 2, Title = "Avatar", Budget = 1200000},
                new Movie {Id = 3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
                new Movie {Id = 4, Title = "Titanic", Budget = 1200000},
                new Movie {Id = 5, Title = "Inception", Budget = 1200000},
                new Movie {Id = 6, Title = "Avengers: Age of Ultron", Budget = 1200000},
                new Movie {Id = 7, Title = "Interstellar", Budget = 1200000},
                new Movie {Id = 8, Title = "Fight Club", Budget = 1200000},

            };
            return View(movies);
        */
        }
    
}
