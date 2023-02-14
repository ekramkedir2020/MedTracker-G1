/**using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAdvisor.Models
{
  public class Registration
    {
       public int Id { get; set; }
        [Required]
        public string ?UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public string? IsActive { get; set; }
    }
}
*/