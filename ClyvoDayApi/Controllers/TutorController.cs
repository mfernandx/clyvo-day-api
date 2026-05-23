using ClyvoDayApi.Data;
using ClyvoDayApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TutorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetAll()
        {
            var tutors = await _context.Tutors.Include(t => t.Pets).ToListAsync();
            return Ok(tutors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetById(int id)
        {
            var tutor = await _context.Tutors.Include(t => t.Pets).FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutor == null)
                return NotFound();

            return Ok(tutor);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Tutor tutor)
        {
            _context.Tutors.Add(tutor);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),new { id = tutor.TutorId }, tutor);
        }


        [HttpPut("{id}/atualizacontato")]
        public async Task<ActionResult> UpdateContact(int id,[FromBody] Tutor updatedContact)
        {
            var tutor = await _context.Tutors.FindAsync(id);

            if (tutor == null)
                return NotFound("Tutor não encontrado.");

            tutor.UpdateContact(updatedContact.Email,updatedContact.PhoneNumber);

            await _context.SaveChangesAsync();

            return Ok(tutor);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tutor = await _context.Tutors.Include(t => t.Pets).FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutor == null)
                return NotFound("Tutor não encontrado.");

            _context.Tutors.Remove(tutor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
