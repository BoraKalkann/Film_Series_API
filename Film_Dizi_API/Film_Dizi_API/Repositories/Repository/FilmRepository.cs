using Film_Dizi_API.Data;
using Film_Dizi_API.DTOs.Actor;
using Film_Dizi_API.DTOs.Film;
using Film_Dizi_API.Helpers;
using Film_Dizi_API.Models;
using Film_Dizi_API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Film_Dizi_API.Repositories.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;
        public FilmRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Film> CreateFilmAsync(Film film)
        {
            await _context.Films.AddAsync(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<Film?> DeleteFilmAsync(int id)
        {
            var filmModel = await _context.Films.FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (filmModel is null)
            {
                return null;
            }

            _context.Films.Remove(filmModel);
            await _context.SaveChangesAsync();

            return filmModel;
        }

        public async Task<List<Film>> GetAllFilmsAysnc(QueryObject query)
        {
            return await _context.Films.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Film?> GetFilmByIdAysnc(int id)
        {
            return await _context.Films.Include(c => c.Comments).FirstOrDefaultAsync(f =>  f.Id == id);
        }

        public async Task<Film?> UpdateFilmAsync(int id, UpdateFilmDto filmDto)
        {
            var existingFilm = await _context.Films.FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (existingFilm is null)
            {
                return null;
            }
            
            existingFilm.Title = filmDto.Title;
            existingFilm.Description = filmDto.Description;
            existingFilm.Duration = filmDto.Duration;
            existingFilm.Rating = filmDto.Rating;
            existingFilm.Director = filmDto.Director;
            existingFilm.ReleaseDate = filmDto.ReleaseDate;

            await _context.SaveChangesAsync();

            return existingFilm;
        }

        public async Task<bool> FilmExistsAsync(int id)
        {
            return await _context.Films.AnyAsync(f => f.Id == id);
        }
    }
}
