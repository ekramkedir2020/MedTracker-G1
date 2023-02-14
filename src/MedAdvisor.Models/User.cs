
using System.ComponentModel.DataAnnotations;

namespace MedAdvisor.DataAccess.Mysql
{
    public enum Gender
    {
        Male, Female
    }
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]

        public string SecondName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Gender Gender { get; set; }
        public string BirthDate { get; set; } = string.Empty;
        public bool OrganDonor { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string Nationality { get; set; } = string.Empty;
        [Phone]
        public int Telephone { get; set; }
        public string PostalAddress { get; set; } = string.Empty;
        public string TravelInsurance { get; set; } = string.Empty;
        public int PostalNumber { get; set; }
        public string AlarmTelephone { get; set; } = string.Empty;
        public int EmergencyContacts { get; set; }
        public string OtherInformation { get; set; } = string.Empty;

    }
}