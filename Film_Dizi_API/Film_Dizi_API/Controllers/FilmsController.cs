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
        [HttpGet("id:int")]
        public IActionResult GetOneFilm([FromRoute(Name ="id")]int id)
        {
            var film = ApplicationContext.films.
                Where(b=>b.Id.Equals(id)).
                SingleOrDefault();
            

            if (film is null)
                return NotFound();
            
            return Ok(film);
        }

        [HttpPost]
        public IActionResult CreateOneFilm([FromBody]Films film)
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
    }
}
