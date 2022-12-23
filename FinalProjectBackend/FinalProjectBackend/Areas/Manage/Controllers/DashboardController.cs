﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("index", "product");
        }
    }
}
