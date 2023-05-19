

using System.ComponentModel.DataAnnotations;

namespace CIE_206.Models.TableModel
{
    public class Users
    {
        public int UserID { get; set; }

        public string UserType { get; set; }

        public string Fname { get; set; }
                
        public string Lname { get; set; }

        public string U_Email { get; set; }

        public string U_Password { get; set;}

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

        public string BirthDate { get; set; }

        public string Country { get; set; }

        public string Age { get; set; }
        public string CreateDate { get; set;}

    }
}
