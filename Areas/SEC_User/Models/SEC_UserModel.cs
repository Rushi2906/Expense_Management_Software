using System.ComponentModel.DataAnnotations;

namespace Expense_Management_Software.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int? UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ProfilePicture { get; set; }

        public int IsAdmin { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IFormFile? CoverPhoto { get; set; }


    }
}
