/**using System;
using MedAdvisor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedAdvisor.Services.Okta.AllergyService
{
 public  interface IAllergyService
    {
        List<Allergy>? GetAllAllergies();
        Allergy ? GetSingleAllergy(int id);
        List<Allergy> AddAllergy(Allergy allergy);
        List<Allergy> ? UpdateAllergy(int id , Allergy request);
        List<Allergy> ?  DeleteAllergy(int id);
    
    }


}
*/