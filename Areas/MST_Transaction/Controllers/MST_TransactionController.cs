using Expense_Management_Software.Areas.ADMN_Category.Models;
using Expense_Management_Software.Areas.ADMN_PaymentMode.Models;
using Expense_Management_Software.Areas.MST_Transaction.Models;
using Expense_Management_Software.Areas.MST_TransactionType.Models;
using Expense_Management_Software.BAL;
using Expense_Management_Software.DAL.MST_Transfer;
using Expense_Management_Software.DAL.MST_TransferType;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Expense_Management_Software.Areas.MST_Transaction.Controllers
{
    [Area("MST_Transaction")]
    [Route("MST_Transaction/[controller]/[action]")]
    public class MST_TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Configuration

        private readonly IConfiguration Configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public MST_TransactionController(IConfiguration _Configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = _Configuration;
            _webHostEnvironment = webHostEnvironment;
            
        }

        MST_TransferDAL dal = new MST_TransferDAL();

        #endregion

        #region MST_TransferTypeList

        public IActionResult MST_TransactionList()
        {

            #region Category Dropdown

            DataTable dt = dal.Admin_MST_Transfer_Category_Dropdown();
            List<Admin_MST_CategoryModel> list = new List<Admin_MST_CategoryModel>();

            foreach (DataRow dr in dt.Rows)
            {
                Admin_MST_CategoryModel model = new Admin_MST_CategoryModel();
                model.CategoryID = Convert.ToInt32(dr["CategoryId"]);
                model.CategoryName = dr["CategoryName"].ToString();
                list.Add(model);
            }
            ViewBag.Category = list;

            #endregion

            #region Transfer Type Dropdown

            DataTable dt2 = dal.Admin_MST_Transfer_Type_Dropdown();
            List<MST_TransactionTypeModel> list2 = new List<MST_TransactionTypeModel>();

            foreach (DataRow dr in dt2.Rows)
            {
                MST_TransactionTypeModel model = new MST_TransactionTypeModel();
                model.TransferTypeID = Convert.ToInt32(dr["TransferTypeID"]);
                model.TransferTypeName = dr["TransferTypeName"].ToString();
                list2.Add(model);
            }
            ViewBag.TransferType = list2;

            #endregion

            #region Payment Mode Dropdown

            DataTable dt3 = dal.Admin_MST_Payment_Mode_Dropdown();
            List<Admin_MST_PaymentModeModel> list3 = new List<Admin_MST_PaymentModeModel>();

            foreach (DataRow dr in dt3.Rows)
            {
                Admin_MST_PaymentModeModel model = new Admin_MST_PaymentModeModel();
                model.PaymentModeID = Convert.ToInt32(dr["PaymentModeID"]);
                model.PaymentModeType = dr["PaymentModeType"].ToString();
                list3.Add(model);
            }
            ViewBag.PaymentMode = list3;

            #endregion

            DataTable dt4 = dal.PR_MST_TRANSFER_SELECTALL();
            return View(dt4);
        }

        #endregion

        #region Admin_MST_TransferSave
        public IActionResult Admin_MST_TransactionSave(MST_TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {
                if (dal.Admin_MST_TransferSave(transactionModel))
                {
                    TempData["SuccessMessage"] = "Data Added Successfully.";
                    return RedirectToAction("MST_TransactionList");
                }

            }
            return View("MST_TransactionAdd");
        }
        #endregion

        #region Admin_MST_TransferAdd
        public IActionResult Admin_MST_TransactionAdd(int TransferID)
        {
            MST_TransactionModel admin_MST_TransferModel = dal.Admin_MST_TransferByID(TransferID);

            #region Category Dropdown

            DataTable dt = dal.Admin_MST_Transfer_Category_Dropdown();
            List<Admin_MST_CategoryModel> list = new List<Admin_MST_CategoryModel>();

            foreach(DataRow dr in dt.Rows)
            {
                Admin_MST_CategoryModel model = new Admin_MST_CategoryModel();
                model.CategoryID = Convert.ToInt32(dr["CategoryId"]);
                model.CategoryName = dr["CategoryName"].ToString();
                list.Add(model);
            }
            ViewBag.Category = list;

            #endregion

            #region Transfer Type Dropdown

            DataTable dt2 = dal.Admin_MST_Transfer_Type_Dropdown();
            List<MST_TransactionTypeModel> list2 = new List<MST_TransactionTypeModel>();

            foreach (DataRow dr in dt2.Rows)
            {
                MST_TransactionTypeModel model = new MST_TransactionTypeModel();
                model.TransferTypeID = Convert.ToInt32(dr["TransferTypeID"]);
                model.TransferTypeName = dr["TransferTypeName"].ToString();
                list2.Add(model);
            }
            ViewBag.TransferType = list2;

            #endregion

            #region Payment Mode Dropdown

            DataTable dt3 = dal.Admin_MST_Payment_Mode_Dropdown();
            List<Admin_MST_PaymentModeModel> list3 = new List<Admin_MST_PaymentModeModel>();

            foreach (DataRow dr in dt3.Rows)
            {
                Admin_MST_PaymentModeModel model = new Admin_MST_PaymentModeModel();
                model.PaymentModeID = Convert.ToInt32(dr["PaymentModeID"]);
                model.PaymentModeType = dr["PaymentModeType"].ToString();
                list3.Add(model);
            }
            ViewBag.PaymentMode = list3;

            #endregion

            if (admin_MST_TransferModel != null)
            {
                //ViewBag.CategoryList = dal.CategoryDropDown();
                return View("MST_TransactionAdd", admin_MST_TransferModel);
            }
            else
            {
                //ViewBag.CategoryList = dal.CategoryDropDown();
                return View("MST_TransactionAdd");
            }
        }
        #endregion

        #region Admin_MST_TransactionDelete
        public IActionResult Admin_MST_TransactionDelete(int TransferID)
        {
            Console.WriteLine(TransferID);
            bool isSuccess = dal.PR_MST_TRANSFER_DELETEBYID(TransferID);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Data Deleted Successfully.";
                return RedirectToAction("MST_TransactionList");
            }
            return RedirectToAction("MST_TransactionList");

        }

        #endregion

        #region Filter Transaction

        public IActionResult MST_Transaction_Filter(MST_Transaction_FilterModel filterModel)
        {

            #region Category Dropdown

            DataTable dt = dal.Admin_MST_Transfer_Category_Dropdown();
            List<Admin_MST_CategoryModel> list = new List<Admin_MST_CategoryModel>();

            foreach (DataRow dr in dt.Rows)
            {
                Admin_MST_CategoryModel model = new Admin_MST_CategoryModel();
                model.CategoryID = Convert.ToInt32(dr["CategoryId"]);
                model.CategoryName = dr["CategoryName"].ToString();
                list.Add(model);
            }
            ViewBag.Category = list;

            #endregion

            #region Transfer Type Dropdown

            DataTable dt2 = dal.Admin_MST_Transfer_Type_Dropdown();
            List<MST_TransactionTypeModel> list2 = new List<MST_TransactionTypeModel>();

            foreach (DataRow dr in dt2.Rows)
            {
                MST_TransactionTypeModel model = new MST_TransactionTypeModel();
                model.TransferTypeID = Convert.ToInt32(dr["TransferTypeID"]);
                model.TransferTypeName = dr["TransferTypeName"].ToString();
                list2.Add(model);
            }
            ViewBag.TransferType = list2;

            #endregion

            #region Payment Mode Dropdown

            DataTable dt3 = dal.Admin_MST_Payment_Mode_Dropdown();
            List<Admin_MST_PaymentModeModel> list3 = new List<Admin_MST_PaymentModeModel>();

            foreach (DataRow dr in dt3.Rows)
            {
                Admin_MST_PaymentModeModel model = new Admin_MST_PaymentModeModel();
                model.PaymentModeID = Convert.ToInt32(dr["PaymentModeID"]);
                model.PaymentModeType = dr["PaymentModeType"].ToString();
                list3.Add(model);
            }
            ViewBag.PaymentMode = list3;

            #endregion

            DataTable dt4 = dal.MST_Transfer_Filter(filterModel);
            ModelState.Clear();
            return View("MST_TransactionList", dt4);
        }

        #endregion

    }
}
