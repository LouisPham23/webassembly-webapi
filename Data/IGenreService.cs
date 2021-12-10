using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IGenreService
    {
        Task<List<Genre>> GetGenres();
    }
}
