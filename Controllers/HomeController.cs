using Expense_Management_Software.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Expense_Management_Software.BAL;
using System.Globalization;

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

            CultureInfo indianCulture = new CultureInfo("en-IN");

            string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_USER_DASHBOARDCOUNT]";
            objCmd.Parameters.AddWithValue("@UserID", CV.UserID());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);
            Console.WriteLine(dt.Rows.Count);
            
            List<UserDashboardCount> counters = new List<UserDashboardCount>();
            foreach(DataRow row in dt.Rows)
            {
                UserDashboardCount model = new UserDashboardCount();
                Console.WriteLine("income"+row["Income"]);
                Console.WriteLine("income2"+row["Income"].ToString());
                if (row["Income"].ToString() == "")
                {
                    model.Income = "0";
                }
                else
                {
                    model.Income = row["Income"].ToString();
                }
                if (row["Expense"].ToString() == "")
                {
                    model.Expense = "0";
                }
                else
                {
                    model.Expense = row["Expense"].ToString();
                }
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
                model2.Category_INCOME = row["INCOME"].ToString();
                model2.Category_EXPENSE = row["EXPENSE"].ToString();
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
                model3.Payment_INCOME = row["INCOME"].ToString();
                model3.Payment_EXPENSE = row["EXPENSE"].ToString();
                paymentModes.Add(model3);
            }
            connection3.Close();

            var tables = new Demo
            {
                Categories = category,
                UserCounters = counters,
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