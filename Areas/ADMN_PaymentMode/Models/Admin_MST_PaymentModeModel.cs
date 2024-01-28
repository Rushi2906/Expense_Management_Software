namespace Expense_Management_Software.Areas.ADMN_PaymentMode.Models
{
    public class Admin_MST_PaymentModeModel
    {
        public int PaymentModeID { get; set; }
        public string PaymentModeType { get; set;}
        public DateTime? Created { get; set; }
        public DateTime? Modified {  get; set; }
        public int? UserID { get; set;}
    }
}
