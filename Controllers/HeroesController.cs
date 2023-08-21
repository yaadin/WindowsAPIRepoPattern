using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HeroesAPI.Models;
using HeroesAPI.Data;
using Microsoft.EntityFrameworkCore;
using HeroesAPI.Services.HeroService;

namespace HeroesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroInterface _repository;
        public HeroesController(IHeroInterface repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HeroModel>> Getall()
        {
            try
            {
                var AllHeroes = await _repository.Getall();
                if (AllHeroes == null) 
                {
                    return NotFound(); 
                }
                return Ok(AllHeroes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occured: {ex.Message}");
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostHero([FromBody] HeroModel model)
        {
            try
            {
                if (model.id != 0)
                {
                    return BadRequest();
                }
                var HeroToBePosted = await _repository.PostHero(model);
                if (HeroToBePosted == null)
                {
                    return NotFound();
                }
                return Ok(HeroToBePosted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occured: {ex.Message}");
            }
        }
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HeroModel>> GetByiD(int id)
        {
            try
            {
                HeroModel Hero = await _repository.GetByiD(id);
                if (Hero == null)
                {
                    return NotFound();
                }
                return Ok(Hero);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occured: {ex.Message}");
            }
        }
    }
}
