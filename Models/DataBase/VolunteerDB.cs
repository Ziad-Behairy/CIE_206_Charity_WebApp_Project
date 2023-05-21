using CIE_206.Models.TableModel;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Data.SqlClient;

namespace CIE_206.Models.DataBase
{
    public class VolunteerDB : DB
    {
        public object getVoulanteerinfo()
        {
            return FunctionExcuteReader("select p.Fname,p.Lname,p.PhoneNumber,v.VoulanteerSection,v.VoulanteerId,v.Address,v.Notes,v.VolunteerBranch from \r\nVolunteer as v left join Persons as p\r\non(v.VoulanteerId=p.PersonID)");
        }
        public object AddVoulanteerInformation(Volunteer D)
        {
            object NumberOfRowsAffected = FunctionExcuteNonQuery("INSERT INTO DonatorInformation(Fname, Lname, U_Email, PhoneNumber, Address,VoulanteerId, VoulanteerSection, Notes)" +
                $" VALUES (N'{D.Fname}', N'{D.Lname}', N'{D.U_Email}', N'{D.PhoneNumber}', N'{D.Address}', N'{D.VoulanteerId}', N'{D.VoulanteerSection}', N'{D.Notes}')");
            return NumberOfRowsAffected;
        }
     
    }
}
