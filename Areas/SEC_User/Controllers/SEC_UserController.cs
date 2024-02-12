using Expense_Management_Software.Areas.ADMN_Category.Models;
using Expense_Management_Software.Areas.SEC_User.Models;
using Expense_Management_Software.BAL;
using Expense_Management_Software.DAL.SEC_DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Expense_Management_Software.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[controller]/[action]")]
    public class SEC_UserController : Controller
    {

        #region Method : Configuration

        private readonly IConfiguration Configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SEC_UserController(IConfiguration _Configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = _Configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        #endregion

        #region Method : Login

        public IActionResult SEC_UserLogin()
        {
            return View();
        }

        public IActionResult User_Login(SEC_UserModel userLoginModel)
        {
            string ErrorMsg = string.Empty;
            if (string.IsNullOrEmpty(userLoginModel.UserName))
            {
                ErrorMsg += "User Name is Required";
            }
            if (string.IsNullOrEmpty(userLoginModel.Password))
            {
                ErrorMsg += "<br/>Password is Required";
            }
            if (ErrorMsg != string.Empty)
            {
                TempData["Error"] = ErrorMsg;
                return RedirectToAction("SEC_UserLogin", userLoginModel);
            }

            if (ModelState.IsValid)
            {

                SEC_DALBase dal = new SEC_DALBase(_webHostEnvironment);

                DataTable dtLogin = dal.PR_MST_USER_SELECTBYNAMEPASSWORD(userLoginModel.UserName, userLoginModel.Password);

                if (dtLogin.Rows.Count == 0)
                {
                    TempData["Error"] = "Invalid Username or Password";
                    return RedirectToAction("SEC_UserLogin", "SEC_User");
                }
                else
                {
                    //dtLogin.Load(objSDR);
                    if (dtLogin.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtLogin.Rows)
                        {
                            HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                            HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                            HttpContext.Session.SetString("Email", dr["Email"].ToString());
                            HttpContext.Session.SetString("Password", dr["Password"].ToString());
                            HttpContext.Session.SetString("FirstName", dr["FirstName"].ToString());
                            HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
                            HttpContext.Session.SetString("ProfilePicture", dr["ProfilePicture"].ToString());
                            HttpContext.Session.SetString("IsAdmin", dr["IsAdmin"].ToString());
                            HttpContext.Session.SetString("Created", Convert.ToDateTime(dr["Created"]).ToString("MMMM/yyyy"));
                            HttpContext.Session.SetString("Modified", dr["Modified"].ToString());
                            break;
                        }

                    }
                    //else
                    //{

                    //    TempData["Error"] = ErrorMsg;
                    //    return RedirectToAction("Login_Page", "SEC_User");
                    //}
                    if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                    {
                        Console.WriteLine("Login Success");
                        Console.WriteLine(dtLogin.Rows[0]["IsAdmin"].ToString());

                        if (dtLogin.Rows[0]["IsAdmin"].ToString()=="True")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Index_User", "Home");
                        }
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Method : Logout

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SEC_User_Dashboard", "SEC_User");
        }

        #endregion

        #region Method : Register

        public IActionResult SEC_UserRegister()
        {
            return View();
        }

        public IActionResult Register(SEC_UserModel userModel)
        {
            SEC_DALBase dal = new SEC_DALBase(_webHostEnvironment);
            bool IsSuccess = dal.PR_MST_USER_INSERT(userModel);
            Console.WriteLine(IsSuccess);
            if (IsSuccess)
            {
                return RedirectToAction("SEC_UserLogin");
            }
            else
            {
                return RedirectToAction("SEC_UserRegister");
            }
        }
        #endregion

        #region Method : Admin_UserSelectAll

        public IActionResult SEC_User_SelectAll()
        {
            SEC_DAL dal = new SEC_DAL(_webHostEnvironment);
            DataTable dt = dal.PR_MST_USER_SELECTALL();
            return View(dt);
        }

        #endregion

        #region Method : Admin_UserDelete
        public IActionResult SEC_User_DeleteByID(int UserID)
        {
            SEC_DAL dal = new SEC_DAL(_webHostEnvironment);
            bool isSuccess = dal.PR_MST_USER_DELETEBYID(UserID);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Data Deleted Successfully.";
                return RedirectToAction("SEC_User_SelectAll");
            }
            return RedirectToAction("SEC_User_SelectAll");
        }
        #endregion

        #region User Home Page

        public IActionResult SEC_User_Dashboard()
        {
            return View();
        }

        #endregion

        #region User Login

        public IActionResult SEC_User_Login()
        {
            return View();
        }

        #endregion

        #region User Profile

        public IActionResult SEC_User_Profile()
        {
            return View();
        }

        #endregion

       
    }
}
