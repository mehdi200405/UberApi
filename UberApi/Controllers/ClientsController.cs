﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UberApi.Models.EntityFramework;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursiersController : ControllerBase
    {
        private readonly S221UberContext _context;

        public CoursiersController(S221UberContext context)
        {
            _context = context;
        }

        // GET: api/coursiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coursier>>> GetCoursiers()
        {
            var coursiers = await _context.Coursiers
                .Include(c => c.Adresse)
                .Include(c => c.Entretien)
                .Include(c => c.Vehicules)
                .ToListAsync();

            return Ok(coursiers);
        }

        // GET: api/coursiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coursier>> GetCoursier(int id)
        {
            var coursier = await _context.Coursiers
                .Include(c => c.Adresse)
                .Include(c => c.Entretien)
                .Include(c => c.Vehicules)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (coursier == null)
            {
                return NotFound();
            }

            return Ok(coursier);
        }

        // POST: api/coursiers
        [HttpPost]
        public async Task<ActionResult<Coursier>> PostCoursier(Coursier coursier)
        {
            _context.Coursiers.Add(coursier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoursier", new { id = coursier.Id }, coursier);
        }

        // PUT: api/coursiers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoursier(int id, Coursier coursier)
        {
            if (id != coursier.Id)
            {
                return BadRequest();
            }

            _context.Entry(coursier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursierExists(id))
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

        // DELETE: api/coursiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoursier(int id)
        {
            var coursier = await _context.Coursiers.FindAsync(id);
            if (coursier == null)
            {
                return NotFound();
            }

            _context.Coursiers.Remove(coursier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoursierExists(int id)
        {
            return _context.Coursiers.Any(e => e.Id == id);
        }
    }
}
