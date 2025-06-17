using Azure.Core;
using Film_Dizi_API.Data;
using Film_Dizi_API.DTOs.Actor;
using Film_Dizi_API.DTOs.Comment;
using Film_Dizi_API.Helpers;
using Film_Dizi_API.Mappers;
using Film_Dizi_API.Models;
using Film_Dizi_API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Film_Dizi_API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IActorRepository _actorRepo;
        public ActorsController(ApplicationDbContext context, IActorRepository actorRepo)
        {
            _actorRepo = actorRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var actors = await _actorRepo.GetAllActorsAsync(query);

            var actorsDto = actors.Select(a => a.ToActorDto());


            return Ok(actorsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var actor = await _actorRepo.GetActorByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            var actorDto = actor.ToActorDto();

            return Ok(actorDto);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOneActor([FromBody] CreateActorDto actorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var actorModel = actorDto.ToActorCreateFromDto();

            await _actorRepo.CreateActorAysnc(actorModel);

            return CreatedAtAction(nameof(GetActorById), new { id = actorModel.Id }, actorModel.ToActorDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateActor([FromRoute] int id, [FromBody] UpdateActorDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var actorModel = await _actorRepo.UpdateActorAsync(id, updateDto);

            if (actorModel == null)
            {
                return NotFound();
            }

            return Ok(actorModel.ToActorDto());


        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteActor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var actorModel = await _actorRepo.DeleteActorAsync(id);

            if (actorModel is null)
            {
                return NotFound(id);
            }


            return NoContent();

        }

        [HttpPost("{actorId}/comments")]
        public async Task<ActionResult<CommentDto>> AddCommentToFilm(int actorId, CreateCommentForModelsDto createCommentDto)
        {
            var actor = await _context.Actors.FindAsync(actorId);
            if (actor == null)
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

        [HttpGet("{actorId}/comments")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetFilmComments(int actorId)
        {
            var actor = await _context.Actors
                .Include(f => f.Comments)
                .FirstOrDefaultAsync(f => f.Id == actorId);

            if (actor is null)
                return NotFound("Film bulunamadı.");

            var comments = actor.Comments.OrderByDescending(c => c.CreatedOn)
                .Select(c => c.ToCommentDto());

            return Ok(comments);
        }
    }
}
