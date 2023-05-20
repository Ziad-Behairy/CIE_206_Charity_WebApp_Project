using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

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

        [BindProperty]
        public Needy Needy { get; set; }

        public void OnGet()
        {
        }

        private void SaveImageFile(IFormFile file, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        private string GetUniqueFilePath(string fileName)
        {
            var uniqueName = $"{DateTime.Now.Ticks}_{Path.GetRandomFileName()}";
            var uniqueFileName = $"{uniqueName}{Path.GetExtension(fileName)}";
            var filePath = Path.Combine("wwwroot/UploadedImgs", uniqueFileName).Replace("\\", "/");
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
                        string imagePath = GetUniqueFilePath(Needy.ImageData.FileName);
                        SaveImageFile(Needy.ImageData, imagePath);
                        Needy.ImageDataPath = imagePath.Replace("wwwroot", "");
                    }

                    if (Needy.Frontidimg != null && Needy.Frontidimg.Length > 0)
                    {
                        string frontImagePath = GetUniqueFilePath(Needy.Frontidimg.FileName);
                        SaveImageFile(Needy.Frontidimg, frontImagePath);
                        Needy.FrontidimgPath = frontImagePath.Replace("wwwroot", "");
                    }

                    if (Needy.Backidimg != null && Needy.Backidimg.Length > 0)
                    {
                        string backImagePath = GetUniqueFilePath(Needy.Backidimg.FileName);
                        SaveImageFile(Needy.Backidimg, backImagePath);
                        Needy.BackidimgPath = backImagePath.Replace("wwwroot", "");
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
