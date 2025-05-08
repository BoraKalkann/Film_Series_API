using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Dizi_API.Data;
using Film_Dizi_API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Film_Dizi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllActors()
        {
            var actors = ApplicationContext.actors;
            return Ok(actors);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneActor([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext.actors
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult CreateOneActor([FromBody] Actors actor)
        {
            try
            {
                if (actor is null)
                    return BadRequest(); // 400 Bad Request
                ApplicationContext.actors.Add(actor);
                return StatusCode(201, actor); // 201 Created
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneActor([FromRoute(Name = "id")] int id, [FromBody] Actors actor)
        {
            var entity = ApplicationContext.actors
                .Find(b => b.Id.Equals(id));

            if (entity is null)
                return NotFound(new
                {
                    message = $"Actor with ID {id} not found."
                }); // 404 Not Found

            if (id != actor.Id)
                return BadRequest($"ID in the route and body do not match."); // 400 Bad Request

            ApplicationContext.actors.Remove((Actors)entity);
            actor.Id = entity.Id;
            ApplicationContext.actors.Add(actor);
            return Ok(actor); // 200 OK
        }

        [HttpDelete]
        public IActionResult DeleteAllActors()
        {
            ApplicationContext.actors.Clear();
            return Ok("All actors deleted.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneActor([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext.actors
                .Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(new
                {
                    message = $"Actor with ID {id} not found."
                }); // 404 Not Found
            ApplicationContext.actors.Remove((Actors)entity);
            return Ok(entity); // 200 OK
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneActor([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Actors> actorPatch)
        {
            var entity = ApplicationContext.actors
                .Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(new
                {
                    message = $"Actor with ID {id} not found."
                }); // 404 Not Found
            actorPatch.ApplyTo(entity);
            return Ok(entity); // 200 OK

        }
    }
}
