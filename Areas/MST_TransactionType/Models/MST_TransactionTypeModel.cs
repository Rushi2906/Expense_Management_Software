using System.ComponentModel.DataAnnotations;

namespace Expense_Management_Software.Areas.MST_TransactionType.Models
{
    public class MST_TransactionTypeModel
    {
        public int TransferTypeID { get; set; }
        [Required]
        public string TransferTypeName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int? UserID { get; set; }

    }
}
