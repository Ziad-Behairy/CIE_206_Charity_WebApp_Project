using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using System.Collections.Generic;
namespace CIE_206.Pages.CharityWorkersView
{
    public class UpdateNeedyDataModel : PageModel
    {
        private readonly NeedyDB db;
        public UpdateNeedyDataModel(NeedyDB db)
        {
            this.db = db;
        }


        public List<Needy> needyList { get; set; }
        [BindProperty]
        public Needy Needy { get; set; } // Replace `NeedyModel` with your actual model class

        public void OnGet(string id)
        {
            needyList = db.GetNeedy(id);

            if (needyList != null && needyList.Count > 0)
            {
                Needy = new Needy(); // Create a new instance of Needy

                // Assign the properties of the first element in needyList to the corresponding properties in Needy
                Needy.Number = needyList[0].Number;
                Needy.NeedyID = needyList[0].NeedyID;
                Needy.Fname = needyList[0].Fname;
                Needy.Mname = needyList[0].Mname;
                Needy.Lname = needyList[0].Lname;
                Needy.Familyname = needyList[0].Familyname;
                Needy.SSN = needyList[0].SSN;
                Needy.PhoneNum = needyList[0].PhoneNum;
                Needy.Birthdate = needyList[0].Birthdate;
                Needy.StreetAddress = needyList[0].StreetAddress;
                Needy.floornum = needyList[0].floornum;
                Needy.Area = needyList[0].Area;
                Needy.mark = needyList[0].mark;
                Needy.Income = needyList[0].Income;
                Needy.Casetype = needyList[0].Casetype;
                Needy.NumberOfFamilyMembers = needyList[0].NumberOfFamilyMembers;
                Needy.AreaCode = needyList[0].AreaCode;
                Needy.HealthStatus = needyList[0].HealthStatus;
                Needy.EducationalState = needyList[0].EducationalState;
                Needy.SocialState = needyList[0].SocialState;
                Needy.Job = needyList[0].Job;
                Needy.AcceptStatus = needyList[0].AcceptStatus;
                Needy.Details = needyList[0].Details;
                Needy.ImageDataPath = needyList[0].ImageDataPath;
                Needy.FrontidimgPath = needyList[0].FrontidimgPath;
                Needy.BackidimgPath = needyList[0].BackidimgPath;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the needy information in the database
            db.UpdateNeedy(Needy); // Replace `UpdateNeedy` with your method to update the needy data

            return RedirectToPage("/CharityWorkersView/NeedyMenu");
        }
    
  }
}
