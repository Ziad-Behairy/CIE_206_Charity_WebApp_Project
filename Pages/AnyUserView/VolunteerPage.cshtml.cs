using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE_206.Pages.AnyUserView
{
    public class VolunteerPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserType") == null)
            {
                return RedirectToPage("/AnyUserView/LoginPage", new { msg = "„‰ ›÷·ﬂ ”Ã· œŒÊ· «Ê·« ·ﬂÌ   ÿÊ⁄" });

            }
            return Page();
        }
    }
}
