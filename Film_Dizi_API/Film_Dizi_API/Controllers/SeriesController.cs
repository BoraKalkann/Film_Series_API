using Film_Dizi_API.Data;
using Film_Dizi_API.Models;
using Film_Dizi_API.Models.Film_Dizi_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Film_Dizi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllSeries()
        {
            var serie = ApplicationContext.series;
            return Ok(serie);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneSerie([FromRoute(Name = "id")] int id)
        {
            var serie = ApplicationContext.series.
                Where(b => b.Id.Equals(id)).
                SingleOrDefault();


            if (serie is null)
                return NotFound();

            return Ok(serie);
        }

        [HttpPost]
        public IActionResult CreateOneSerie([FromBody] Series serie)
        {
            try
            {
                if (serie is null)
                    return BadRequest();//400 Bad Req Üretecek
                ApplicationContext.series.Add(serie);
                return StatusCode(201, serie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneSerie([FromRoute(Name = "id")] int id, [FromBody] Series serie)
        {
            // Check if the film exists
            var entity = ApplicationContext.series.Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(); // Return 404 if the film is not found

            if (id != serie.Id)
                return BadRequest("ID in the route and body do not match."); // Return 400 if IDs mismatch

            // Update the existing film
            entity.Title = serie.Title;
            entity.Publisher = serie.Publisher;
            entity.Seasons = serie.Seasons;

            return Ok(entity); // Return the updated film
        }


        [HttpDelete]
        public IActionResult DeleteAllSeries()
        {
            ApplicationContext.series.Clear();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneSerie([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext
                .series
                .Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    message = $"Serie with this id ({id}) does not found. "
                });
            }
            ApplicationContext.series.Remove(entity); // Corrected to remove from the 'series' list
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneSerie([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Series> seriePatch)
        {
            var entity = ApplicationContext.series.Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound();
            seriePatch.ApplyTo(entity);
            return NoContent();
        }

    }
}
