﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CTMS.Web.Controllers
{
    public class TemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}