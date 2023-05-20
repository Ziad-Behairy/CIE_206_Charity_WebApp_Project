using CIE_206.Models.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;


namespace CIE_206.Pages.CharityWorkersView
{
    public class EmployeeModel : PageModel
    {

        [BindProperty]
        public DataTable dt { get; set; }
        private readonly DB Db;
        public EmployeeModel(DB db)
        {
            Db = db;
        }
        public void OnGet()
        {

            dt = new DataTable();
            if (HttpContext.Session.GetString("UserType") == "A")
            {
                dt = (DataTable)Db.FunctionExcuteReader("SELECT CONCAT(U.Fname, ' ', U.Lname) AS EmployeeName,E.EmployeeSSN,U.PhoneNumber,E.EmployeeAddress AS EmployeeAdress, B.BranchName,E.Salary \r\nFROM Branchs AS B JOIN Employees AS E  ON B.BranchID = E.WorkingBranch\r\nJOIN Users AS U ON UserID= E.EmployeeID\r\norder by CONCAT(U.Fname, ' ', U.Lname)\r\n");
            }
            /*just in case any edit*/
            else if ((HttpContext.Session.GetString("UserType") == "E"))
            {
                dt = (DataTable)Db.FunctionExcuteReader("SELECT CONCAT(U.Fname, ' ', U.Lname) AS EmployeeName,E.EmployeeSSN,U.PhoneNumber,E.EmployeeAddress AS EmployeeAddress, B.BranchName, E.Salary \r\nFROM Employees AS E JOIN Branchs AS B ON B.BranchID = E.WorkingBranch JOIN Users AS U ON U.UserID = E.EmployeeIDWHERE U.UserID = " + HttpContext.Session.GetString("UserID") + " ORDER BY CONCAT(U.Fname, ' ', U.Lname); ");

            }
        }
    }
}
