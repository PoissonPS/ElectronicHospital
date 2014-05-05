using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using ElectronicHospital.com.Models;

namespace ElectronicHospital.com.Controllers
{
    public class DocCardController : Controller
    {
        //
        // GET: /DocCard/

        public ActionResult Index()
        {
            var model = new DoctorAndUsers();
            var currentDoctor = new Doctor();
            var user = HttpContext.User.Identity.Name;
            var databasePath = ConfigurationManager.AppSettings["DataBasePath"];
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                const string sql = @"SELECT * FROM [dbo].[System_Doctor] " +
                                   @"WHERE [Username] = @u ";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = user;
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currentDoctor.UserName = reader["Username"].ToString();
                        currentDoctor.IdentityNumber = reader["IdentityNumber"].ToString();
                        currentDoctor.FirstName = reader["FirstName"].ToString();
                        currentDoctor.LastName = reader["LastName"].ToString();
                        currentDoctor.FathersName = reader["FathersName"].ToString();
                        currentDoctor.Picture = reader["Picture"].ToString();
                        currentDoctor.Oblast = reader["Oblast"].ToString();
                        currentDoctor.City = reader["City"].ToString();

                        currentDoctor.Position = reader["Position"].ToString();
                        currentDoctor.WorkPlace = reader["WorkPlace"].ToString();
                        currentDoctor.Email = reader["Email"].ToString();
                        currentDoctor.Gender = reader["Gender"].ToString();
                        currentDoctor.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                    }
                    reader.Close();
                }
            }
            model.Doctor = currentDoctor;
            model.Users = new List<User>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DoctorAndUsers model)
        {
            var id = string.Empty;
            if (string.IsNullOrEmpty(model.LastName) == false)
            {
                if (model.LastName == "Гаупт")
                {
                    id = "1";
                }
            }
           
            model = new DoctorAndUsers();
            var currentDoctor = new Doctor();
            var user = HttpContext.User.Identity.Name;
            var databasePath = ConfigurationManager.AppSettings["DataBasePath"];
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                const string sql = @"SELECT * FROM [dbo].[System_Doctor] " +
                                   @"WHERE [Username] = @u ";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = user;
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currentDoctor.UserName = reader["Username"].ToString();
                        currentDoctor.IdentityNumber = reader["IdentityNumber"].ToString();
                        currentDoctor.FirstName = reader["FirstName"].ToString();
                        currentDoctor.LastName = reader["LastName"].ToString();
                        currentDoctor.FathersName = reader["FathersName"].ToString();
                        currentDoctor.Picture = reader["Picture"].ToString();
                        currentDoctor.Oblast = reader["Oblast"].ToString();
                        currentDoctor.City = reader["City"].ToString();

                        currentDoctor.Position = reader["Position"].ToString();
                        currentDoctor.WorkPlace = reader["WorkPlace"].ToString();
                        currentDoctor.Email = reader["Email"].ToString();
                        currentDoctor.Gender = reader["Gender"].ToString();
                        currentDoctor.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                    }
                    reader.Close();
                }
            }
            model.Doctor = currentDoctor;
            var users = new List<User>();
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                var sql = @"SELECT * FROM [dbo].[System_Patient] WHERE [Id] = " + id + " ";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var currentUser = new User();
                        currentUser.UserName = reader["Username"].ToString();
                        currentUser.IdentityNumber = reader["IdentityNumber"].ToString();
                        currentUser.FirstName = reader["FirstName"].ToString();
                        currentUser.LastName = reader["LastName"].ToString();
                        currentUser.FathersName = reader["FathersName"].ToString();
                        currentUser.PlaceOfBirth = reader["PlaceOfBirth"].ToString();
                        currentUser.Email = reader["Email"].ToString();
                        currentUser.Picture = reader["Picture"].ToString();
                        currentUser.Oblast = reader["Oblast"].ToString();
                        currentUser.City = reader["City"].ToString();
                        currentUser.Gender = reader["Gender"].ToString();
                        currentUser.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        users.Add(currentUser);
                    }
                    reader.Close();
                }
            }
            model.Users = users;
            return View(model);
        }
    }
}
