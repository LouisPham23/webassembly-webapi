using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenres();
    }
}
