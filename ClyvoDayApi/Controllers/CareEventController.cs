using ClyvoDayApi.Data;
using ClyvoDayApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CareEventController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CareEventController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareEvent>>> GetAll()
        {
            var events = await _context.Events.Include(e => e.Pet).ToListAsync();

            return Ok(events);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CareEvent>> GetById(int id)
        {
            var careEvent = await _context.Events.Include(e => e.Pet).FirstOrDefaultAsync(e => e.CareEventId == id);

            if (careEvent == null)
                return NotFound("Evento não encontrado.");

            return Ok(careEvent);
        }



        [HttpPost]
        public async Task<ActionResult> Create(CareEvent newEvent)
        {
            var pet = await _context.Pets.FindAsync(newEvent.PetId);

            if (pet == null)
                return NotFound("Pet não encontrado.");

            _context.Events.Add(newEvent);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),new { id = newEvent.CareEventId },newEvent);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var careEvent = await _context.Events.FindAsync(id);

            if (careEvent == null)
                return NotFound("Evento não encontrado.");

            _context.Events.Remove(careEvent);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
