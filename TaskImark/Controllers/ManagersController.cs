//Registering database context
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskImark.DTOs;
using TaskImark.Models;

namespace TaskImark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly AppDbContext _context;
        

        public ManagersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            var visitors = await _context.Managers.ToListAsync();
            return visitors;
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            
            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }
        //Get: api/Managers/2/Visitors
        [HttpGet("{id}/Visitors")]
        public async Task<ActionResult<List<ReqVisitorDTO>>> GetVisitorsByManager(int id)
        {
            
            
            var visitors = await _context.Visitors.Where(x => x.ManagerId == id).ToListAsync();

            var visitorsDTO = (from visitorDTO in visitors select new ReqVisitorDTO()
                               {
                                   Id = visitorDTO.Id,  
                                   FirstName = visitorDTO.FirstName,
                                   LastName = visitorDTO.LastName,
                                   Address = visitorDTO.Address,
                                   Phone = visitorDTO.Phone,
                                   Gender = visitorDTO.Gender,
                                   Remarks = visitorDTO.Remarks,
                                   ManagerId = visitorDTO.ManagerId,
                                   Date = visitorDTO.Date,
                               }).ToList();
            if (visitorsDTO == null)
            {
                return NotFound();
            }

            return visitorsDTO;
        }

        // PUT: api/Managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(int id, Manager manager)
        {
            if (id != manager.Id)
            {
                return BadRequest();
            }

            _context.Entry(manager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetManager), new { id = manager.Id }, manager);
        }  

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagerExists(int id)
        {
            return _context.Managers.Any(e => e.Id == id);
        }
    }
}
