using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaScreening.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task<ActionResult<IList<MovieDto>>> Get()
        {
            var result = await _movieService.GetAll().ConfigureAwait(false);
            return new JsonResult(result.ToList());
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> Get(int id)
        {
            var result = await _movieService.GetById(id).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<ActionResult<MovieDto>> Post([FromBody] MovieDto movie)
        {
            var resultEntity = await _movieService.Create(movie).ConfigureAwait(false);
            return CreatedAtAction("Get", new { id = resultEntity.Id }, resultEntity);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MovieDto movie)
        {
            try
            {
                await _movieService.Update(id, movie).ConfigureAwait(false);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var movie = await _movieService.GetById(id).ConfigureAwait(false);
            if (movie == null)
            {
                return NotFound();
            }
            var result = await _movieService.Delete(id).ConfigureAwait(false);
            return result;
        }
    }
}
