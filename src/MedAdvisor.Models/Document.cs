
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models
{
    public enum FileTypes
    {
        Certificate,
        DischargeSummary,
        Insurance,
        Livingwill,
        Passport,
        Prescription,
        TravelDocument,
        Xray,
        Other
    }
    public class Document
    {
        public int UserId { get; set; }
        public int DocumentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public FileTypes FileTypes { get; set; }
       
        public string Description { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? file { get; set; } 
    }
}
