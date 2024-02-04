using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Expense_Management_Software.Areas.ADMN_Category.Models;
using Expense_Management_Software.DAL.ADMN_Category;
using Expense_Management_Software.BAL;

namespace Expense_Management_Software.Areas.ADMN_Category.Controllers
{
    [Area("ADMN_Category")]
    [Route("ADMN_Category/[controller]/[action]")]
    public class Admin_MST_CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Configuration

        private readonly IConfiguration Configuration;

        public Admin_MST_CategoryController(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        ADMN_Category_DAL dal = new ADMN_Category_DAL();

        #endregion

        #region Admin_MST_CategoryList

        public IActionResult Admin_MST_CategoryList()
        {
            DataTable dt = dal.PR_MST_CATEGORY_SELECTALL();
            return View(dt);
        }

        #endregion

        #region PR_MST_CATEGORY_DELETEBYID

        public IActionResult PR_MST_CATEGORY_DELETEBYID(int CategoryID)
        {
            bool isSuccess = dal.PR_MST_CATEGORY_DELETEBYID(CategoryID);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Data Deleted Successfully.";
                return RedirectToAction("Admin_MST_CategoryList");
            }
            return RedirectToAction("Admin_MST_CategoryList");
        }

        #endregion

        #region Admin_MST_CategorySave
        public IActionResult Admin_MST_CategorySave(Admin_MST_CategoryModel admin_MST_CategoryModel)
        {
            if (ModelState.IsValid)
            {
                if (dal.Admin_MST_CatgeorySave(admin_MST_CategoryModel))
                {
                    TempData["SuccessMessage"] = "Data Added Successfully.";
                    return RedirectToAction("Admin_MST_CategoryList");

                }
            }
            return View("Admin_MST_CategoryAdd");
        }
        #endregion

        #region Admin_MST_CategoryAdd
        public IActionResult Admin_MST_CategoryAdd(int CategoryID)
        {
            Admin_MST_CategoryModel admin_MST_CategoryModel = dal.Admin_MST_CatgeoryByID(CategoryID);
            if (admin_MST_CategoryModel != null)
            {
                //ViewBag.CategoryList = dal.CategoryDropDown();
                return View("Admin_MST_CategoryAdd", admin_MST_CategoryModel);
            }
            else
            {
                //ViewBag.CategoryList = dal.CategoryDropDown();
                return View("Admin_MST_CategoryAdd");
            }
        }
        #endregion

        public IActionResult CategoryFilter()
        {
            return View("Category_Filter");
        }

        [HttpPost]
        public IActionResult MST_CategoryFilter(MST_CategoryFilterModel model)
        {
            string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
            DataTable dt4 = new DataTable();
            SqlConnection connection4 = new SqlConnection(connectionStr);
            connection4.Open();
            SqlCommand objCmd4 = connection4.CreateCommand();
            objCmd4.CommandType = CommandType.StoredProcedure;
            objCmd4.CommandText = "[PR_DASHBOARD_CATEGORY_FILTER_RANGEDATE]";
            objCmd4.Parameters.AddWithValue("@UserID", CV.UserID());
            objCmd4.Parameters.AddWithValue("@FROMDATE", model.FROMDATE);
            objCmd4.Parameters.AddWithValue("@TODATE", model.TODATE);
            SqlDataReader objSDR4 = objCmd4.ExecuteReader();
            dt4.Load(objSDR4);
            Console.WriteLine("Count"+dt4.Rows.Count);
            return View("Category_Filter",dt4);
        }
    }
}
