using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace PinewoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private IActivitiesRepository _activitiesRepository;

        public ActivityController(IActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Activity>))]
        public IActionResult GetActivities()
        {
            var activities = _activitiesRepository.GetActivities();

            if (!ModelState.IsValid)
                return BadRequest(activities);

            return Ok(activities);
        }


        [HttpGet("{activityId}")]
        [ProducesResponseType(200, Type = typeof(Activity))]
        [ProducesResponseType(400)]
        public IActionResult GetActivity(int activityId)
        {
            if (!_activitiesRepository.ActivityExists(activityId))
                return NotFound();

            var activity = _activitiesRepository.GetActivity(activityId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(activity);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateActivity([FromBody] Activity activityCreate)
        {
            if (CreateActivity == null)
                return BadRequest(ModelState);

            var contact = _activitiesRepository.GetActivities()
                .Where(c => c.Notes.Trim().ToUpper() == activityCreate.Notes.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (contact != null)
            {
                ModelState.AddModelError("", "Activity already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_activitiesRepository.CreateActivity(activityCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{activityId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateActivty(int activityId, [FromBody] Activity updatedActivity)
        {
            if (updatedActivity == null)
                return BadRequest(ModelState);

            if (activityId != updatedActivity.ActivityId)
                return BadRequest(ModelState);

            if (!_activitiesRepository.ActivityExists(activityId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();


            if (!_activitiesRepository.UpdateActivity(updatedActivity))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }


        [HttpDelete("{activityId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteActivity(int activityId)
        {
            if (!_activitiesRepository.ActivityExists(activityId))
            {
                return NotFound();
            }

            var activityToDelete = _activitiesRepository.GetActivity(activityId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_activitiesRepository.DeleteActivity(activityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return Ok();
        }

    }
}
