/**
using MedAdvisor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAdvisor.Services.Okta.AllergyService
{
    public class AllergyService : IAllergyService
    {
        private static List<Allergy> Allergies = new List<Allergy>
            {
                new Allergy
                {
                    AllergyId=1,
                    AllergyName="some Allergy",
                    UserId=1
                },
                 new Allergy
                {
                    AllergyId=2,
                    AllergyName="another Allergy",
                    UserId=1
                }
        };

        public List<Allergy> AddAllergy(Allergy allergy)
        {
            Allergies.Add(allergy);

            return Allergies;
        }

        public List<Allergy> DeleteAllergy(int id)
        {
            var result = Allergies.Find(x => x.AllergyId ==id);
            if (result == null) {
                return null;
            }
            return Allergies;
            
        }

        public List<Allergy> GetAllAllergies()
        {
            return Allergies;
        }

        public Allergy GetSingleAllergy(int id)
        {
            var allergy = Allergies.Find(x => x.AllergyId == id);
            if (allergy == null)
            {
                return null;
            }
            return allergy;
        }

        public List<Allergy> UpdateAllergy(int id, Allergy request)
        {
            var allerg = Allergies.Find(x => x.AllergyId==id);
            if (allerg is null)
            {
                return null;
            }
            allerg.UserId = request.UserId;
            allerg.AllergyId=request.AllergyId;
            allerg.AllergyName = request.AllergyName;
            return Allergies;
        }
    }
}
*/