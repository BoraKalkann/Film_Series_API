using Film_Dizi_API.DTOs.Comment;
using Film_Dizi_API.DTOs.Film;
using Film_Dizi_API.Models;

namespace Film_Dizi_API.Mappers
{
    public static class FilmMappers
    {
        public static FilmDto ToFilmDto(this Film filmModel)
        {
            return new FilmDto
            {
                Id = filmModel.Id,
                Title = filmModel.Title,
                Description = filmModel.Description,
                Director = filmModel.Director,
                Duration = filmModel.Duration,
                Rating = filmModel.Rating,
                ReleaseDate = filmModel.ReleaseDate,
            };
        }

        public static Film ToCreateFilmFromDto(this CreateFilmDto filmModel)
        {
            return new Film
            {
                Title = filmModel.Title,
                Description = filmModel.Description,
                Director = filmModel.Director,
                Duration = filmModel.Duration,
                Rating = filmModel.Rating,
                ReleaseDate = filmModel.ReleaseDate,
            };
        }

        public static Film ToUpdateFilmFromDto(this UpdateFilmDto filmModel)
        {
            return new Film
            {
                Title = filmModel.Title,
                Description = filmModel.Description,
                Director = filmModel.Director,
                Duration = filmModel.Duration,
                ReleaseDate = filmModel.ReleaseDate,
                Rating = filmModel.Rating,

            };
        }
    }
}
