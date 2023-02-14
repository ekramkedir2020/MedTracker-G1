/**
using MedAdvisor.DataAccess.Mysql;
using MedAdvisor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAdvisor.Services.Okta.MedicineService
{
    public class MedicineService : IMedicineService
    {
        private static List<Medicine> Medicines = new List<Medicine>
            {
                new Medicine
                {
                    MedicineId=1,
                    MedicineName="some Medicine",
                    UserId=1
                },
                 new Medicine
                {
                    MedicineId=2,
                    MedicineName="some Medicine",
                    UserId=1
                },
        };

        public List<Medicine> AddMedicine(Medicine medicine)
        {
            Medicines.Add(medicine);

            return Medicines;
        }

        public List<Medicine> DeleteMedicine(int id)
        {
            var result = Medicines.Find(x => x.MedicineId == id);
            if (result == null)
            {
                return null;
            }
            return Medicines;

        }

        public List<Medicine>? GetAllMedicines()
        {
            throw new NotImplementedException();
        }

        public List<Medicine> GetAllMedinices()
        {
            return Medicines;
        }

        public Medicine GetSingleMedicine(int id)
        {
            var medicine = Medicines.Find(x => x.MedicineId == id);
            if (medicine == null)
            {
                return null;
            }
            return medicine;
        }

        public List<Medicine> UpdateMedicine(int id, Medicine request)
        {
            var medicine = Medicines.Find(x => x.MedicineId == id);
            if (medicine is null)
            {
                return null;
            }
            medicine.UserId = request.UserId;
            medicine.MedicineId = request.MedicineId;
            medicine.MedicineName = request.MedicineName;
            return Medicines;
        }
    }
}
*/