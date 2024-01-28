using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Expense_Management_Software.Areas.SEC_User.Models;
using Microsoft.AspNetCore.Hosting;

namespace Expense_Management_Software.DAL.SEC_DAL
{
    public class SEC_DALBase : SEC_DALHelper
    {

        #region PhotoFile Upload

        private readonly IWebHostEnvironment _webHostEnvironment;
        public SEC_DALBase(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        #endregion

        #region Method: PR_MST_USER_SELECTBYNAMEPASSWORD
        public DataTable PR_MST_USER_SELECTBYNAMEPASSWORD(string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_MST_USER_SELECTBYNAMEPASSWORD");
                sqlDB.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex) { return null; }
        }
        #endregion

        #region Method: PR_MST_USER_INSERT
        public bool PR_MST_USER_INSERT(SEC_UserModel userModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand db = sqlDatabase.GetStoredProcCommand("PR_MST_USER_SELECTBYNAME");
                sqlDatabase.AddInParameter(db, "@USERNAME", SqlDbType.VarChar, userModel.UserName);
                DataTable dt = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(db))
                {
                    dt.Load(dataReader);
                }
                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine(userModel.CoverPhoto);
                    //For Upload and get Photo into Database
                    if (userModel.CoverPhoto != null)
                    {
                        string folder = "images/user/";
                        folder += Guid.NewGuid().ToString() + "_" + userModel.CoverPhoto.FileName;  // Guid.NewGuid().ToString() for making file name unique

                        userModel.ProfilePicture = "/" + folder;

                        string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                        userModel.CoverPhoto.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
                    }

                    DbCommand dbCmd = sqlDatabase.GetStoredProcCommand("PR_MST_USER_INSERT");
                    sqlDatabase.AddInParameter(dbCmd, "@UserName", SqlDbType.NVarChar, userModel.UserName);
                    sqlDatabase.AddInParameter(dbCmd, "@Password", SqlDbType.NVarChar, userModel.Password);
                    sqlDatabase.AddInParameter(dbCmd, "@FirstName", SqlDbType.NVarChar, userModel.FirstName);
                    sqlDatabase.AddInParameter(dbCmd, "@LastName", SqlDbType.NVarChar, userModel.LastName);
                    sqlDatabase.AddInParameter(dbCmd, "@Email", SqlDbType.NVarChar, userModel.Email);
                    sqlDatabase.AddInParameter(dbCmd, "@ProfilePicture", SqlDbType.NVarChar, userModel.ProfilePicture);

                    if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCmd)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        #endregion

        #region Method: PR_User_SelectAll

        public DataTable PR_MST_USER_SELECTALL()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_USER_SELECTALL");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region: Method: PR_User_Delete

        public bool PR_MST_USER_DELETEBYID(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_USER_DELETEBYID]");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion



    }
}
