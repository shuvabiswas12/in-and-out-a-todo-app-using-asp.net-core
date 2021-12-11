using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        #region :: hello world ::
        public IActionResult Index()
        {
            return View();
            
        }
        #endregion
    }
}
