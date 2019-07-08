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
    public class PulseSurveyDetailsController : ControllerBase
    {
        private readonly POLLBDContext _context;

        public PulseSurveyDetailsController(POLLBDContext context)
        {
            _context = context;
        }

        // GET: api/PulseSurveyDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PulseSurveyDetail>>> GetPulseSurveyDetail()
        {
            return await _context.PulseSurveyDetail.ToListAsync();
        }

        // GET: api/PulseSurveyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PulseSurveyDetail>> GetPulseSurveyDetail(Guid id)
        {
            var pulseSurveyDetail = await _context.PulseSurveyDetail.FindAsync(id);

            if (pulseSurveyDetail == null)
            {
                return NotFound();
            }

            return pulseSurveyDetail;
        }

        // PUT: api/PulseSurveyDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPulseSurveyDetail(Guid id, PulseSurveyDetail pulseSurveyDetail)
        {
            if (id != pulseSurveyDetail.PulseSurveyDetail1)
            {
                return BadRequest();
            }

            _context.Entry(pulseSurveyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PulseSurveyDetailExists(id))
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

        // POST: api/PulseSurveyDetails
        [HttpPost]
        public async Task<ActionResult<PulseSurveyDetail>> PostPulseSurveyDetail(PulseSurveyDetail pulseSurveyDetail)
        {
            _context.PulseSurveyDetail.Add(pulseSurveyDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PulseSurveyDetailExists(pulseSurveyDetail.PulseSurveyDetail1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPulseSurveyDetail", new { id = pulseSurveyDetail.PulseSurveyDetail1 }, pulseSurveyDetail);
        }

        // DELETE: api/PulseSurveyDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PulseSurveyDetail>> DeletePulseSurveyDetail(Guid id)
        {
            var pulseSurveyDetail = await _context.PulseSurveyDetail.FindAsync(id);
            if (pulseSurveyDetail == null)
            {
                return NotFound();
            }

            _context.PulseSurveyDetail.Remove(pulseSurveyDetail);
            await _context.SaveChangesAsync();

            return pulseSurveyDetail;
        }

        private bool PulseSurveyDetailExists(Guid id)
        {
            return _context.PulseSurveyDetail.Any(e => e.PulseSurveyDetail1 == id);
        }
    }
}
