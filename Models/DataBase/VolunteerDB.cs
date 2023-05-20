using CIE_206.Models.TableModel;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Data.SqlClient;

namespace CIE_206.Models.DataBase
{
    public class VolunteerDB : DB
    {
        public object getVoulanteerinfo()
        {
            return FunctionExcuteReader("select Fname+' '+Lname as name, U_Email, PhoneNumber, Address, VoulanteerSection, VoulanteerId , Notes from Voulanteer");
        }
        public object AddVoulanteerInformation(Volunteer D)
        {
            object NumberOfRowsAffected = FunctionExcuteNonQuery("INSERT INTO DonatorInformation(Fname, Lname, U_Email, PhoneNumber, Address,VoulanteerId, VoulanteerSection, Notes)" +
                $" VALUES (N'{D.Fname}', N'{D.Lname}', N'{D.U_Email}', N'{D.PhoneNumber}', N'{D.Address}', N'{D.VoulanteerId}', N'{D.VoulanteerSection}', N'{D.Notes}')");
            return NumberOfRowsAffected;
        }
     
    }
}
