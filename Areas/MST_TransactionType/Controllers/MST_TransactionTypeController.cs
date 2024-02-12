using Expense_Management_Software.Areas.ADMN_PaymentMode.Models;
using Expense_Management_Software.Areas.MST_TransactionType.Models;
using Expense_Management_Software.DAL.ADMN_PaymentMode;
using Expense_Management_Software.DAL.MST_TransferType;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Expense_Management_Software.Areas.MST_TransactionType.Controllers
{
    [Area("MST_TransactionType")]
    [Route("MST_TransactionType/[controller]/[action]")]
    public class MST_TransactionTypeController : Controller
    {

        #region Method : Configuration

        private readonly IConfiguration Configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MST_TransactionTypeController(IConfiguration _Configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = _Configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        MST_TransferType_DAL dal = new MST_TransferType_DAL();


        #endregion

        #region Method : Admin_TransactionTypeList

        public IActionResult MST_TransactionTypeList()
        {
            DataTable dt = dal.PR_MST_TRANSFERTYPE_SELECTALL();
            return View(dt);
        }

        #endregion

        #region Method : Admin_TransactionTypeSave
        public IActionResult Admin_MST_TransactionTypeSave(MST_TransactionTypeModel transactionTypeModel)
        {
            if (ModelState.IsValid)
            {
                if (dal.Admin_MST_TransferTypeSave(transactionTypeModel))
                {
                    TempData["SuccessMessage"] = "Data Added Successfully.";
                    return RedirectToAction("MST_TransactionTypeList");
                }

            }
            return View("MST_TransactionTypeAdd");
        }
        #endregion

        #region Method : Admin_TransactionTypeAdd
        public IActionResult Admin_MST_TransactionTypeAdd(int TransferTypeID)
        {
            MST_TransactionTypeModel admin_MST_TransferTypeModel = dal.Admin_MST_TransferTypeByID(TransferTypeID);
            if (admin_MST_TransferTypeModel != null)
            {
                //ViewBag.CategoryList = dal.CategoryDropDown();
                return View("MST_TransactionTypeAdd", admin_MST_TransferTypeModel);
            }
            else
            {
                //ViewBag.CategoryList = dal.CategoryDropDown();
                return View("MST_TransactionTypeAdd");
            }
        }
        #endregion

        #region Method : Admin_TransactionTypeDelete
        public IActionResult Admin_MST_TransferTypeDelete(int TransferTypeID)
        {
            Console.WriteLine(TransferTypeID);
            bool isSuccess = dal.PR_MST_TRANSFERTYPE_DELETEBYID(TransferTypeID);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Data Deleted Successfully.";
                return RedirectToAction("MST_TransactionTypeList");
            }
            return RedirectToAction("MST_TransactionTypeList");

        }

        #endregion
    }
}
