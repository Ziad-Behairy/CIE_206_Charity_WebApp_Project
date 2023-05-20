using CIE_206.Models.TableModel;
using System.Data.SqlClient;

namespace CIE_206.Models.DataBase
{
    public class DonatorDB : DB
    {
        public object getdonatorinfo()
        {
            return FunctionExcuteReader("select * from DonatorInformation");
        }
        public object AddDonatorInformation(Donator D)
        {
           
            // First insert into Persons table
            object NumberOfRowsAffected1 = FunctionExcuteNonQuery($"INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber) VALUES ('V', N'{D.Fname}', N'{D.Lname}', N'{D.PhoneNumber}')");

            // Then insert into Donators table
            object NumberOfRowsAffected2 = FunctionExcuteNonQuery($"INSERT INTO Donators (DonatorID, Address, Job, Email, DonationAmount, Notes) VALUES ((SELECT PersonID FROM Persons WHERE PhoneNumber=N'{D.PhoneNumber}'), N'{D.Address}', N'{D.Job}', N'{D.U_Email}', N'{D.DonationAmount}', N'{D.Notes}')");
            return NumberOfRowsAffected1;
        }
       
        public object Get1DonInfo(string PhoneNumber)
        {
            //return FunctionExcuteReader("select * from DonatorInformation where PhoneNumber = @PhoneNumber");
            
            return FunctionExcuteReader("select * from DonatorInformation where PhoneNumber = 'PhoneNumber'");

        }
        public object DeleteDonator(Donator D)
        {
            // First delete from Donators table
            object NumberOfRowsAffected1 = FunctionExcuteNonQuery($"DELETE FROM Donators WHERE DonatorID=(SELECT PersonID FROM Persons WHERE PhoneNumber=N'{D.PhoneNumber}')");

            // Then delete from Persons table
            object NumberOfRowsAffected2 = FunctionExcuteNonQuery($"DELETE FROM Persons WHERE PhoneNumber=N'{D.PhoneNumber}'");

            return NumberOfRowsAffected1;
        }
        public object UpdateDonator(Donator D)
        {
            // First update the Donators table
            object NumberOfRowsAffected1 = FunctionExcuteNonQuery($"UPDATE Donators SET Address=N'{D.Address}', Job=N'{D.Job}', Email=N'{D.U_Email}', DonationAmount=N'{D.DonationAmount}', Notes=N'{D.Notes}' WHERE DonatorID=(SELECT PersonID FROM Persons WHERE PhoneNumber=N'{D.PhoneNumber}')");

            // Then update the Persons table
            object NumberOfRowsAffected2 = FunctionExcuteNonQuery($"UPDATE Persons SET Fname=N'{D.Fname}', Lname=N'{D.Lname}', PhoneNumber=N'{D.PhoneNumber}' WHERE PhoneNumber=N'{D.PhoneNumber}'");

            return NumberOfRowsAffected1;
        }

    }
}
