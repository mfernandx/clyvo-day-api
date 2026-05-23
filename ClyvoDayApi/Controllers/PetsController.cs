using ClyvoDayApi.Data;
using ClyvoDayApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var pets = await _context.Pets.ToListAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
                return NotFound();

            return Ok(pet);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Pet newPet)
        {
            var pets = new Pet(newPet.Name, newPet.Species, newPet.Breed, newPet.Gender, newPet.Age, newPet.Weight, newPet.BirthDate, newPet.TutorId);
            
            _context.Pets.Add(pets);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = pets.PetId }, pets);
        }


        [HttpPut("{id}/atualizapeso")]
        public async Task<ActionResult> UpdateWeight(int id,[FromBody] decimal newWeight)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
                return NotFound("Pet não encontrado.");

            pet.UpdateWeight(newWeight);

            await _context.SaveChangesAsync();

            return Ok(pet);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
                return NotFound("Pet não encontrado.");

            _context.Pets.Remove(pet);

            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}
