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
    public class GenreRepository: EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieStoreDbContext dbContext) : base(dbContext)
        {


        }

        //Select all Genres 
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await _dbContext.Genres.Select(x=> x).ToListAsync();
            return genres;
        }
    }
}
