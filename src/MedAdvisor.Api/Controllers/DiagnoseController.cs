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
    public class DiagnoseController : ControllerBase
    {
        private readonly MedAdvisorDbContext _dbcontext;

        public DiagnoseController(MedAdvisorDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Diagnose>>> GetDiagnoses()
        {
            if (_dbcontext.Diagnoses == null)
            {
                return NotFound();
            }
            return await _dbcontext.Diagnoses.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Diagnose>> GetDiagnose(int id)
        {
            if (_dbcontext.Diagnoses == null)
            {
                return NotFound();
            }

            var diagnose = await _dbcontext.Diagnoses.FindAsync(id);
            if (diagnose == null)
            {
                return NotFound();
            }
            return diagnose;

        }
        [HttpPost]
        public async Task<ActionResult<Diagnose>> PostDiagnose(Diagnose diagnose)
        {
            _dbcontext.Diagnoses.Add(diagnose);
            await _dbcontext.SaveChangesAsync();
            return Ok(diagnose);
        }
        [HttpPut]
        public async Task<IActionResult> Diagnose(int id, Diagnose request)

        {
            var diagnose = await _dbcontext.Diagnoses.FindAsync(id);
            if (id != diagnose.DiagnoseId)
            {
                return BadRequest();
            }
            try
            {
                diagnose.UserId = request.UserId;
                diagnose.DiagnoseId = request.DiagnoseId;
                diagnose.DiagnoseName = request.DiagnoseName;

                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnoseAvailable(id))
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
        private bool DiagnoseAvailable(int id)
        {
            return (_dbcontext.Diagnoses?.Any(x => x.DiagnoseId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnose(int id)
        {
            if (_dbcontext.Diagnoses == null)
            {
                return NotFound();
            }
            var diagnose = await _dbcontext.Diagnoses.FindAsync(id);
            if (diagnose == null)
            {
                return NotFound();
            }
            _dbcontext.Diagnoses.Remove(diagnose);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

    }

}
