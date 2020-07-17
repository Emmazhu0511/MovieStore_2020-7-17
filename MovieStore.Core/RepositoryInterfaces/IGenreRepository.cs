using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieStore.Core.Entities;

namespace MovieStore.Core.RepositoryInterfaces
{
    public interface IGenreRepository: IAsyncRepository<Genre>
    {

        Task<IEnumerable<Genre>> GetAllGenres();
    }
}
