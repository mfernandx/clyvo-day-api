using ClyvoDayApi.Data;
using ClyvoDayApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinarianController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeterinarianController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinarian>>> GetAll()
        {
            var veterinarians = await _context.Veterinarians.Include(v => v.Clinic).ToListAsync();

            return Ok(veterinarians);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinarian>> GetById(int id)
        {
            var veterinarian = await _context.Veterinarians.Include(v => v.Clinic).FirstOrDefaultAsync(v => v.VeterinarianId == id);

            if (veterinarian == null)
                return NotFound("Veterinário não encontrado.");

            return Ok(veterinarian);
        }


        [HttpGet("clinica/{clinicId}")]
        public async Task<ActionResult<IEnumerable<Veterinarian>>> GetByClinicId(int clinicId)
        {
            var veterinarians = await _context.Veterinarians.Where(v => v.ClinicId == clinicId).ToListAsync();

            return Ok(veterinarians);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Veterinarian newVeterinarian)
        {
            var clinic = await _context.Clinics.FindAsync(newVeterinarian.ClinicId);

            if (clinic == null)
                return NotFound("Clínica não encontrada.");

            _context.Veterinarians.Add(newVeterinarian);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),new { id = newVeterinarian.VeterinarianId },newVeterinarian);
        }


        [HttpPut("{id}/atualizacontato")]
        public async Task<ActionResult> UpdateContact(int id,[FromBody] Veterinarian updatedVeterinarian)
        {
            var veterinarian = await _context.Veterinarians.FindAsync(id);

            if (veterinarian == null)
                return NotFound("Veterinário não encontrado.");

            veterinarian.UpdateContact(updatedVeterinarian.Email, updatedVeterinarian.PhoneNumber);

            await _context.SaveChangesAsync();

            return Ok(veterinarian);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var veterinarian = await _context.Veterinarians.FindAsync(id);

            if (veterinarian == null)
                return NotFound("Veterinário não encontrado.");

            _context.Veterinarians.Remove(veterinarian);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
