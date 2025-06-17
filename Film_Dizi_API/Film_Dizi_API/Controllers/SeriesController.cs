using Film_Dizi_API.Data;
using Film_Dizi_API.DTOs.Comment;
using Film_Dizi_API.DTOs.Film;
using Film_Dizi_API.DTOs.Series;
using Film_Dizi_API.Helpers;
using Film_Dizi_API.Mappers;
using Film_Dizi_API.Models;
using Film_Dizi_API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Film_Dizi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISeriesRepository _seriesRepo;

        public SeriesController(ApplicationDbContext context, ISeriesRepository seriesRepo)
        {
            _context = context;
            _seriesRepo = seriesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeries([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var series = await _seriesRepo.GetAllSeriesAsync(query);

            var seriesDto = series.Select(f => f.ToSeriesDto());

            return Ok(seriesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSeriesById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var serie = await _seriesRepo.GetSeriesByIdAsync(id);

            if (serie == null)
                return NotFound();

            return Ok(serie.ToSeriesDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSeries([FromRoute] int id, [FromBody] UpdateSeriesDto seriesModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var serie = await _seriesRepo.UpdateSeriesAsync(id, seriesModel);

            if (serie == null)
            {
                return NotFound();
            }

            return Ok(serie.ToSeriesDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSerie([FromBody] CreateSeriesDto seriesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var seriesModel = seriesDto.ToCreateSeriesFromDto();

            await _seriesRepo.CreateSeriesAsync(seriesModel);

            return CreatedAtAction(nameof(GetSeriesById), new { id = seriesModel.Id }, seriesModel.ToSeriesDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteSerie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var serieModel = await _seriesRepo.DeleteSeries(id);

            if (serieModel is null)
            {
                return NotFound(id);
            }


            return NoContent();

        }

        [HttpPost("{seriesId:int}/comments")]
        public async Task<ActionResult<CommentDto>> AddCommentToFilm(int seriesId, CreateCommentForModelsDto createCommentDto)
        {
            var serie = await _context.Series.FindAsync(seriesId);
            if (serie == null)
                return NotFound("Film bulunamadı.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                CreatedOn = DateTime.Now,
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentById", "Comments", new { id = comment.Id },
                new CommentDto
                {
                    Id = comment.Id,
                    Title = comment.Title,
                    Content = comment.Content,
                    CreatedOn = DateTime.Now,
                });
        }

        [HttpGet("{seriesId:int}/comments")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetFilmComments(int seriesId)
        {
            var serie = await _context.Series
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(y => y.Id == seriesId);

            if (serie is null)
                return NotFound("Film bulunamadı.");

            var comments = serie.Comments.OrderByDescending(c => c.CreatedOn)
                .Select(c => c.ToCommentDto());

            return Ok(comments);
        }
    }
}
