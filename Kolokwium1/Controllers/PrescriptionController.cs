using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium1.Models;
using Kolokwium1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1.Controllers
{
    [ApiController]
    [Route("api/prescriptions")]
    public class PrescriptionController : Controller
    {

        public const string ConString = "Data Source=db-mssql;Initial Catalog=s19273;Integrated Security=True";
        [HttpGet("{IdPrescription}")]
        public IActionResult GetPrescription(int IdPrescription)
        {
            using (SqlConnection connect = new SqlConnection(ConString))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect;
                command.CommandText = "select IdPrescription, Date, DueDate, IdPatient, IdDoctor from Prescription where IdPrescription=@IdPrescription";
                command.Parameters.AddWithValue("IdPrescription", IdPrescription);
                var request = new PrescriptionRequest();
                connect.Open();

            }
            return BadRequest("Error");
        }

        private readonly IPrescriptionDbService _dbService;

        public PrescriptionController(IPrescriptionDbService dbService)
        {
            this._dbService = dbService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}