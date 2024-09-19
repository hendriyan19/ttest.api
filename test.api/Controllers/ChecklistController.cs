using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.api.Models; 
using test.api.Repository; 

namespace test.api.Controllers
{
 

    [ApiController]
    [Route("checklist")]
    public class ChecklistController : ControllerBase
    {
        private readonly IRepositoryChecklist _checklistRepository;

        public ChecklistController(IRepositoryChecklist checklistRepository)
        {
            _checklistRepository = checklistRepository;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Checklist>>> GetAll()
        {
            var checklists = await _checklistRepository.GetAllChecklistsAsync();
            return Ok(checklists);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Checklist>> Create([FromBody] Checklist checklist)
        {
            if (checklist == null)
            {
                return BadRequest("Checklist is null.");
            }

            var createdChecklist = await _checklistRepository.CreateChecklistAsync(checklist);
            return CreatedAtAction(nameof(GetAll), new { id = createdChecklist.Id }, createdChecklist);
        }

        [HttpDelete("{checklistId}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int checklistId)
        {
            var result = await _checklistRepository.DeleteChecklistAsync(checklistId);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }

}
