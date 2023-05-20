using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CIE_206.Models.DataBase;
using System.Data;
using CIE_206.Models.TableModel;
using ClosedXML.Excel;

namespace CIE_206.Pages.CharityWorkersView
{
    public class NeedyMenuModel : PageModel
    {
        private readonly NeedyDB db;
        public NeedyMenuModel(NeedyDB db)
        {
            this.db = db;
            dt = new DataTable();
        }
        public DataTable dt { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserType") != "A" && HttpContext.Session.GetString("UserType") != "E" && HttpContext.Session.GetString("UserType") != "DE")
            {
                return RedirectToPage("/Index");
            }

            dt = (DataTable)db.GetAllNeedy();

            return Page();
        }
    }
}
