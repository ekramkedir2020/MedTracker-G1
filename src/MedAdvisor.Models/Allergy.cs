
namespace MedAdvisor.Models
{
    public class Allergy
    {
        public int UserId { get; set; }
        public int AllergyId { get; set; }
        public string AllergyName { get; set; } = string.Empty;
    }
}