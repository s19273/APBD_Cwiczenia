using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Services
{
    public interface IPrescriptionDbService

    {
        public IEnumerable<Models.Prescription> GetPrescription(int IdPrescription);
    }
}
