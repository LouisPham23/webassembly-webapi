using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repo;

        public GenreService(IGenreRepository genreRepository)
        {
            _repo = genreRepository;
        }

        public Task<List<Genre>> GetGenres()
        {
            return _repo.GetGenres();
        }
    }
}
