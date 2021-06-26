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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        // GET: api/<LanguageController>
        [HttpGet]
        public async Task<ActionResult<IList<LanguageDto>>> Get()
        {
            var result = await _languageService.GetAll().ConfigureAwait(false);
            return result.ToList();
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageDto>> Get(int id)
        {
            var result = await _languageService.GetById(id).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST api/<LanguageController>
        [HttpPost]
        public async Task<ActionResult<LanguageDto>> Post([FromBody] LanguageDto language)
        {
            var result = await _languageService.Create(language).ConfigureAwait(false);
            return CreatedAtAction("Get", new { id = result.Id }, result);
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LanguageDto language)
        {
            try
            {
                await _languageService.Update(id, language).ConfigureAwait(false);
            }
            catch
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var language = await _languageService.GetById(id).ConfigureAwait(false);
            if (language == null)
            {
                return NotFound();
            }
            var result = await _languageService.Delete(id).ConfigureAwait(false);
            return result;
        }
    }
}
