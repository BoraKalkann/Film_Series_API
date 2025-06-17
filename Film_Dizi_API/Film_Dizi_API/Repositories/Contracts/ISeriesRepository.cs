using Film_Dizi_API.DTOs.Series;
using Film_Dizi_API.Helpers;
using Film_Dizi_API.Models;

namespace Film_Dizi_API.Repositories.Contracts
{
    public interface ISeriesRepository
    {
        Task<List<Series>> GetAllSeriesAsync(QueryObject query);
        Task<Series?> GetSeriesByIdAsync(int id);
        Task<Series?> DeleteSeries(int id);
        Task<Series?> UpdateSeriesAsync(int id, UpdateSeriesDto seriesDto);
        Task<Series> CreateSeriesAsync(Series series);
    }
}
