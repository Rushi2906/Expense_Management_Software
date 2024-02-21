namespace Expense_Management_Software.Models
{
    public class HomeModel
    {
        public int UserCount { get; set; }
        public int CategoryCount { get; set; }
        public int PaymnetModeCount { get; set; }
    }

    public class UserDashboardCount
    {
        public decimal? Income { get; set; }
        public decimal? Expense { get; set; }
    }

    public class CategoryFilterModel
    {
        public string? CategoryName { get; set; }
        public decimal? Category_INCOME { get; set; }
        public decimal? Category_EXPENSE { get; set; }
    }

    public class PaymentModeModel
    {
        public string? PaymentModeName { get; set; }
        public decimal? Payment_INCOME { get; set; }
        public decimal? Payment_EXPENSE { get; set; }
    }

    public class Demo
    {
        public IEnumerable<CategoryFilterModel> Categories { get; set; }
        public IEnumerable<HomeModel> Counters { get; set; }
        public IEnumerable<UserDashboardCount> UserCounters { get; set; }
        public IEnumerable<PaymentModeModel> PaymentModes { get; set; }
    }
}
