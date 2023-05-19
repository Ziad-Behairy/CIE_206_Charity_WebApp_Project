using CIE_206.Models.DataBase;
using CIE_206.Models.TableModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CIE_206.Pages.AnyUserView
{
    public class SignUpPageModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "��� ����� �����")]
        public string Fname { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "��� ����� �����")]
        public string Lname { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "��� ����� �����")]
        [EmailAddress]
        public string U_Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "��� ����� �����")]
        public string U_Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "��� ����� �����")]
        public string PhoneNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "��� ����� �����")]
        public string Gender { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "��� ����� �����")]
        public string BirthDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "��� ����� �����")]
        public string Country { get; set; }


        public string Message { get; set; }

        Users CurrentUser;



        public UsersDB Db { get; set; }

        public SignUpPageModel()
        {
            Db = new UsersDB();
            CurrentUser = new Users();
        }

        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                CurrentUser.Fname= Fname;
                CurrentUser.Lname= Lname;
                CurrentUser.U_Email= U_Email;
                CurrentUser.PhoneNumber= PhoneNumber;
                CurrentUser.Gender= Gender;
                CurrentUser.U_Password= U_Password;
                CurrentUser.BirthDate=BirthDate;
                CurrentUser.Country= Country;
                CurrentUser.UserType = "U";

                if (Db.CheckIfEmailExist(CurrentUser.U_Email))
                {
                    Message = "��� ������ ����� �� ���";
                    return Page();
                }

                if (CurrentUser.U_Password.Length <= 8)
                {
                    Message = "���� ������ ����� ���� �� �������� ��� ���� �� 8 ����";
                    return Page();
                }

                bool hasCapitalLetter = CurrentUser.U_Password.Any(char.IsUpper);
                bool hasLowerCase = CurrentUser.U_Password.Any(char.IsLower);
                bool hasNumber = CurrentUser.U_Password.Any(char.IsDigit);

                if (!(hasCapitalLetter && hasLowerCase && hasNumber))
                {
                    Message = "���� �� �� ����� ���� ������ ��� ��� ���� ���� ���� ����";
                    return Page();
                }

                
                if (CurrentUser.PhoneNumber.Length < 11 || CurrentUser.PhoneNumber.Any(c => !char.IsDigit(c)))
                {
                    Message = "������ ��� ����";
                    return Page();
                }

                if (Db.CalculateUserAge(CurrentUser.BirthDate) < 18)
                {
                    Message = "��� ��� �� 18 ���";
                    return Page();
                }

                if (Db.CalculateUserAge(CurrentUser.BirthDate) > 100)
                {
                    Message = "����� ������� ��� ����";
                    return Page();
                }

                object x = Db.AddUser(CurrentUser);

                string id = CurrentUser.UserID.ToString();

                HttpContext.Session.SetString("UserFname", CurrentUser.Fname);
                HttpContext.Session.SetString("Email", CurrentUser.U_Email);
                HttpContext.Session.SetString("UserType", CurrentUser.UserType);
                HttpContext.Session.SetString("UserID", id);

                return RedirectToPage("/Index");
            }
            return Page();

        }
    }
}
