using Film_Dizi_API.DTOs.Comment;
using Film_Dizi_API.Mappers;
using Film_Dizi_API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Film_Dizi_API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IActorRepository _actorRepo;
        public CommentsController(ICommentRepository commentRepo, IActorRepository actorRepo)
        {
            _commentRepo = commentRepo;
            _actorRepo = actorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            var comments = await _commentRepo.GetAllCommentsAsync();

            var commentDto = comments.Select(s => s.ToCommentDto()).ToList();

            return Ok(commentDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comment = await _commentRepo.GetCommentByIdAsync(id);

            if (comment is null)
                return NotFound();

            return Ok(comment.ToCommentDto());

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comment = await _commentRepo.UpdateCommentAsync(id, updateDto.ToCommentUpdateFromDto());

            if (comment is null)
                return NotFound("Comment not found");

            return Ok(comment.ToCommentDto());

        }


        [HttpPost("{actorId:int}")]
        public async Task<IActionResult> CreateComment([FromRoute] int actorId, CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _actorRepo.ActorExists(actorId))
            {
                return BadRequest("Actor does not exist");
            }

            var commentModel = commentDto.ToCommentCreateFromDto(actorId);
            await _commentRepo.CreateCommentAsync(commentModel);

            return CreatedAtAction(nameof(GetCommentById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var commentModel = await _commentRepo.DeleteCommentAsync(id);

            if (commentModel is null) return NotFound("Comment not found");

            return Ok(commentModel.ToCommentDto());
        }
    }
}
