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
                dt = (DataTable)Db.FunctionExcuteReader("select p.Fname,p.Lname,v.EmployeeSSN ,p.PhoneNumber,v.EmployeeAdress,v.WorkingBranch,v.Salary from \r\nEmployees as v left join Persons as p\r\non("+ HttpContext.Session.GetString("UserID") + "=p.PersonID)");
            }
            /*just in case any edit*/
            else if ((HttpContext.Session.GetString("UserType") == "E"))
            {
                dt = (DataTable)Db.FunctionExcuteReader("select p.Fname,p.Lname,v.EmployeeSSN ,p.PhoneNumber,v.EmployeeAdress,v.WorkingBranch,v.Salary from \r\nEmployees as v left join Persons as p\r\non(" + HttpContext.Session.GetString("UserID") + "=p.PersonID)");

            }
        }
    }
}
