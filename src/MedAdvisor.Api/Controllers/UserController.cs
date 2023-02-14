using MedAdvisor.DataAccess.Mysql;
using MedAdvisor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MedAdvisorDbContext _dbcontext;

        public UserController(MedAdvisorDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetPersonalInfo()
        {
            if (_dbcontext.Users == null)
            {
                return NotFound();
            }
            return await _dbcontext.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetPersonalInfo(int id)
        {
            if (_dbcontext.Users == null)
            {
                return NotFound();
            }

            var user = await _dbcontext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;

        }
        [HttpPost]
        public async Task<ActionResult<User>> PostPersonalInfo(User user)
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> PutPersonalInfo(int id, User request)

        {
            var user = await _dbcontext.Users.FindAsync(id);
            if (id != user.UserId)
            {
                return BadRequest();
            }
            try
            {
                user.UserId = request.UserId;
                user.FirstName = request.FirstName;
                user.SecondName = request.SecondName;
                user.Gender = request.Gender;
                user.BirthDate = request.BirthDate;
                user.OrganDonor = request.OrganDonor;
                user.SocialSecurityNumber = request.SocialSecurityNumber;
                user.Nationality = request.Nationality;
                user.Telephone = request.Telephone;
                user.PostalAddress = request.PostalAddress;
                user.TravelInsurance = request.TravelInsurance;
                user.PostalNumber = request.PostalNumber;
                user.AlarmTelephone = request.AlarmTelephone;
                user.EmergencyContacts = request.EmergencyContacts;
                user.OtherInformation= request.OtherInformation;
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoAvailable(id))
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
        private bool PersonalInfoAvailable(int id)
        {
            return (_dbcontext.Users?.Any(x => x.UserId == id)).GetValueOrDefault();
        }
    }
}
