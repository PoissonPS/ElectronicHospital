using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ElectronicHospital.com.Models
{
    public class Doctor
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Логін")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Запам'ятати мене на цьому комп'ютері")]
        public bool RememberMe { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Oblast { get; set; }
        public string City { get; set; }
        public string WorkPlace { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        

        public bool IsValid(string username, string password)
        {
            var databasePath = ConfigurationManager.AppSettings["DataBasePath"];
            using (var cn = new SqlConnection(@"Server=0e3094be-f645-446a-bdab-a32200ed29fb.sqlserver.sequelizer.com;Database=db0e3094bef645446abdaba32200ed29fb;User ID=iczhmqpltsejtils;Password=UTtLp4BsaLsaHgMjRwmj2GWpiS6QUC4dY8nYdreyLKqZtKZMebNwgpYn5dBD7TFD;"))
            {
                const string sql = @"SELECT [Username] FROM [dbo].[System_Doctor] " +
                                    @"WHERE [Username] = @u AND [Password] = @p";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = username;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = Helpers.SHA1.Encode(password); // password;//
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                reader.Dispose();
                cmd.Dispose();
                return false;
            }
        }
    }
}