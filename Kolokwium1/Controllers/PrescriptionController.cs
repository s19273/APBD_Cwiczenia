﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1.Controllers
{
    public class PrescriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}