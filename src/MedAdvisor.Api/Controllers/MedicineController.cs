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
    public class MedicineController : ControllerBase
    {
        private readonly MedAdvisorDbContext _dbcontext;

        public MedicineController(MedAdvisorDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicines()
        {
            if (_dbcontext.Medicines == null)
            {
                return NotFound();
            }
            return await _dbcontext.Medicines.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetMedicine(int id)
        {
            if (_dbcontext.Medicines == null)
            {
                return NotFound();
            }

            var medicine = await _dbcontext.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            return medicine;

        }
        [HttpPost]
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {
            _dbcontext.Medicines.Add(medicine);
            await _dbcontext.SaveChangesAsync();
            return Ok(medicine);
        }
        [HttpPut]
        public async Task<IActionResult> Medicine(int id, Medicine request)

        {
            var medicine = await _dbcontext.Medicines.FindAsync(id);
            if (id != medicine.MedicineId)
            {
                return BadRequest();
            }
            try
            {
                medicine.UserId = request.UserId;
                medicine.MedicineId = request.MedicineId;
                medicine.MedicineName = request.MedicineName;

                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineAvailable(id))
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
        private bool MedicineAvailable(int id)
        {
            return (_dbcontext.Medicines?.Any(x => x.MedicineId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            if (_dbcontext.Medicines == null)
            {
                return NotFound();
            }
            var medicine = await _dbcontext.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            _dbcontext.Medicines.Remove(medicine);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

    }

}
