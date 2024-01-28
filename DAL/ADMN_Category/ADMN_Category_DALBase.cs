using Expense_Management_Software.Areas.ADMN_Category.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace Expense_Management_Software.DAL.ADMN_Category
{
    public class ADMN_Category_DALBase:SEC_DALHelper
    {
        #region PR_MST_CATEGORY_SELECTALL

        public DataTable PR_MST_CATEGORY_SELECTALL()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_CATEGORY_SELECTALL");
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

        #region Method : PR_MST_CATEGORY_DELETEBYID
        public bool PR_MST_CATEGORY_DELETEBYID(int CategoryID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_CATEGORY_DELETEBYID");
                sqlDatabase.AddInParameter(dbCommand, "@CategoryID", DbType.Int32, CategoryID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region Method : Category Insert and Update
        public bool Admin_MST_CatgeorySave(Admin_MST_CategoryModel categoryModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (categoryModel.CategoryID == 0)
                {
                    if (categoryModel.CategoryPhoto != null)
                    {
                        string FilePath = "wwwroot\\images\\category";
                        string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileNameWithPath = Path.Combine(path, categoryModel.CategoryPhoto.FileName);

                        categoryModel.CategoryImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + categoryModel.CategoryPhoto.FileName;

                        using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            categoryModel.CategoryPhoto.CopyTo(fileStream);
                        }
                    }
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_ADMIN_MST_CATEGORY_INSERT");
                    sqlDatabase.AddInParameter(dbCommand, "@CategoryName", DbType.String, categoryModel.CategoryName);
                    sqlDatabase.AddInParameter(dbCommand, "@CategoryImage", DbType.String, categoryModel.CategoryImage);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                    if (categoryModel.CategoryPhoto != null)
                    {
                        string FilePath = "wwwroot\\images\\category";
                        string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileNameWithPath = Path.Combine(path, categoryModel.CategoryPhoto.FileName);

                        categoryModel.CategoryImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + categoryModel.CategoryPhoto.FileName;

                        using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            categoryModel.CategoryPhoto.CopyTo(fileStream);
                        }
                    }
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_CATEGORY_UPDATEBYPK");
                    sqlDatabase.AddInParameter(dbCommand, "@CategoryID", DbType.Int32, categoryModel.CategoryID);
                    sqlDatabase.AddInParameter(dbCommand, "@CategoryName", DbType.String, categoryModel.CategoryName);
                    sqlDatabase.AddInParameter(dbCommand, "@CategoryImage", DbType.String, categoryModel.CategoryImage);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Admin_MST_CatgeoryByID
        public Admin_MST_CategoryModel Admin_MST_CatgeoryByID(int CategoryID)
        {
            Admin_MST_CategoryModel admin_MST_CategoryModel = new Admin_MST_CategoryModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_CATEGORY_SELECTBYID]");
                sqlDatabase.AddInParameter(dbCommand, "@CategoryID", DbType.Int32, CategoryID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    admin_MST_CategoryModel.CategoryID = Convert.ToInt32(dataRow["CategoryID"]);
                    admin_MST_CategoryModel.CategoryName = dataRow["CategoryName"].ToString();
                    admin_MST_CategoryModel.CategoryImage = dataRow["CategoryImage"].ToString();
                    admin_MST_CategoryModel.Created = Convert.ToDateTime(dataRow["Created"]);
                    admin_MST_CategoryModel.Modified = Convert.ToDateTime(dataRow["Modified"]);
                }
                return admin_MST_CategoryModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
