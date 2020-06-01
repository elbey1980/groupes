using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WcfRESTGroupesClient;

namespace WcfRESTGroupesClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitesController : ControllerBase
    {
        private readonly groupesDBContext _context;

        public ActivitesController(groupesDBContext context)
        {
            _context = context;
        }

        // GET: api/Activites
        [HttpGet]
        public IEnumerable<Activite> GetActivite()
        {
            return _context.Activite;
        }

        // GET: api/Activites/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivite([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activite = await _context.Activite.FindAsync(id);

            if (activite == null)
            {
                return NotFound();
            }

            return Ok(activite);
        }

        // PUT: api/Activites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivite([FromRoute] string id, [FromBody] Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activite.NomActivite)
            {
                return BadRequest();
            }

            _context.Entry(activite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiviteExists(id))
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

        // POST: api/Activites
        [HttpPost]
        public async Task<IActionResult> PostActivite([FromBody] Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Activite.Add(activite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActiviteExists(activite.NomActivite))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActivite", new { id = activite.NomActivite }, activite);
        }

        // DELETE: api/Activites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivite([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activite = await _context.Activite.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }

            _context.Activite.Remove(activite);
            await _context.SaveChangesAsync();

            return Ok(activite);
        }

        private bool ActiviteExists(string id)
        {
            return _context.Activite.Any(e => e.NomActivite == id);
        }
    }
}