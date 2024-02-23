namespace Expense_Management_Software.Areas.MST_Transaction.Models
{
    public class MST_TransactionModel
    {
        public int TransferID { get; set; }
        public int? CategoryID { get; set; }
        public int? PaymentModeID { get; set; }
        public int? UserID { get; set; }
        public int? TransferTypeID { get; set; }
        public string? TransferTypeName { get; set; }
        public string? TransferNote { get; set; }
        public string? CategoryName { get; set; }
        public string? PaymentModeType { get; set; }
        public string? UserName { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? TransferAmount { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public double? Income { get; set; }
        public double? Expense { get; set; }

    }

    public class MST_Transaction_FilterModel
    {
        //public int TransferID { get; set;}
        public int? CategoryID { get; set;}
        public int? TransferTypeID { get; set; }
        public int? PaymentModeID { get; set; }
        public double? TransferAmount { get; set; }
        //public DateTime? TransferDate { get; set; }
        //public string? TransferNote { get; set; }

    }

    public class MST_Transaction_MultipleDelete
    {
        public List<MST_TransactionModel> Transactions { get; set;}
    }
}
