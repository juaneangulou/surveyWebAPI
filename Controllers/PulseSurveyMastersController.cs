using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealTimePoll.Models;

namespace RealTimePoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PulseSurveyMastersController : ControllerBase
    {
        private readonly POLLBDContext _context;

        public PulseSurveyMastersController(POLLBDContext context)
        {
            _context = context;
        }

        // GET: api/PulseSurveyMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PulseSurveyMaster>>> GetPulseSurveyMaster()
        {
            return await _context.PulseSurveyMaster.ToListAsync();
        }

        // GET: api/PulseSurveyMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PulseSurveyMaster>> GetPulseSurveyMaster(Guid id)
        {
            var pulseSurveyMaster = await _context.PulseSurveyMaster.FindAsync(id);

            if (pulseSurveyMaster == null)
            {
                return NotFound();
            }

            return pulseSurveyMaster;
        }

        // PUT: api/PulseSurveyMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPulseSurveyMaster(Guid id, PulseSurveyMaster pulseSurveyMaster)
        {
            if (id != pulseSurveyMaster.PulseSurveyMasterId)
            {
                return BadRequest();
            }

            _context.Entry(pulseSurveyMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PulseSurveyMasterExists(id))
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

        // POST: api/PulseSurveyMasters
        [HttpPost]
        public async Task<ActionResult<PulseSurveyMaster>> PostPulseSurveyMaster(PulseSurveyMaster pulseSurveyMaster)
        {
            _context.PulseSurveyMaster.Add(pulseSurveyMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PulseSurveyMasterExists(pulseSurveyMaster.PulseSurveyMasterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPulseSurveyMaster", new { id = pulseSurveyMaster.PulseSurveyMasterId }, pulseSurveyMaster);
        }

        // DELETE: api/PulseSurveyMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PulseSurveyMaster>> DeletePulseSurveyMaster(Guid id)
        {
            var pulseSurveyMaster = await _context.PulseSurveyMaster.FindAsync(id);
            if (pulseSurveyMaster == null)
            {
                return NotFound();
            }

            _context.PulseSurveyMaster.Remove(pulseSurveyMaster);
            await _context.SaveChangesAsync();

            return pulseSurveyMaster;
        }

        private bool PulseSurveyMasterExists(Guid id)
        {
            return _context.PulseSurveyMaster.Any(e => e.PulseSurveyMasterId == id);
        }
    }
}
