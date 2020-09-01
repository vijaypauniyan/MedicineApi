using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAppApi.Model
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string FullName { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
    }
}
