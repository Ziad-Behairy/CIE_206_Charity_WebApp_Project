using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CIE_206.Pages.CharityWorkersView
{
    public class Add_NeedyModel : PageModel
    {

        private readonly NeedyDB db;
        private readonly ILogger<Add_NeedyModel> _logger;
        public Add_NeedyModel(ILogger<Add_NeedyModel> logger, NeedyDB db)
        {
            _logger = logger;
            this.db = db;
        }

        public int done { get; set; }
        [BindProperty]
        public Needy Needy { get; set; }



        public IActionResult OnGet()
        {
			if (HttpContext.Session.GetString("UserType") != "A" && HttpContext.Session.GetString("UserType") != "E" && HttpContext.Session.GetString("UserType") != "DE")
			{
				return RedirectToPage("/Index");
			}





			return Page();
		}



        private void SaveImageFile(IFormFile file, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
        private string GetFilePath(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine("Uploads", fileName);
            return filePath;
        }
        public IActionResult OnPost()

        {
            
            
            


            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {

                    if (Needy.ImageData != null && Needy.ImageData.Length > 0)
                    {
                        Needy.ImageDataPath = GetFilePath(Needy.ImageData);
                        SaveImageFile(Needy.ImageData, Needy.ImageDataPath);
                    }


                    if (Needy.Frontidimg != null && Needy.Frontidimg.Length > 0)
                    {
                        Needy.FrontidimgPath = GetFilePath(Needy.Frontidimg);
                        SaveImageFile(Needy.Frontidimg, Needy.FrontidimgPath);
                    }

                    if (Needy.Backidimg != null && Needy.Backidimg.Length > 0)
                    {
                        Needy.BackidimgPath = GetFilePath(Needy.Backidimg);
                        SaveImageFile(Needy.Backidimg, Needy.BackidimgPath);
                    }

                    // Save the Needy model to the database
                    db.AddNewNeedy(Needy);
                    return RedirectToPage("/CharityWorkersView/NeedyMenu");
                }
            }

            // Invalid ModelState, redirect to the Employee page
            return Page();
        }
      
    }
}  

