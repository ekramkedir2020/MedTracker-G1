/**using System;
using MedAdvisor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedAdvisor.DataAccess.Mysql;

namespace MedAdvisor.Services.Okta.MedicineService
{
    public interface IMedicineService
    {
        List<Medicine>? GetAllMedicines();
        Medicine? GetSingleMedicine(int id);
        List<Medicine> AddMedicine(Medicine medicine);
        List<Medicine>? UpdateMedicine(int id, Medicine request);
        List<Medicine>? DeleteMedicine(int id);

    }


}
*/