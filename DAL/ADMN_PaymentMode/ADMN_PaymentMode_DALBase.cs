using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Expense_Management_Software.Areas.ADMN_Category.Models;
using Expense_Management_Software.Areas.ADMN_PaymentMode.Models;

namespace Expense_Management_Software.DAL.ADMN_PaymentMode
{
    public class ADMN_PaymentMode_DALBase : SEC_DALHelper
    {
        #region PR_MST_PAYMENTMODE_SELECTALL

        public DataTable PR_MST_PAYMENTMODE_SELECTALL()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_PAYMENTMODE_SELECTALL");
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

        #region Method : PR_MST_PAYMENTMODE_DELETEBYID
        public bool PR_MST_PAYMENTMODE_DELETEBYID(int PaymentModeID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_PAYMENTMODE_DELETEBYID");
                sqlDatabase.AddInParameter(dbCommand, "@PaymentModeID", DbType.Int32, PaymentModeID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region Method : Admin_MST_PaymentModeSave
        public bool Admin_MST_PaymentModeSave(Admin_MST_PaymentModeModel paymentModeModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (paymentModeModel.PaymentModeID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_PAYMENTMODE_INSERT");
                    sqlDatabase.AddInParameter(dbCommand, "@PaymentModeType", DbType.String, paymentModeModel.PaymentModeType);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_PAYMENTMODE_UPDATEBYPK");
                    sqlDatabase.AddInParameter(dbCommand, "@PaymentModeID", DbType.Int32, paymentModeModel.PaymentModeID);
                    sqlDatabase.AddInParameter(dbCommand, "@PaymentModeType", DbType.String, paymentModeModel.PaymentModeType);
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

        #region Method : Admin_MST_PaymentModeByID
        public Admin_MST_PaymentModeModel Admin_MST_PaymentModeByID(int PaymentModeID)
        {
            Admin_MST_PaymentModeModel admin_MST_PaymentModeModel = new Admin_MST_PaymentModeModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_PAYMENTMODE_SELECTBYID]");
                sqlDatabase.AddInParameter(dbCommand, "@PaymentModeID", DbType.Int32, PaymentModeID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    admin_MST_PaymentModeModel.PaymentModeID = Convert.ToInt32(dataRow["PaymentModeID"]);
                    admin_MST_PaymentModeModel.PaymentModeType = dataRow["PaymentModeType"].ToString();
                    admin_MST_PaymentModeModel.Created = Convert.ToDateTime(dataRow["Created"]);
                    admin_MST_PaymentModeModel.Modified = Convert.ToDateTime(dataRow["Modified"]);
                }
                return admin_MST_PaymentModeModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
