using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using System.Data;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE_206.Pages.CharityWorkersView
{
    public class EditDonatorModel : PageModel
    {
        [BindProperty]
        public Donator D { get; set; }
        private readonly DonatorDB DB;
        System.Data.DataTable dt;
       
        public EditDonatorModel(DonatorDB db)
        {
            DB = db;
            dt= new System.Data.DataTable();
        }

        public void OnGet(string id)
        {
            dt =  (System.Data.DataTable)DB.Get1DonInfo(id);
            if(dt.Rows.Count > 0)
            {
                D.Fname = dt.Rows[0][1].ToString();
                D.Lname = dt.Rows[0][2].ToString();

                

            }
        }
        public IActionResult OnPost()
        {
            DB.UpdateDonator(D);
            return RedirectToPage("/CharityWorkersView/DonatorsInfo");
        }
    }
}
