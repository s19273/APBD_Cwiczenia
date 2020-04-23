using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Models
{
    public class PrescriptionRequest
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public string DueDate { get; set; }
        [Required]
        public int IdPatient { get; set; }
        [Required]
        public int IdDoctor { get; set; }
    }
}
