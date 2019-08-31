
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CTMS.Entity;
using CTMS.Entity.Enum;
using CTMS.Service.DAL;
using Microsoft.AspNetCore.Mvc;


namespace CTMS.Web.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    public class ServiceController : AdminBaseController
    {
        public IActionResult Error(string msg = "")
        {
            ViewBag.Msg = msg;
            return View();
        }
    }
}
