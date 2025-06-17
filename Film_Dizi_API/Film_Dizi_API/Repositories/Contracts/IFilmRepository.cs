using Film_Dizi_API.DTOs.Film;
using Film_Dizi_API.Helpers;
using Film_Dizi_API.Models;

namespace Film_Dizi_API.Repositories.Contracts
{
    public interface IFilmRepository
    {
        Task<List<Film>> GetAllFilmsAysnc(QueryObject query);
        Task<Film?> GetFilmByIdAysnc(int id);
        Task<Film> CreateFilmAsync(Film film);
        Task<Film?> UpdateFilmAsync(int id, UpdateFilmDto filmDto);
        Task<Film?> DeleteFilmAsync(int id);
        Task<bool> FilmExistsAsync(int id);
    }
}
