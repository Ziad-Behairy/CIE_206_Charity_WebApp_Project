using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE_206.Pages.CharityWorkersView
{
    public class NeedyDetailsModel : PageModel
    {

        private readonly NeedyDB db;
        public List<Needy> needyList { get; set; }
        public NeedyDetailsModel(NeedyDB db)
        {
            this.db = db;

           
        }
        public void OnGet(string id )
        {
            if (HttpContext.Session.GetString("UserType") != "A" && HttpContext.Session.GetString("UserType") != "E" && HttpContext.Session.GetString("UserType") != "DE")
            {
                RedirectToPage("/Index");
            }
        needyList = db.GetNeedy(id);

        }





        public IActionResult OnPost(string iddelete) {

           
            db.DeleteNeedy(iddelete);
            return RedirectToPage("/CharityWorkersView/NeedyMenu");
        
        
        }
    }
}
