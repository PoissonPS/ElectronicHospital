using System.Web.Mvc;
using System.Web.Security;

namespace ElectronicHospital.com.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                if (doctor.IsValid(doctor.UserName, doctor.Password))
                {
                    FormsAuthentication.SetAuthCookie(doctor.UserName, doctor.RememberMe);
                    return RedirectToAction("Index", "DocCard");

                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(doctor);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
