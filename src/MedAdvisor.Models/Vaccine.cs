
namespace MedAdvisor.DataAccess.Mysql
{
    public class Vaccine
    {
        public int UserId { get; set; }
        public int VaccineId { get; set; }
        public string VaccineName { get; set; } = string.Empty;
    }
}