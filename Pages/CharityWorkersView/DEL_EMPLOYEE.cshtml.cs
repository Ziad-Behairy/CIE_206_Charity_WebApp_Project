using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

using CIE_206.Models.DataBase;

namespace CIE_206.Pages.CharityWorkersView
{
    public class DEL_EMPLOYEEModel : PageModel
    {


        public static string ssn;
        [BindProperty]
        public DataTable dt { get; set; }

        private readonly DB Db;
        public DEL_EMPLOYEEModel( DB db)
        {
          
            Db = db;
        }
    
        public void OnGet(string id)
        {
            
            ssn = id;
            string q = "select CONCAT(U.Fname, ' ', U.Lname) AS EmployeeName from Users as U join Employees on U.UserID=EmployeeID WHERE EmployeeSSN='" + ssn + "'";
            dt =(DataTable)Db.FunctionExcuteReader(q);


        }
        public IActionResult OnPost()
        {

            
            Db.FunctionExcuteNonQuery("DELETE FROM Users WHERE Users.UserID = (SELECT Employees.EmployeeID FROM Employees WHERE Employees.EmployeeSSN = '"+ssn+"' );");
            Db.FunctionExcuteNonQuery("delete from Employees where Employees.EmployeeSSN ='"+ssn+"';");

            return RedirectToPage("/CharityWorkersView/Employee");

        }
    }
}
