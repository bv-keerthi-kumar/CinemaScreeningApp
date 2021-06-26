using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaScreening.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public async Task<ActionResult<IList<GenreDto>>> Get()
        {
            var result = await _genreService.GetAll().ConfigureAwait(false);
            return result.ToList();
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> Get(int id)
        {
            var result = await _genreService.GetById(id).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST api/<GenreController>
        [HttpPost]
        public async Task<ActionResult<GenreDto>> Post([FromBody] GenreDto genre)
        {
            var result = await _genreService.Create(genre).ConfigureAwait(false);
            return CreatedAtAction("Get", new { id = result.Id }, result);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GenreDto genre)
        {
            try
            {
                await _genreService.Update(id, genre).ConfigureAwait(false);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var genre = await _genreService.GetById(id).ConfigureAwait(false);
            if (genre == null)
            {
                return NotFound();
            }
            var result = await _genreService.Delete(id).ConfigureAwait(false);
            return result;
        }
    }
}
