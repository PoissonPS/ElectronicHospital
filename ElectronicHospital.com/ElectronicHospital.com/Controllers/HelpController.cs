using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicHospital.com.Models;

namespace ElectronicHospital.com.Controllers
{
    public class HelpController : Controller
    {
        //
        // GET: /Help/

        public ActionResult Index()
        {
          
            return View();
        }

    }
}
