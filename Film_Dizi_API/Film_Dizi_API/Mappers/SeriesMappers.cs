using Film_Dizi_API.DTOs.Film;
using Film_Dizi_API.DTOs.Series;
using Film_Dizi_API.Models;

namespace Film_Dizi_API.Mappers
{
    public static class SeriesMappers
    {
        public static SeriesDto ToSeriesDto(this Series seriesModel)
        {
            return new SeriesDto
            {
                Id = seriesModel.Id,
                Title = seriesModel.Title,
                Description = seriesModel.Description,
                Creator = seriesModel.Creator,
                EpisodeCount = seriesModel.EpisodeCount,
                Rating = seriesModel.Rating,
                SeasonCount = seriesModel.SeasonCount,
                Status = seriesModel.Status
            };
        }

        public static Series ToCreateSeriesFromDto(this CreateSeriesDto seriesModel)
        {
            return new Series
            {
                Title = seriesModel.Title,
                Description = seriesModel.Description,
                Rating = seriesModel.Rating,
                Status = seriesModel.Status,
                EpisodeCount = seriesModel.EpisodeCount,
                SeasonCount = seriesModel.SeasonCount,
                Creator = seriesModel.Creator 
            };
        }

        public static Series ToUpdateSeriesFromDto(this UpdateSeriesDto seriesModel)
        {
            return new Series
            {
                Title = seriesModel.Title,
                Description = seriesModel.Description,
                Rating = seriesModel.Rating,
                Status = seriesModel.Status,
                EpisodeCount = seriesModel.EpisodeCount,
                SeasonCount = seriesModel.SeasonCount,
                Creator = seriesModel.Creator
            };
        }
    }
}
