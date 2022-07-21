using EFCoreRelationships.Data;
using EFCoreRelationships.Dto;
using EFCoreRelationships.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters
                .Where(u => u.UserId == userId)
                .ToListAsync();
            return characters;
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CharacterDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return NotFound();
            }
            var newCharacter = new Character
            {
                Name = request.Name,
                RpgClass = request.RpgClass,
                User = user
            };
            await _context.Characters.AddAsync(newCharacter);
            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserId);
        }
    }
}
