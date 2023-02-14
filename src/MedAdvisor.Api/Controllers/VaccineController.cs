using Azure.Core;
using MedAdvisor.DataAccess.Mysql;
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
    public class VaccineController : ControllerBase
    {
        private readonly MedAdvisorDbContext _dbcontext;

        public VaccineController(MedAdvisorDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccine>>> GetVaccines()
        {
            if (_dbcontext.Vaccines == null)
            {
                return NotFound();
            }
            return await _dbcontext.Vaccines.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccine>> GetVaccine(int id)
        {
            if (_dbcontext.Vaccines == null)
            {
                return NotFound();
            }

            var vaccine = await _dbcontext.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return vaccine;

        }
        [HttpPost]
        public async Task<ActionResult<Vaccine>> PostVaccine(Vaccine vaccine)
        {
            _dbcontext.Vaccines.Add(vaccine);
            await _dbcontext.SaveChangesAsync();
            return Ok(vaccine);
        }
        [HttpPut]
        public async Task<IActionResult> Vaccine(int id, Vaccine request)

        {
            var vaccine = await _dbcontext.Vaccines.FindAsync(id);
            if (id != vaccine.VaccineId)
            {
                return BadRequest();
            }
            try
            {
                vaccine.UserId = request.UserId;
                vaccine.VaccineId = request.VaccineId;
                vaccine.VaccineName = request.VaccineName;

                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineAvailable(id))
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
        private bool VaccineAvailable(int id)
        {
            return (_dbcontext.Vaccines?.Any(x => x.VaccineId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            if (_dbcontext.Vaccines == null)
            {
                return NotFound();
            }
            var vaccine = await _dbcontext.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            _dbcontext.Vaccines.Remove(vaccine);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

    }

}
