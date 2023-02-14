using MedAdvisor.DataAccess.Mysql;
using MedAdvisor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly MedAdvisorDbContext _dbcontext;

        public DocumentController(MedAdvisorDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        [Route("UploadFile")]
        public async Task<ActionResult<Document>> UploadFile([FromForm] Document document)
        {
            Response response = new Response();
            try
            {
                string path = Path.Combine("C:\\Users\\helen\\OneDrive\\Desktop\\New\\Working\\-MedTracker-G1\\src\\MedAdvisor.Api\\Images", document.Title);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    document.file.CopyTo(stream);
                }

                _dbcontext.Documents.Add(document);
                await _dbcontext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(document);
        }
    }
}
