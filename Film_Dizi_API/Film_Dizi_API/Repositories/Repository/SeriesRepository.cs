using Film_Dizi_API.Data;
using Film_Dizi_API.DTOs.Actor;
using Film_Dizi_API.DTOs.Series;
using Film_Dizi_API.Helpers;
using Film_Dizi_API.Models;
using Film_Dizi_API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Film_Dizi_API.Repositories.Repository
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly ApplicationDbContext _context;
        public SeriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Series> CreateSeriesAsync(Series series)
        {
            await _context.Series.AddAsync(series);
            await _context.SaveChangesAsync();
            return series;
        }

        public async Task<Series?> DeleteSeries(int id)
        {
            var seriesModel = await _context.Series.FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (seriesModel is null)
            {
                return null;
            }

            _context.Series.Remove(seriesModel);
            await _context.SaveChangesAsync();

            return seriesModel;
        }

        public async Task<Series?> GetSeriesByIdAsync(int id)
        {
            return await _context.Series.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task<List<Series>> GetAllSeriesAsync(QueryObject query)
        {
            var series = _context.Series.Include(c => c.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                series = series.Where(s => s.Title.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    series = query.IsDecsending ? series.OrderByDescending(s => s.Title) : series.OrderBy(s => s.Title);
                }
                
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await series.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Series> UpdateSeriesAsync(int id, UpdateSeriesDto seriesDto)
        {

            var existingSeries = await _context.Series.FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (existingSeries is null)
            {
                return null;
            }

            existingSeries.Title = seriesDto.Title;
            existingSeries.Description = seriesDto.Description;
            existingSeries.Rating = seriesDto.Rating;
            existingSeries.Status = seriesDto.Status;
            existingSeries.Creator = seriesDto.Creator;

            await _context.SaveChangesAsync();

            return existingSeries;
        }
    }
}
