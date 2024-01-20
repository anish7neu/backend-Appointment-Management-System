//Registering database context
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskImark.DTOs;
using TaskImark.Models;

namespace TaskImark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VisitorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Visitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReqVisitorDTO>>> GetVisitors()
        {
            var visitors = await _context.Visitors.ToListAsync();
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
            

            return visitorsDTO;
        }

        // GET: api/Visitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReqVisitorDTO>> GetVisitor(int id)
        {

            var visitor = await _context.Visitors.FindAsync(id);
            var visitorDTO = new ReqVisitorDTO()
            {
                Id = visitor.Id,
                FirstName = visitor.FirstName,
                LastName = visitor.LastName,
                Address = visitor.Address,
                Phone = visitor.Phone,
                Gender = visitor.Gender,
                Remarks = visitor.Remarks,
                ManagerId = visitor.ManagerId,
                Date = visitor.Date,
            };
            if (visitor == null)
            {
                return NotFound();
            }

            return visitorDTO;
        }
        

        // PUT: api/Visitors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitor(int id, Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorExists(id))
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

        // POST: api/Visitors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(ResVisitorDTO visitorDTO)
        {
            var visitor = new Visitor()
            {

                FirstName = visitorDTO.FirstName,
                LastName = visitorDTO.LastName,
                Address = visitorDTO.Address,
                Phone = visitorDTO.Phone,
                Gender = visitorDTO.Gender,
                ManagerId = visitorDTO.ManagerId,
                Remarks = visitorDTO.Remarks,
                Date = visitorDTO.Date,
            };
            _context.Visitors.Add(visitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisitor), new { id = visitor.Id }, visitor);
        }



        // DELETE: api/Visitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }

            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitorExists(int id)
        {
            return _context.Visitors.Any(e => e.Id == id);
        }
    }
}
