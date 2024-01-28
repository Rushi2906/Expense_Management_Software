namespace Expense_Management_Software.DAL
{
    public class SEC_DALHelper
    {
        #region Connection String
        
        public static string ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");
        
        #endregion
    }
}
