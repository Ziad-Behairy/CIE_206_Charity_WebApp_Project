using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE_206.Pages.AnyUserView
{
    public class DonatorPageModel : PageModel
    {
        public IActionResult OnGet()
        {

            if (HttpContext.Session.GetString("UserType") == null)
            {
                return RedirectToPage("/AnyUserView/LoginPage", new {msg = "„‰ ›÷·ﬂ ”Ã· œŒÊ· «Ê·« ·ﬂÌ   »—⁄" });
            }
            return Page();
        }



        public IActionResult OnPost()
        {
            TempData["DonationMessage"] = "Thanks for donating!";
            return RedirectToPage("/Index");
        }
    }
}
