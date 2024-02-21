using Expense_Management_Software.Areas.ADMN_Category.Models;
using Expense_Management_Software.Areas.ADMN_PaymentMode.Models;
using Expense_Management_Software.Areas.MST_Transaction.Models;
using Expense_Management_Software.Areas.MST_TransactionType.Models;
using Expense_Management_Software.BAL;
using Expense_Management_Software.DAL.MST_Transfer;
using Expense_Management_Software.DAL.MST_TransferType;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;

namespace Expense_Management_Software.Areas.MST_Transaction.Controllers
{
    [Area("MST_Transaction")]
    [Route("MST_Transaction/[controller]/[action]")]
    public class MST_TransactionController : Controller
    {

        #region Method : Configuration

        private readonly IConfiguration Configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public MST_TransactionController(IConfiguration _Configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = _Configuration;
            _webHostEnvironment = webHostEnvironment;
            
        }

        MST_TransferDAL dal = new MST_TransferDAL();

        #endregion

        #region Method : User_TransactionList

        public IActionResult MST_TransactionList()
        {

            #region Method : Category_Dropdown

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

            #region Method : TransferType_Dropdown

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

            #region Method : PaymentMode_Dropdown

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

        #region Method : User_TransactionSave
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

        #region Method : User_TransactionAdd
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

        #region Method : User_TransactionDelete
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

        #region Method : User_Transaction_Filter

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

        #region Method : User_ExportData_Excel
        public List<MST_TransactionModel> GetTransactionModels()
        {
            List<MST_TransactionModel> studentModels = new List<MST_TransactionModel>();
            string myconnStr = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(myconnStr);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_TRANSFER_SELECTALL";
            cmd.Parameters.AddWithValue("@UserID", CV.UserID());
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    MST_TransactionModel studentModel = new MST_TransactionModel
                    {
                        TransferTypeName = reader["TransferTypeName"].ToString(),
                        TransferAmount = Convert.ToDouble(reader["TransferAmount"]),
                        TransferDate = Convert.ToDateTime(reader["TransferDate"]),
                        TransferNote = reader["TransferNote"].ToString(),
                        CategoryName = reader["CategoryName"].ToString(),
                        PaymentModeType = reader["PaymentModeType"].ToString()
                        // Add other properties as needed
                    };
                    studentModels.Add(studentModel);
                }
                return studentModels;
            }
        }

        public ActionResult ExportToExcel(List<MST_TransactionModel> data)
        {
            
            List<MST_TransactionModel> transactionModel = GetTransactionModels();
            Console.WriteLine(transactionModel.Count);
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("MST_Transaction");

                // Add header row
                worksheet.Cells["A1"].Value = "TransferTypeName";
                worksheet.Cells["B1"].Value = "TransferAmount";
                worksheet.Cells["C1"].Value = "TransferDate";
                worksheet.Cells["D1"].Value = "CategoryName";
                worksheet.Cells["E1"].Value = "PaymentModeType";

                int row = 3;
                // Add data rows
                foreach (var tr in transactionModel)
                {
                    
                    worksheet.Cells[row, 1].Value = tr.TransferTypeName;
                    worksheet.Cells[row, 2].Value = Convert.ToDouble(tr.TransferAmount);
                    worksheet.Cells[row, 3].Value = Convert.ToDateTime(tr.TransferDate);
                    worksheet.Cells[row, 4].Value = tr.CategoryName;
                    worksheet.Cells[row, 5].Value = tr.PaymentModeType;
                    row++;
                }

                fileContents = package.GetAsByteArray();
            }

            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExpenseManager.xlsx");
        }

        #endregion

        #region Method : Multiple Delete

        [HttpPost]
        public IActionResult MultipleDelete(int[] id)
        {
            foreach(var item in id)
            {
                try
                {
                    Admin_MST_TransactionDelete(item);
                    Console.WriteLine("Dleted" + item);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            return RedirectToAction("MST_TransactionList");
        }

        #endregion

    }
}
