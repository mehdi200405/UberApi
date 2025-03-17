using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.EntityFramework;
using UberApi.Models.Repository;

namespace UberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursiersController : ControllerBase
    {
        private readonly IDataRepository<Coursier> dataRepository;

        public CoursiersController(IDataRepository<Coursier> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Coursiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coursier>>> GetCoursiers()
        {
            return dataRepository.GetAll();
        }

        // GET: api/Coursiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coursier>> GetCoursier(int id)
        {
            var coursier = dataRepository.GetById(id);

            if (coursier == null)
            {
                return NotFound();
            }

            return coursier;
        }

        // PUT: api/Coursiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCoursier(int id, Coursier coursier)
        //{
        //    if (id != coursier.IdCoursier)
        //    {
        //        return BadRequest();
        //    }



        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CoursierExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //POST: api/Coursiers
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Coursier>> PostCoursier(Coursier coursier)
        //{
        //    _context.Coursiers.Add(coursier);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCoursier", new { id = coursier.IdCoursier }, coursier);
        //}

        //DELETE: api/Coursiers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCoursier(int id)
        //{
        //    var coursier = await _context.Coursiers.FindAsync(id);
        //    if (coursier == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Coursiers.Remove(coursier);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CoursierExists(int id)
        //{
        //    return _context.Coursiers.Any(e => e.IdCoursier == id);
        //}
    }
}
