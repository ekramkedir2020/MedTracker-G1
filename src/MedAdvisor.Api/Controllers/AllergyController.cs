using Azure.Core;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Reflection.Metadata.Ecma335;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly MedAdvisorDbContext _dbcontext;

        public AllergyController(MedAdvisorDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergy>>> GetAllergys()
        {
            if (_dbcontext.Allergies == null)
            {
                return NotFound();
            }
            return await _dbcontext.Allergies.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Allergy>> GetAllergy(int id)
        {
            if (_dbcontext.Allergies == null)
            {
                return NotFound();
            }

            var allergy = await _dbcontext.Allergies.FindAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }
            return allergy;

        }
        [HttpPost]
        public async Task<ActionResult<Allergy>> PostAllergy(Allergy allergy)
        {
            _dbcontext.Allergies.Add(allergy);
            await _dbcontext.SaveChangesAsync();
            return Ok(allergy);
        }
        [HttpPut]
        public async Task<IActionResult> PutAllergy(int id, Allergy request)

        {
            var allerg = await _dbcontext.Allergies.FindAsync(id);
            if (id != allerg.AllergyId)
            {
                return BadRequest();
            }
            try
            {
                allerg.UserId = request.UserId;
                allerg.AllergyId = request.AllergyId;
                allerg.AllergyName = request.AllergyName;

                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergyAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok();
        }
        private bool AllergyAvailable(int id)
        {
            return (_dbcontext.Allergies?.Any(x => x.AllergyId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergy(int id)
        {
            if (_dbcontext.Allergies == null)
            {
                return NotFound();
            }
            var allergy = await _dbcontext.Allergies.FindAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }
            _dbcontext.Allergies.Remove(allergy);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

    }

}
