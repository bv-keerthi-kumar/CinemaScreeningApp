using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Infra.Dtos;
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
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        // GET: api/<DirectorController>
        [HttpGet]
        public async Task<ActionResult<IList<Director>>> Get()
        {
            var result = await _directorService.GetAll().ConfigureAwait(false);
            return result.ToList();
        }

        // GET api/<DirectorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> Get(int id)
        {
            var result = await _directorService.GetById(id).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST api/<DirectorController>
        [HttpPost]
        public async Task<ActionResult<Director>> Post([FromBody] Director director)
        {            
            var resultEntity = await _directorService.Create(director).ConfigureAwait(false);
            return CreatedAtAction("Get", new { id = resultEntity.Id }, resultEntity);
        }

        // PUT api/<DirectorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Director director)
        {
            try
            {               
                await _directorService.Update(id,director).ConfigureAwait(false);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<DirectorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var director = await _directorService.GetById(id).ConfigureAwait(false);
            if (director == null)
            {
                return NotFound();
            }            
           var result = await _directorService.Delete(id).ConfigureAwait(false);
            return result;
        }
    }
}
