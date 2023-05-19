using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIE_206.Pages.CharityWorkersView
{
    public class DonatorsInfoModel : PageModel
    {
        [BindProperty]
        public Donator D { get; set; }

        private readonly DonatorDB DB;
        
        public DataTable dt { get; set; }
        public DonatorsInfoModel()
        {
            DB = new DonatorDB();
            dt= new DataTable();
        }
        public IActionResult OnGet()
        {
			if (HttpContext.Session.GetString("UserType") != "A" && HttpContext.Session.GetString("UserType") != "E" && HttpContext.Session.GetString("UserType") != "DE")
			{
				return RedirectToPage("/Index");
			}



			dt =(DataTable)DB.getdonatorinfo();

			return Page();
		}



        public IActionResult OnPost()
        {
            if(ModelState.IsValid) 
            {

                DB.AddDonatorInformation(D);
                return RedirectToPage("/CharityWorkersView/DonatorsInfo");
            }
            return Page();

        }




        public IActionResult OnPostDownloadExcel()
        {
            dt = (DataTable)DB.getdonatorinfo();
            // Create a DataTable
            DataTable ddt = new DataTable("Sample Data");
            ddt.Columns.AddRange(new DataColumn[7]
           {
                            new DataColumn("الاسم", typeof(string)),
                            new DataColumn("رقم الهاتف", typeof(string)),
                            new DataColumn("العنوان", typeof(string)),
                            new DataColumn("البريد الالكتروني", typeof(string)),
                            new DataColumn("الوظيفة", typeof(string)),
                            new DataColumn("المبلغ الشهري", typeof(string)),
                            new DataColumn("ملاحظات", typeof(string))
           });



            // Add rows to the DataTable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddt.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6]);

            }



            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(ddt);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SampleData.xlsx");
                }
            }
        }
    }
}
