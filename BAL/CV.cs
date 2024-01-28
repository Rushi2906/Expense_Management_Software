namespace Expense_Management_Software.BAL
{
    public class CV
    {
        //Provides access to the current
        //Microsoft.AspNetCore.Http.IHttpContextAccessor.HttpContext

        private static IHttpContextAccessor _httpContextAccessor;
        static CV()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public static int? UserID()
        {
            //Initialize the UserID with null
            int? UserID = null;
            //check if session contains specified key?
            //if it contains then return the value contained by the key.
            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID =
               Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID").ToString());

            }
            Console.WriteLine(UserID);
            return UserID;
        }
        public static string? UserName()
        {
            string? UserName = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
            {
                UserName =
               _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
            }

            return UserName;
        }

        public static string? FirstName()
        {
            string? FirstName = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("FirstName") != null)
            {
                FirstName =
               _httpContextAccessor.HttpContext.Session.GetString("FirstName").ToString();
            }

            return FirstName;
        }

        public static string? LastName()
        {
            string? LastName = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("LastName") != null)
            {
                LastName =
               _httpContextAccessor.HttpContext.Session.GetString("LastName").ToString();
            }

            return LastName;
        }

        public static string? Email()
        {
            string? Email = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("Email") != null)
            {
                Email =
               _httpContextAccessor.HttpContext.Session.GetString("Email").ToString();
            }

            return Email;
        }

        public static string? ProfilePicture()
        {
            string? ProfilePicture = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("ProfilePicture") != null)
            {
                ProfilePicture =
               _httpContextAccessor.HttpContext.Session.GetString("ProfilePicture").ToString();
            }

            return ProfilePicture;
        }

        public static bool IsAdmin()
        {
            //Initialize the UserID with null
            bool IsAdmin = false;
            //check if session contains specified key?
            //if it contains then return the value contained by the key.
            if (_httpContextAccessor.HttpContext.Session.GetString("IsAdmin") != null)
            {
                IsAdmin =
               Convert.ToBoolean(_httpContextAccessor.HttpContext.Session.GetString("IsAdmin").ToString());

            }
            Console.WriteLine("Admin"+IsAdmin);
            return IsAdmin;
        }

        public static DateTime? Created()
        {
            //Initialize the UserID with null
            DateTime? Created = null;
            //check if session contains specified key?
            //if it contains then return the value contained by the key.
            if (_httpContextAccessor.HttpContext.Session.GetString("Created") != null)
            {
                Created =
               Convert.ToDateTime(_httpContextAccessor.HttpContext.Session.GetString("Created").ToString());
                
            }
            Console.WriteLine(Created);
            return Created;
        }

    }
}
