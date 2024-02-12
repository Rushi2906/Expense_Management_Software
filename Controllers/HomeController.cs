using Expense_Management_Software.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Expense_Management_Software.BAL;
using NuGet.Protocol;
using System.Diagnostics.Metrics;
using static Expense_Management_Software.Models.PaymentModeModel;

namespace Expense_Management_Software.Controllers
{
    [BAL.CheckAccess]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;


        public HomeController(ILogger<HomeController> logger,IConfiguration _Configuration)
        {
            Configuration = _Configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_Dashboard_Count]";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);
            Console.WriteLine(dt.Rows.Count);
            return View(dt);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index_User()
        {
            string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_Dashboard_Count]";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);

            List<HomeModel> counters = new List<HomeModel>();
            foreach(DataRow row in dt.Rows)
            {
                HomeModel model = new HomeModel();
                model.UserCount = Convert.ToInt32(row["UserCount"]);
                model.CategoryCount = Convert.ToInt32(row["CategoryCount"]);
                model.PaymnetModeCount = Convert.ToInt32(row["PaymentModeCount"]);
                model.Income = Convert.ToDecimal(row["Income"].ToString());
                model.Expense = Convert.ToDecimal(row["Expense"].ToString());
                counters.Add(model);
            }
            connection.Close();

            DataTable dt2 = new DataTable();
            SqlConnection connection2 = new SqlConnection(connectionStr);
            connection2.Open();
            SqlCommand objCmd2 = connection2.CreateCommand();
            objCmd2.CommandType = CommandType.StoredProcedure;
            objCmd2.CommandText = "[PR_DASHBOARD_CATEGORY_FILTER]";
            objCmd2.Parameters.AddWithValue("@UserID", CV.UserID());
            SqlDataReader objSDR2 = objCmd2.ExecuteReader();
            dt2.Load(objSDR2);

            List<CategoryFilterModel> category = new List<CategoryFilterModel>();
            foreach(DataRow row in dt2.Rows)
            {
                CategoryFilterModel model2 = new CategoryFilterModel();
                model2.CategoryName = row["CategoryName"].ToString();
                model2.Category_INCOME = Convert.ToDecimal(row["INCOME"].ToString());
                model2.Category_EXPENSE = Convert.ToDecimal(row["EXPENSE"].ToString());
                category.Add(model2);
            }
            connection2.Close();

            DataTable dt3 = new DataTable();
            SqlConnection connection3 = new SqlConnection(connectionStr);
            connection3.Open();
            SqlCommand objCmd3 = connection3.CreateCommand();
            objCmd3.CommandType = CommandType.StoredProcedure;
            objCmd3.CommandText = "[PR_DASHBOARD_PAYMENTMODE_FILTER]";
            objCmd3.Parameters.AddWithValue("@UserID", CV.UserID());
            SqlDataReader objSDR3 = objCmd3.ExecuteReader();
            dt3.Load(objSDR3);
            

            List<PaymentModeModel> paymentModes = new List<PaymentModeModel>();
            foreach (DataRow row in dt3.Rows)
            {
                PaymentModeModel model3 = new PaymentModeModel();
                model3.PaymentModeName = row["PaymentModeType"].ToString();
                model3.Payment_INCOME = Convert.ToDecimal(row["INCOME"].ToString());
                model3.Payment_EXPENSE = Convert.ToDecimal(row["EXPENSE"].ToString());
                paymentModes.Add(model3);
            }
            connection3.Close();

            var tables = new Demo
            {
                Categories = category,
                Counters = counters,
                PaymentModes = paymentModes
            };

            Console.WriteLine(tables);
            return View(tables);
        }

        public IActionResult Dashboard_Category_Filter()
        {
            string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_DASHBOARD_CATEGORY_FILTER]";
            objCmd.Parameters.AddWithValue("@UserID", CV.UserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);
            Console.WriteLine(dt.Rows.Count);
            return View("Index_User",dt);
        }

    }
}