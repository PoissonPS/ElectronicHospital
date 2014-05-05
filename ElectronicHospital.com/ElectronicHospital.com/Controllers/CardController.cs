using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using ElectronicHospital.com.Models;

namespace ElectronicHospital.com.Controllers
{
    public class CardController : Controller
    {
        //
        // GET: /Card/
       
      public ActionResult Index()
        {
            var sorttype = string.Empty;
            var type = string.Empty;
            if (String.IsNullOrEmpty(sorttype) == false)
            {
                if (sorttype == "Захворювання")
                {
                    type = "diseas";
                }
                if (sorttype == "Аналізи")
                {
                    type = "analysis";
                }
                if (sorttype == "Рецепти")
                {
                    type = "recipe";
                }
            }
            var model = new UserAndCard();
            var currentUser = new User();
            var user = HttpContext.User.Identity.Name;
            var databasePath = ConfigurationManager.AppSettings["DataBasePath"];
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                const string sql = @"SELECT * FROM [dbo].[System_Patient] " +
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

                    }
                    reader.Close();
                }
            }

            //читаєм болячки)))
            var diseases = new List<CardItem>();
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                var sql = String.IsNullOrEmpty(type)
                    ? @"SELECT * FROM [dbo].[System_DiseaseItems] WHERE [Username] = @u"
                    : @"SELECT * FROM [dbo].[System_DiseaseItems] WHERE [Username] = @u and [Type] like '%" + type + "%' ";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = user;
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var disease = new CardItem();
                        disease.DateFrom = Convert.ToDateTime(reader["DateFrom"]);
                        disease.DateTo = Convert.ToDateTime(reader["DateTo"]);
                        disease.Name = reader["Name"].ToString();
                        disease.Description = reader["Description"].ToString();
                        disease.Type = reader["Type"].ToString();
                        disease.DoctorName = reader["DoctorName"].ToString();
                        diseases.Add(disease);
                    }
                    reader.Close();
                }
            }
            model.User = currentUser;
            model.Items = diseases;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserAndCard model)
        {
            var startDay = "1980-01-01";
            var endDay = "2015-01-01";
            if (String.IsNullOrEmpty(model.From) == false && String.IsNullOrEmpty(model.To)==false)
            {
                startDay = model.From;
                endDay = model.To;
            }

            var type = string.Empty;

            if (String.IsNullOrEmpty(model.Type) == false)
            {
                if (model.Type == "Захворювання")
                {
                    type = "diseas";
                }
                if (model.Type == "Аналіз")
                {
                    type = "analysis";
                }
                if (model.Type == "Рецепт")
                {
                    type = "recipe";
                }
            }
            model = new UserAndCard();
            var currentUser = new User();
            var user = HttpContext.User.Identity.Name;
            var databasePath = ConfigurationManager.AppSettings["DataBasePath"];
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                const string sql = @"SELECT * FROM [dbo].[System_Patient] " +
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

                    }
                    reader.Close();
                }
            }

            //читаєм болячки)))
            var diseases = new List<CardItem>();
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                var sql = String.IsNullOrEmpty(type)
                    ? @"SELECT * FROM [dbo].[System_DiseaseItems] WHERE [Username] = @u"
                    : @"SELECT * FROM [dbo].[System_DiseaseItems] WHERE [Username] = @u and [Type] like '%" + type +
                      "%' and" +
                      "[DateFrom]> '" + startDay + "'  and [DateTo]<'" + endDay + "' ";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = user;
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var disease = new CardItem();
                        disease.DateFrom = Convert.ToDateTime(reader["DateFrom"]);
                        disease.DateTo = Convert.ToDateTime(reader["DateTo"]);
                        disease.Name = reader["Name"].ToString();
                        disease.Description = reader["Description"].ToString();
                        disease.Type = reader["Type"].ToString();
                        disease.DoctorName = reader["DoctorName"].ToString();
                        diseases.Add(disease);
                    }
                    reader.Close();
                }
            }
            model.User = currentUser;
            model.Items = diseases;
            return View(model);
        }



        public ActionResult Details(string user)
        {
            var currentUser = new User();
            var userFind = user;
            var databasePath = ConfigurationManager.AppSettings["DataBasePath"];
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                const string sql = @"SELECT * FROM [dbo].[System_Patient] " +
                                   @"WHERE [Username] = @u ";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = userFind;
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
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

                    }
                    reader.Close();
                }
            }

            //читаєм болячки)))
            var diseases = new List<CardItem>();
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                var sql = @"SELECT * FROM [dbo].[System_DiseaseItems] WHERE [Username] = @u ";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = userFind;
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var disease = new CardItem();
                        disease.DateFrom = Convert.ToDateTime(reader["DateFrom"]);
                        disease.DateTo = Convert.ToDateTime(reader["DateTo"]);
                        disease.Name = reader["Name"].ToString();
                        disease.Description = reader["Description"].ToString();
                        disease.Type = reader["Type"].ToString();
                        disease.DoctorName = reader["DoctorName"].ToString();
                        diseases.Add(disease);
                    }
                    reader.Close();
                }
            }
            var model = new UserAndCard();
            model.User = currentUser;
            model.Items = diseases;
            return View(model);
        }
    }
}
