﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia_3.Controllers
{
    [ApiController]
    [Route("api/students")]

    public class StudentsController : ControllerBase
    {
        [HttpGet]

        public string GetStudent()
        {
            return "Kowalski, Malewski, Andrzejewski";
        }
    }
}