using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIE_206.Pages.CharityWorkersView
{
    public class DeleteDonatorModel : PageModel
    {
        public static string phone;

        [BindProperty]
        public Donator u { get; set; }
        public System.Data.DataTable dt { get; set; }
        private readonly DonatorDB DB;

        public DeleteDonatorModel(DonatorDB db)
        {
            DB = db;
            dt = new System.Data.DataTable();

        }

        public void OnGet(string id)
        {
            phone = id;
            object result = DB.Get1DonInfo(phone);

            if (result is System.Data.DataTable dt && dt.Rows.Count > 0)
            {
                u.PhoneNumber = dt.Rows[0][1].ToString();
            }
            else
            {
                // Handle case when no rows are returned or result is not a DataTable
            }
        }

        public IActionResult OnPost()
        {
            u.PhoneNumber = phone;
            DB.DeleteDonator(u);
            return RedirectToPage("/CharityWorkersView/DonatorsInfo");
        }
    }
}
