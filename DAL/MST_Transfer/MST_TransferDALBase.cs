using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Expense_Management_Software.BAL;
using Expense_Management_Software.Areas.MST_TransactionType.Models;
using Expense_Management_Software.Areas.MST_Transaction.Models;

namespace Expense_Management_Software.DAL.MST_Transfer
{
    public class MST_TransferDALBase:SEC_DALHelper
    {

        #region PR_MST_TRANSFER_SELECTALL

        public DataTable PR_MST_TRANSFER_SELECTALL()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFER_SELECTALL]");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, CV.UserID());
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

        #region Method : Admin_MST_TransferSave
        public bool Admin_MST_TransferSave(MST_TransactionModel transactionModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (transactionModel.TransferID == 0)
                {

                    


                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFER_INSERT]");
                    sqlDatabase.AddInParameter(dbCommand, "@TransferTypeID", DbType.Int32, transactionModel.TransferTypeID);
                    sqlDatabase.AddInParameter(dbCommand, "@TransferAmount", DbType.Decimal, transactionModel.TransferAmount);
                    sqlDatabase.AddInParameter(dbCommand, "@TransferNote", DbType.String, transactionModel.TransferNote);
                    sqlDatabase.AddInParameter(dbCommand, "@TransferDate", DbType.DateTime, transactionModel.TransferDate);
                    sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, CV.UserID());
                    sqlDatabase.AddInParameter(dbCommand, "@CategoryID", DbType.Int32, transactionModel.CategoryID);
                    sqlDatabase.AddInParameter(dbCommand, "@PaymentModeID", DbType.Int32, transactionModel.PaymentModeID);

                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFER_UPDATEBYPK]");
                    sqlDatabase.AddInParameter(dbCommand, "@TransferID", DbType.Int32, transactionModel.TransferID);
                    sqlDatabase.AddInParameter(dbCommand, "@TransferTypeID", DbType.Int32, transactionModel.TransferTypeID);
                    sqlDatabase.AddInParameter(dbCommand, "@TransferAmount", DbType.Decimal, transactionModel.TransferAmount);
                    sqlDatabase.AddInParameter(dbCommand, "@TransferNote", DbType.String, transactionModel.TransferNote);
                    sqlDatabase.AddInParameter(dbCommand, "@TransferDate", DbType.DateTime, transactionModel.TransferDate);
                    sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, CV.UserID());
                    sqlDatabase.AddInParameter(dbCommand, "@CategoryID", DbType.Int32, transactionModel.CategoryID);
                    sqlDatabase.AddInParameter(dbCommand, "@PaymentModeID", DbType.Int32, transactionModel.PaymentModeID);
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

        #region Method : Admin_MST_TransferByID
        public MST_TransactionModel Admin_MST_TransferByID(int TransferID)
        {
            MST_TransactionModel transactionModel = new MST_TransactionModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFER_SELECTBYID]");
                sqlDatabase.AddInParameter(dbCommand, "@TransferID", DbType.Int32, TransferID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    transactionModel.TransferID = Convert.ToInt32(dataRow["TransferID"]);
                    transactionModel.TransferTypeID = Convert.ToInt32(dataRow["TransferTypeID"]);
                    transactionModel.TransferAmount = Convert.ToDouble(dataRow["TransferAmount"].ToString());
                    transactionModel.TransferDate = Convert.ToDateTime(dataRow["TransferDate"]);
                    transactionModel.TransferNote = dataRow["TransferNote"].ToString();
                    transactionModel.CategoryID = Convert.ToInt32(dataRow["CategoryID"]);
                    transactionModel.PaymentModeID = Convert.ToInt32(dataRow["PaymentModeID"]);
                    transactionModel.UserID = Convert.ToInt32(dataRow["UserID"]);
                    transactionModel.Created = Convert.ToDateTime(dataRow["Created"]);
                    transactionModel.Modified = Convert.ToDateTime(dataRow["Modified"]);
                }
                return transactionModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : PR_MST_TRANSFER_DELETEBYID
        public bool PR_MST_TRANSFER_DELETEBYID(int TransferID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                Console.WriteLine(TransferID);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFER_DELETEBYID]");
                sqlDatabase.AddInParameter(dbCommand, "@TransferID", DbType.Int32, TransferID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region Category Dropdown

        public DataTable Admin_MST_Transfer_Category_Dropdown()
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_CATEGORY_SELECTALL]");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }

            return dataTable;
        }

        #endregion

        #region Transfer Type Dropdown

        public DataTable Admin_MST_Transfer_Type_Dropdown()
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFERTYPE_SELECTALL]");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }

            return dataTable;
        }

        #endregion

        #region Payment Mode Dropdown

        public DataTable Admin_MST_Payment_Mode_Dropdown()
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_PAYMENTMODE_SELECTALL]");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }

            return dataTable;
        }

        #endregion

        #region Filter Transaction

        public DataTable MST_Transfer_Filter(MST_Transaction_FilterModel filterModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_TRANSFER_FILTER");
            sqlDatabase.AddInParameter(dbCommand, "@TransferTypeID", DbType.Int32, filterModel.TransferTypeID);
            sqlDatabase.AddInParameter(dbCommand, "@CategoryID", DbType.Int32, filterModel.CategoryID);
            sqlDatabase.AddInParameter(dbCommand, "@PaymentModeID", DbType.Int32, filterModel.PaymentModeID);
            sqlDatabase.AddInParameter(dbCommand, "@TransferAmount", DbType.Decimal, filterModel.TransferAmount);
            DataTable dt = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dt.Load(dataReader);
            }
            return dt;
        }

        #endregion
    }
}
