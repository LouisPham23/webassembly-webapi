using Data;
using Data.Entities;
using System.Net.Http.Json;

namespace FrontEnd.Services
{
    public class GenreService : IGenreService
    {
        private readonly HttpClient httpClient;
        public GenreService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Genre>> GetGenres()
        {
            return await httpClient.GetFromJsonAsync<List<Genre>>("/api/genres");
        }
    }
}
