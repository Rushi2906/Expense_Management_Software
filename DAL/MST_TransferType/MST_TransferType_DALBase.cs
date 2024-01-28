using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Expense_Management_Software.Areas.ADMN_PaymentMode.Models;
using Expense_Management_Software.Areas.MST_TransactionType.Models;

namespace Expense_Management_Software.DAL.MST_TransferType
{
    public class MST_TransferType_DALBase:SEC_DALHelper
    {
        #region PR_MST_TRANSFERTYPE_SELECTALL

        public DataTable PR_MST_TRANSFERTYPE_SELECTALL()
        {
            try
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
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method : PR_MST_TRANSFERTYPE_DELETEBYID
        public bool PR_MST_TRANSFERTYPE_DELETEBYID(int TransferTypeID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                Console.WriteLine(TransferTypeID);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFERTYPE_DELETEBYID]");
                sqlDatabase.AddInParameter(dbCommand, "@TransferTypeID", DbType.Int32, TransferTypeID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region Method : Admin_MST_TransferTypeSave
        public bool Admin_MST_TransferTypeSave(MST_TransactionTypeModel transactionTypeModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (transactionTypeModel.TransferTypeID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFERTYPE_INSERT]");
                    sqlDatabase.AddInParameter(dbCommand, "@TransferTypeName", DbType.String, transactionTypeModel.TransferTypeName);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFERTYPE_UPDATEBYPK]");
                    sqlDatabase.AddInParameter(dbCommand, "@TransferTypeID", DbType.Int32, transactionTypeModel.TransferTypeID);
                    sqlDatabase.AddInParameter(dbCommand, "@TransferTypeName", DbType.String, transactionTypeModel.TransferTypeName);
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

        #region Method : Admin_MST_TransferTypeByID
        public MST_TransactionTypeModel Admin_MST_TransferTypeByID(int TransferTypeID)
        {
            MST_TransactionTypeModel transactionTypeModel = new MST_TransactionTypeModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("[PR_MST_TRANSFERTYPE_SELECTBYID]");
                sqlDatabase.AddInParameter(dbCommand, "@TransferTypeID", DbType.Int32, TransferTypeID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    transactionTypeModel.TransferTypeID = Convert.ToInt32(dataRow["TransferTypeID"]);
                    transactionTypeModel.TransferTypeName = dataRow["TransferTypeName"].ToString();
                    transactionTypeModel.Created = Convert.ToDateTime(dataRow["Created"]);
                    transactionTypeModel.Modified = Convert.ToDateTime(dataRow["Modified"]);
                }
                return transactionTypeModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
