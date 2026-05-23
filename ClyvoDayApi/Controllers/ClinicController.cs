using ClyvoDayApi.Data;
using ClyvoDayApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClinicController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinic>>> GetAll()
        {
            var clinics = await _context.Clinics.Include(c => c.Veterinarians).ToListAsync();

            return Ok(clinics);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Clinic>> GetById(int id)
        {
            var clinic = await _context.Clinics.Include(c => c.Veterinarians).FirstOrDefaultAsync(c => c.ClinicId == id);

            if (clinic == null)
                return NotFound("Clínica não encontrada.");

            return Ok(clinic);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Clinic newClinic)
        {
            _context.Clinics.Add(newClinic);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),new { id = newClinic.ClinicId },newClinic);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clinic = await _context.Clinics.Include(c => c.Veterinarians).FirstOrDefaultAsync(c => c.ClinicId == id);

            if (clinic == null)
                return NotFound("Clínica não encontrada.");

            _context.Clinics.Remove(clinic);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
