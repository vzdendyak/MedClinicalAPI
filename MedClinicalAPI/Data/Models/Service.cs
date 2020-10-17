using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinicalAPI.Data.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int DepartamentId { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }
}
