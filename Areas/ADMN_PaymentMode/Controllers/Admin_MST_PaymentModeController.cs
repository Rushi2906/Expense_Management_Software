using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Expense_Management_Software.Areas.ADMN_Category.Models;
using Expense_Management_Software.Areas.ADMN_PaymentMode.Models;
using Expense_Management_Software.DAL.ADMN_PaymentMode;

namespace Expense_Management_Software.Areas.ADMN_PaymentMode.Controllers
{
    [Area("ADMN_PaymentMode")]
    [Route("ADMN_PaymentMode/[controller]/[action]")]
    public class Admin_MST_PaymentModeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Configuration

        private readonly IConfiguration Configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Admin_MST_PaymentModeController(IConfiguration _Configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = _Configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        ADMN_PaymentMode_DAL dal = new ADMN_PaymentMode_DAL();

        #endregion

        #region Admin_MST_PaymentModeList

        public IActionResult Admin_MST_PaymentModeList()
        {
            DataTable dt = dal.PR_MST_PAYMENTMODE_SELECTALL();
            return View("Admin_MST_PaymentModeList", dt);
        }

        #endregion

        #region Admin_MST_PaymentModeSave
        public IActionResult Admin_MST_PaymentModeSave(Admin_MST_PaymentModeModel admin_MST_PaymentModeModel)
        {
            if (ModelState.IsValid)
            {
                if (dal.Admin_MST_PaymentModeSave(admin_MST_PaymentModeModel))
                {
                    TempData["SuccessMessage"] = "Data Added Successfully.";
                    return RedirectToAction("Admin_MST_PaymentModeList");
                }
                
            }
            return View("Admin_MST_PaymentModeAdd");
        }
        #endregion

        #region Admin_MST_PaymentModeAdd
        public IActionResult Admin_MST_PaymentModeAdd(int PaymentModeID)
        {
            Admin_MST_PaymentModeModel admin_MST_PaymentModeModel = dal.Admin_MST_PaymentModeByID(PaymentModeID);
            if (admin_MST_PaymentModeModel != null)
            {
                //ViewBag.CategoryList = dal.CategoryDropDown();
                return View("Admin_MST_PaymentModeAdd", admin_MST_PaymentModeModel);
            }
            else
            {
                //ViewBag.CategoryList = dal.CategoryDropDown();
                return View("Admin_MST_PaymentModeAdd");
            }
        }
        #endregion

        #region Admin_MST_PaymentModeDelete
        public IActionResult Admin_MST_PaymentModeDelete(int PaymentModeID)
        {
            bool isSuccess = dal.PR_MST_PAYMENTMODE_DELETEBYID(PaymentModeID);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Data Deleted Successfully.";
                return RedirectToAction("Admin_MST_PaymentModeList");
            }
            return RedirectToAction("Admin_MST_PaymentModeList");

        }

        #endregion
    }
}
