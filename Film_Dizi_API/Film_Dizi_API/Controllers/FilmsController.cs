using Film_Dizi_API.Data;
using Film_Dizi_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film_Dizi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllFilms()
        {
            var films = ApplicationContext.films;
            return Ok(films);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneFilm([FromRoute(Name = "id")] int id)
        {
            var film = ApplicationContext.films.
                Where(b => b.Id.Equals(id)).
                SingleOrDefault();


            if (film is null)
                return NotFound();

            return Ok(film);
        }

        [HttpPost]
        public IActionResult CreateOneFilm([FromBody] Films film)
        {
            try
            {
                if (film is null)
                    return BadRequest();//400 Bad Req Üretecek
                ApplicationContext.films.Add(film);
                return StatusCode(201, film);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneFilm([FromRoute(Name = "id")] int id, [FromBody] Films film)
        {
            // Check if the film exists
            var entity = ApplicationContext.films.Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(); // Return 404 if the film is not found

            if (id != film.Id)
                return BadRequest("ID in the route and body do not match."); // Return 400 if IDs mismatch

            // Update the existing film
            entity.Title = film.Title;
            entity.ReleaseDate = film.ReleaseDate;

            return Ok(entity); // Return the updated film
        }

        [HttpDelete]
        public IActionResult DeleteAllMovies()
        {
            ApplicationContext.films.Clear();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneMovie([FromRoute(Name ="id")]int id)
        {
            var entity = ApplicationContext
                .films.
                Find(b => b.Id.Equals(id));
            if(entity is null)
            {
                return NotFound(new {
                    StatusCode = 404,
                    message = $"Book with this id ({id}) does not found. "
                });
            }
            ApplicationContext.films.Remove(entity);
            return NoContent();

        }


        
    }
}
