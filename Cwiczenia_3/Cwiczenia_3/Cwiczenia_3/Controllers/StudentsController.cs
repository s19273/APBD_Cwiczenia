using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia_3.DAL;
using Cwiczenia_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Cwiczenia_3.Controllers
{
    [ApiController]
    [Route("api/students")]

    public class StudentsController : ControllerBase
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s19273;Integrated Security=True";
        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();
            using (var con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;

                com.CommandText = "select FirstName, LastName, BirthDate, Studies.Name, Semester from Student, Studies, Enrollment where Enrollment.IdEnrollment=Student.IdEnrollment and Studies.IdStudy=Enrollment.IdStudy;";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.Study = dr["Name"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    list.Add(st);
                }

            }
            return Ok(list);
        }

        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public string GetStudent(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        }

        [HttpGet("{id}")]

        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Nie znaleziono studenta");
        }

        [HttpPost]

        public IActionResult CreateStudent(Models.Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }


    }
}