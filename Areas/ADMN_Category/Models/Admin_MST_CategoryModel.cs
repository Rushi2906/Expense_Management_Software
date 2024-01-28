namespace Expense_Management_Software.Areas.ADMN_Category.Models
{
    public class Admin_MST_CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        public DateTime Created {  get; set; }
        public DateTime Modified { get; set; }
        public IFormFile? CategoryPhoto { get; set; }
        public int? UserID { get; set; }
    }
}
