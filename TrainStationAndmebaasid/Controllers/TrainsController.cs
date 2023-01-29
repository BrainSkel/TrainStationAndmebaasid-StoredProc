using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationAndmebaasid.Data;
using TrainStationAndmebaasid.Models;

namespace TrainStationAndmebaasid.Controllers
{
    public class TrainsController : Controller
    {
        public TrainStationAndmebaasidContext _context;
        public IConfiguration _config { get; }

        public TrainsController
            (
            TrainStationAndmebaasidContext context,
            IConfiguration config
            )
        {
            _context = context;
            _config = config;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<Train> SearchResult()
        {
            var result = _context.Train
                .FromSqlRaw<Train>("dbo.spSearchTrain")
                .ToList();

            return result;
        }

        [HttpGet]
        public IActionResult DynamicSQL()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrain";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Name = sdr["Name"].ToString();
                    details.Speed = 69;
                    details.Seats = 2000;
                    model.Add(details);
                }
                return View(model);
            }
        }

        /// <summary>
        /// SearchPageWithoutDynamicSQL
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DynamicSQL(string Name, string Speed, string Seats)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrain";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (Name != null)
                {
                    SqlParameter param_fn = new SqlParameter("@Name", Name);
                    cmd.Parameters.Add(param_fn);
                }
                if (Speed != null)
                {
                    SqlParameter param_ln = new SqlParameter("@Speed", Speed);
                    cmd.Parameters.Add(param_ln);
                }
                if (Seats != null)
                {
                    SqlParameter param_g = new SqlParameter("@Distance", Seats);
                    cmd.Parameters.Add(param_g);
                }

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Name = sdr["Name"].ToString();
                    details.Speed = 69;
                    details.Seats = 2000;
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SearchWithDynamics()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrain";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Name = sdr["Name"].ToString();
                    details.Speed = 69;
                    details.Seats = 2000;
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SearchWithDynamics(string Name, string Altitude, string Distance, int Model)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrain";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                StringBuilder stringBuilder = new StringBuilder("Select * from Employees where 1 = 1");

                if (Name != null)
                {
                    stringBuilder.Append(" AND Name=@Name");
                    SqlParameter param_fn = new SqlParameter("@Name", Name);
                    cmd.Parameters.Add(param_fn);
                }
                if (Altitude != null)
                {
                    stringBuilder.Append(" AND Altitude=@Altitude");
                    SqlParameter param_ln = new SqlParameter("@Altitude", Altitude);
                    cmd.Parameters.Add(param_ln);
                }
                if (Distance != null)
                {
                    stringBuilder.Append(" AND Distance=@Distance");
                    SqlParameter param_g = new SqlParameter("@Distance", Distance);
                    cmd.Parameters.Add(param_g);
                }
                if (Model != 0)
                {
                    stringBuilder.Append(" AND Model=@Model");
                    SqlParameter param_s = new SqlParameter("@Model", Model);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Name = sdr["Name"].ToString();
                    details.Speed = 69;
                    details.Seats = 2000;
                    model.Add(details);
                }
                return View(model);
            }
        }


        /// <summary>
        /// DynamicSQLInStoredProcedure
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DynamicSQLInStoredProcedure()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrainGoodDynamicSQL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Name = sdr["Name"].ToString();
                    details.Speed = 69;
                    details.Seats = 2000;
                    model.Add(details);
                }
                return View(model);
            }
        }


        /// <summary>
        /// DynamicSQLInStoredProcedure
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DynamicSQLInStoredProcedure(string Name, string Altitude, string Distance, int Model)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrainsGoodDynamicSQL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (Name != null)
                {
                    SqlParameter param = new SqlParameter("@Name", Name);
                    cmd.Parameters.Add(param);
                }
                if (Altitude != null)
                {
                    SqlParameter param = new SqlParameter("@Altitude", Altitude);
                    cmd.Parameters.Add(param);
                }
                if (Distance != null)
                {
                    SqlParameter param = new SqlParameter("@Distance", Distance);
                    cmd.Parameters.Add(param);
                }
                if (Model != 0)
                {
                    SqlParameter param = new SqlParameter("@Model", Model);
                    cmd.Parameters.Add(param);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Name = sdr["Name"].ToString();
                    details.Speed = 69;
                    details.Seats = 2000;
                    model.Add(details);
                }
                return View(model);
            }
        }
    }
}
