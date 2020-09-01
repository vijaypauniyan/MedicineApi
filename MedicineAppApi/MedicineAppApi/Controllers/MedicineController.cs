using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using MedicineAppApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicineAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        static List<Medicine> list = new List<Medicine>();
        private List<Medicine> MedicineAll()
        {
            for (int i = 0; i < 10; i++)
            {
                Medicine medicine = new Medicine()
                {
                    Brand = "Brand " + i,
                    ExpiryDate = DateTime.Now.AddDays(i),
                    FullName = "Ankit " + i,
                    Note = "Note " + i,
                    Price = +i * 10,
                    Quantity = i,
                    MedicineId = i
                };
                list.Add(medicine);
            }
            return list;
        }
        //IEnumerable<Medicine> list = new List<Medicine>();
        [HttpGet]
        public List<Medicine> Get()
        {
            return MedicineAll();
        }
        [HttpPut]
        public Medicine UpdateMedicine([FromQuery] int medicineid, [FromBody] Medicine medicine)
        {
            Medicine medicine1 = list.Where(e => e.MedicineId == medicineid).FirstOrDefault();
            if (medicine1 != null)
            {
                list.Remove(medicine1);
                list.Add(medicine);
            }
            return medicine;
        }
        [HttpPost]
        public Medicine AddMedicine([FromBody] Medicine medicine)
        {
            list.Add(medicine);
            return medicine;
        }

        [HttpGet]
        [Route("GetmedicineById")]
        public Medicine GetmedicineById([FromQuery] int medicineid)
        {
            return list.Where(e => e.MedicineId == medicineid).FirstOrDefault();
        }
    }
}
