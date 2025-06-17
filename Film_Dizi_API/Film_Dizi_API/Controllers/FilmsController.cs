
using Film_Dizi_API.Data;
using Film_Dizi_API.DTOs.Actor;
using Film_Dizi_API.DTOs.Comment;
using Film_Dizi_API.DTOs.Film;
using Film_Dizi_API.Helpers;
using Film_Dizi_API.Mappers;
using Film_Dizi_API.Models;
using Film_Dizi_API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Film_Dizi_API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFilmRepository _filmRepo;

        public FilmsController(ApplicationDbContext context, IFilmRepository filmRepo)
        {
            _context = context;
            _filmRepo = filmRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilms([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var films = await _filmRepo.GetAllFilmsAysnc(query);

            var filmDto = films.Select(f => f.ToFilmDto());

            return Ok(filmDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var film = await _filmRepo.GetFilmByIdAysnc(id);

            if (film == null)
                return NotFound();

            return Ok(film.ToFilmDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilm([FromRoute] int id, [FromBody] UpdateFilmDto filmModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var film = await _filmRepo.UpdateFilmAsync(id, filmModel);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(film.ToFilmDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilm([FromBody] CreateFilmDto filmDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var filmModel = filmDto.ToCreateFilmFromDto();

            await _filmRepo.CreateFilmAsync(filmModel);

            return CreatedAtAction(nameof(GetFilmById), new { id = filmModel.Id }, filmModel.ToFilmDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteFilm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var filmModel = await _filmRepo.DeleteFilmAsync(id);

            if (filmModel is null)
            {
                return NotFound(id);
            }


            return NoContent();

        }

        [HttpPost("{filmId}/comments")]
        public async Task<ActionResult<CommentDto>> AddCommentToFilm(int filmId, CreateCommentForModelsDto createCommentDto)
        {
            var film = await _context.Films.FindAsync(filmId);
            if (film == null)
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

            return CreatedAtAction("Get Comment", "Comments", new { id = comment.Id },
                new CommentDto
                {
                    Id = comment.Id,
                    Title = comment.Title,
                    Content = comment.Content,
                    CreatedOn = DateTime.Now,
                });
        }

        [HttpGet("{filmId}/comments")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetFilmComments(int filmId)
        {
            var film = await _context.Films
                .Include(f => f.Comments)
                .FirstOrDefaultAsync(f => f.Id == filmId);

            if (film is null)
                return NotFound("Film bulunamadı.");

            var comments = film.Comments.OrderByDescending(c => c.CreatedOn)
                .Select(c => c.ToCommentDto());

            return Ok(comments);
        }
    }
}

