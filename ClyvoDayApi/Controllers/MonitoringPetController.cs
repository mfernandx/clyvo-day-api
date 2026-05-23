using ClyvoDayApi.Data;
using ClyvoDayApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoringPetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MonitoringPetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitoringPet>>> GetAll()
        {
            var monitorings = await _context.Monitorings.Include(m => m.Pet).ToListAsync();

            return Ok(monitorings);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MonitoringPet>> GetById(int id)
        {
            var monitoring = await _context.Monitorings.Include(m => m.Pet).FirstOrDefaultAsync(m => m.MonitoringPetId == id);

            if (monitoring == null)
                return NotFound();

            return Ok(monitoring);
        }


        [HttpGet("pet/{petId}")]
        public async Task<ActionResult<IEnumerable<MonitoringPet>>> GetByPetId(int petId)
        {
            var monitoramentos = await _context.Monitorings.Where(m => m.PetId == petId).ToListAsync();

            return Ok(monitoramentos);
        }



        [HttpPost]
        public async Task<ActionResult> Create(MonitoringPet newMonitoring)
        {
            var pet = await _context.Pets.FindAsync(newMonitoring.PetId);

            if (pet == null)
                return NotFound("Pet não encontrado.");

            _context.Monitorings.Add(newMonitoring);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newMonitoring.MonitoringPetId }, newMonitoring);
        }

    }
}
