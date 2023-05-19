using CIE_206.Models.TableModel;

namespace CIE_206.Models.DataBase
{
    public class DonatorDB : DB
    {
        public object getdonatorinfo()
        {
            return FunctionExcuteReader("select Fname+' '+Lname as name,PhoneNumber,U_Email,Address, Job, DonationAmount, Notes from DonatorInformation");
        }
        public object AddDonatorInformation(Donator D)
        {
            object NumberOfRowsAffected = FunctionExcuteNonQuery("INSERT INTO DonatorInformation(Fname, Lname, U_Email, PhoneNumber, Address, Job, DonationAmount, Notes)" +
                $" VALUES (N'{D.Fname}', N'{D.Lname}', N'{D.U_Email}', N'{D.PhoneNumber}', N'{D.Address}', N'{D.Job}', N'{D.DonationAmount}', N'{D.Notes}')");
            return NumberOfRowsAffected;
        }

    }
}
