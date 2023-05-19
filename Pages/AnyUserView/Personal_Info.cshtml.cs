using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE_206.Pages.AnyUserView
{
    public class Personal_InfoModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserType") == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
