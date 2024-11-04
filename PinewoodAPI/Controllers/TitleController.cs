using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace PinewoodAPI.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class TitleController : Controller
    {
        private ITitlesRepository _titlesRepository;

        public TitleController(ITitlesRepository titlesRepository)
        {
            _titlesRepository = titlesRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Title>))]
        public IActionResult GetTitles()
        {
            var titles = _titlesRepository.GetTitles();

            if (!ModelState.IsValid)
                return BadRequest(titles);

            return Ok(titles);
        }

    }
}
