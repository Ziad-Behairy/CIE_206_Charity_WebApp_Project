using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using CIE_206.Models.DataBase;
namespace Project.Pages.DashBoard
{
   
     

    public class TasksModel : PageModel
    {
        [BindProperty]
        public DataTable dt { get; set; }
        private readonly DB Db;
        public TasksModel( DB db)
        {
            Db = db;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserType") != "A" && HttpContext.Session.GetString("UserType") != "E" && HttpContext.Session.GetString("UserType") != "DE")
            {
                return RedirectToPage("/Index");
            }


            dt = new DataTable();

            if (HttpContext.Session.GetString("UserType") == "A") {
                dt = (DataTable) Db.FunctionExcuteReader("\r\nSELECT T.T_Name, T.T_assigne_day, CONCAT(U.Fname, ' ', U.Lname) AS EmployeeName, T.T_State,T_finsh_day ,T.T_notes \r\n\r\nFROM Tasks AS T JOIN Persons AS U ON U.PersonID = T.T_Employee_id\r\n\r\norder by CONCAT(U.Fname, ' ', U.Lname)");
            }
            else if ((HttpContext.Session.GetString("UserType") == "E"))
            {
                dt = (DataTable)Db.FunctionExcuteReader("SELECT T.T_Name, T.T_assigne_day, CONCAT(U.Fname, ' ', U.Lname) AS EmployeeName, T.T_State, T.T_notes\r\nFROM Tasks AS T \r\nJOIN Employees AS E  ON T.T_Employee_id = E.EmployeeID\r\nJOIN Users AS U ON UserID= E.EmployeeID\r\nWHERE U.UserID = " + HttpContext.Session.GetString("UserID") + " order by CONCAT(U.Fname, ' ', U.Lname)");

            }
            

            return Page();
        }
    }
}
