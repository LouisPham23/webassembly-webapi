using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_API;

namespace Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookContext _bookContext;

        public GenreRepository(BookContext bookContext)
        {
            _bookContext = bookContext;

        }
        public async Task<List<Genre>> GetGenres()
        {
            return await _bookContext.Genres.ToListAsync();

        }
    }
}
