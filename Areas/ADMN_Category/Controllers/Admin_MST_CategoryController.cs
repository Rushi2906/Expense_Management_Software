using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Expense_Management_Software.Areas.ADMN_Category.Models;
using Expense_Management_Software.DAL.ADMN_Category;

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

        //#region SelectByID

        //public IActionResult Admin_MST_CategoryByID(int CategoryID)
        //{
        //    string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
        //    DataTable dt = new DataTable();
        //    //Console.WriteLine(CommonVariable.UserID);
        //    SqlConnection connection = new SqlConnection(connectionStr);
        //    connection.Open();
        //    SqlCommand objCmd = connection.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "[PR_MST_CATEGORY_SELECTBYID]";
        //    objCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
        //    SqlDataReader objSDR = objCmd.ExecuteReader();
        //    dt.Load(objSDR);
        //    Console.WriteLine(dt.Rows.Count);
        //    return View("Admin_MST_CategoryList", dt);
        //}

        //#endregion

        //#region Admin_MST_CategorySave / Admin_MST_CategoryAdd

        //public IActionResult Admin_MST_CategorySave(Admin_MST_CategoryModel model)
        //{
        //    Console.WriteLine("aaa" + model.CategoryID);
        //    string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
        //    SqlConnection connection = new SqlConnection(connectionStr);
        //    connection.Open();
        //    SqlCommand objCmd = connection.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    if (model.CategoryID == 0)
        //    {
        //        Console.WriteLine(model.CategoryPhoto);
        //        if (model.CategoryPhoto != null)
        //        {
        //            string folder = "images/category/";
        //            folder += Guid.NewGuid().ToString() + "_" + model.CategoryPhoto.FileName;  // Guid.NewGuid().ToString() for making file name unique

        //            model.CategoryImage = "/" + folder;

        //            string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

        //            model.CategoryPhoto.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
        //        }
        //        objCmd.CommandText = "PR_ADMIN_MST_CATEGORY_INSERT";
        //        TempData["SuccessMessage"] = "Data Added Successfully.";
        //    }
        //    else
        //    {
        //        if (model.CategoryPhoto != null)
        //        {
        //            string folder = "images/category/";
        //            folder += Guid.NewGuid().ToString() + "_" + model.CategoryPhoto.FileName;  // Guid.NewGuid().ToString() for making file name unique

        //            model.CategoryImage = "/" + folder;

        //            string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

        //            model.CategoryPhoto.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
        //        }
        //        objCmd.CommandText = "PR_MST_CATEGORY_UPDATEBYPK";
        //        objCmd.Parameters.AddWithValue("@CategoryID", model.CategoryID);
        //        TempData["SuccessMessage"] = "Data Updated Successfully.";
        //    }

        //    objCmd.Parameters.AddWithValue("@CategoryName", model.CategoryName);
        //    objCmd.Parameters.AddWithValue("@CategoryImage", model.CategoryImage);
        //    objCmd.ExecuteNonQuery();
        //    connection.Close();
        //    return RedirectToAction("Admin_MST_CategoryList");
        //}



        //public IActionResult Admin_MST_CategoryAdd(int? CategoryID)
        //{
        //    if (CategoryID != null)
        //    {
        //        string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
        //        SqlConnection connection = new SqlConnection(connectionStr);
        //        connection.Open();
        //        SqlCommand objCmd = connection.CreateCommand();
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        objCmd.CommandText = "PR_MST_CATEGORY_SELECTBYID";
        //        objCmd.Parameters.AddWithValue("@CATEGORYID", CategoryID);
        //        DataTable dt = new DataTable();
        //        SqlDataReader objSDR = objCmd.ExecuteReader();

        //        dt.Load(objSDR);
        //        Admin_MST_CategoryModel model = new Admin_MST_CategoryModel();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            model.CategoryID = Convert.ToInt32(dr["CategoryID"]);
        //            model.CategoryName = (string)dr["CategoryName"];
        //            model.CategoryImage = (string)dr["CategoryImage"];
        //        }
        //        return View("Admin_MST_CategoryAdd", model);
        //    }
        //    else
        //    {
        //        return View("Admin_MST_CategoryAdd");
        //    }
        //}

        //#endregion

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
    }
}
