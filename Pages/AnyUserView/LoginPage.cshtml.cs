using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIE_206.Pages.AnyUserView
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public UsersDB db;

        public LoginPageModel()
        {
            db = new UsersDB();
        }

        public void OnGet(string msg)
        {
            Message= msg;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                int State = db.CheckAcount(Email, Password);
                if (State == -2)
                {
                    Message = "Invalid Email";
                    return Page();
                }
                else if (State == -1)
                {
                    Message = "Invalid Password";
                    return Page();
                }
                DataTable dt = (DataTable)db.GetRow("Users", "U_Email = '" + Email + "'");
                DataRow row = dt.Rows[0];

                string UserFname = row.Field<string>("Fname");
                string email = row.Field<string>("U_Email");
                string UT = row.Field<string>("UserType");
                string id = row.Field<int>("UserID").ToString();

                HttpContext.Session.SetString("UserFname", UserFname);
                HttpContext.Session.SetString("Email", email);
                HttpContext.Session.SetString("UserType", UT);
                HttpContext.Session.SetString("UserID", id);

                if (State == 1 || State == 2 || State == 3)
                {
                    return RedirectToPage("/CharityWorkersView/statistics");
                }
                if (State == 10)
                {
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}
