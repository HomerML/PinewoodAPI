using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace PinewoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private IStatusesRepository _statusesRepository;

        public StatusController(IStatusesRepository statusesRepository)
        {
            _statusesRepository = statusesRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Status>))]
        public IActionResult GetStatuses()
        {
            var statuses = _statusesRepository.GetStatuses();

            if (!ModelState.IsValid)
                return BadRequest(statuses);

            return Ok(statuses);
        }
    }
}
