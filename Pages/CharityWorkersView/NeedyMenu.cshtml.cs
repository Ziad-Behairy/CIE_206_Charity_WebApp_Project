using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE_206.Pages.CharityWorkersView
{
    public class NeedyMenuModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserType") != "A" && HttpContext.Session.GetString("UserType") != "E" && HttpContext.Session.GetString("UserType") != "DE")
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
