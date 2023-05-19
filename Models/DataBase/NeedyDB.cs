using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CIE_206.Models.TableModel;

namespace CIE_206.Models.DataBase
{
    public class NeedyDB : DB
    {
        public NeedyDB() : base()
        {
        }

        public DataTable GetAllNeedy()
        {
            return (DataTable)FunctionExcuteReader("SELECT * FROM Needy");
        }

        public int AddNewNeedy(Needy needy)
        {
            string query = "INSERT INTO Needy (Fname, Mname, Lname, Familyname, SSN, PhoneNum, BirthDate, StreetAddress, floornum, Area, mark, Income, NumberOfFamilyMembers, AreaCode, Casetype, HealthStatus, EducationalState, SocialState, Job, AcceptStatus,Details, ImageDataPath, FrontidimgPath, BackidimgPath) " +
                            "VALUES (@Fname, @Mname, @Lname, @Familyname, @SSN, @PhoneNum, @BirthDate, @StreetAddress, @floornum, @Area, @mark, @Income, @NumberOfFamilyMembers, @AreaCode, @Casetype, @HealthStatus, @EducationalState, @SocialState, @Job,@AcceptStatus ,@Details, @ImageDataPath, @FrontidimgPath, @BackidimgPath)";

            SqlCommand command = new SqlCommand(query, Con);
            command.Parameters.AddWithValue("@Fname", needy.Fname);
            command.Parameters.AddWithValue("@Mname", needy.Mname);
            command.Parameters.AddWithValue("@Lname", needy.Lname);
            command.Parameters.AddWithValue("@Familyname", needy.Familyname);
            command.Parameters.AddWithValue("@SSN", needy.SSN);
            command.Parameters.AddWithValue("@PhoneNum", needy.PhoneNum);
            command.Parameters.AddWithValue("@BirthDate", needy.Birthdate);
            command.Parameters.AddWithValue("@StreetAddress", needy.StreetAddress);
            command.Parameters.AddWithValue("@floornum", needy.floornum);
            command.Parameters.AddWithValue("@Area", needy.Area);
            command.Parameters.AddWithValue("@mark", needy.mark);
            command.Parameters.AddWithValue("@Income", needy.Income);
            command.Parameters.AddWithValue("@NumberOfFamilyMembers", needy.NumberOfFamilyMembers);
            command.Parameters.AddWithValue("@AreaCode", needy.AreaCode);
            command.Parameters.AddWithValue("@Casetype", needy.Casetype);
            command.Parameters.AddWithValue("@HealthStatus", needy.HealthStatus);
            command.Parameters.AddWithValue("@EducationalState", needy.EducationalState);
            command.Parameters.AddWithValue("@SocialState", needy.SocialState);
            command.Parameters.AddWithValue("@Job", needy.Job);
            command.Parameters.AddWithValue("@AcceptStatus", needy.AcceptStatus);
            command.Parameters.AddWithValue("@Details", needy.Details);
            command.Parameters.AddWithValue("@ImageDataPath", needy.ImageDataPath);
            command.Parameters.AddWithValue("@FrontidimgPath", needy.FrontidimgPath);
            command.Parameters.AddWithValue("@BackidimgPath", needy.BackidimgPath);

            return ExcuteCommand(command);
        }


        public int UpdateNeedy(Needy needy)
        {
            string query = "UPDATE Needy SET Fname=@Fname, Mname=@Mname, Lname=@Lname, Familyname=@Familyname, SSN=@SSN, PhoneNum=@PhoneNum, Birthdate=@Birthdate, StreetAddress=@StreetAddress, floornum=@floornum, Area=@Area, mark=@mark, Income=@Income,  Casetype=@Casetype, NumberOfFamilyMembers=@NumberOfFamilyMembers, AreaCode=@AreaCode, HealthStatus=@HealthStatus, EducationalState=@EducationalState, SocialState=@SocialState, Job=@Job, Details=@Details, ImageDataPath=@ImageDataPath, FrontidimgPath=@FrontidimgPath, BackidimgPath=@BackidimgPath WHERE NeedyID=@NeedyID";

            SqlCommand command = new SqlCommand(query, Con);
            command.Parameters.AddWithValue("@Fname", needy.Fname);
            command.Parameters.AddWithValue("@Mname", needy.Mname);
            command.Parameters.AddWithValue("@Lname", needy.Lname);
            command.Parameters.AddWithValue("@Familyname", needy.Familyname);
            command.Parameters.AddWithValue("@SSN", needy.SSN);
            command.Parameters.AddWithValue("@PhoneNum", needy.PhoneNum);
            command.Parameters.AddWithValue("@Birthdate", needy.Birthdate);
            command.Parameters.AddWithValue("@StreetAddress", needy.StreetAddress);
            command.Parameters.AddWithValue("@floornum", needy.floornum);
            command.Parameters.AddWithValue("@Area", needy.Area);
            command.Parameters.AddWithValue("@mark", needy.mark);
            command.Parameters.AddWithValue("@Income", needy.Income);
            command.Parameters.AddWithValue("@Casetype", needy.Casetype);
            command.Parameters.AddWithValue("@NumberOfFamilyMembers", needy.NumberOfFamilyMembers);
            command.Parameters.AddWithValue("@AreaCode", needy.AreaCode);
            command.Parameters.AddWithValue("@HealthStatus", needy.HealthStatus);
            command.Parameters.AddWithValue("@EducationalState", needy.EducationalState);
            command.Parameters.AddWithValue("@SocialState", needy.SocialState);
            command.Parameters.AddWithValue("@Job", needy.Job);
            command.Parameters.AddWithValue("@Details", needy.Details);
            command.Parameters.AddWithValue("@ImageDataPath", needy.ImageDataPath);
            command.Parameters.AddWithValue("@FrontidimgPath", needy.FrontidimgPath);
            command.Parameters.AddWithValue("@BackidimgPath", needy.BackidimgPath);
           

            return ExcuteCommand(command);
        }


        public int DeleteNeedy(string needyID)
        {
            string query = "DELETE FROM Needy WHERE NeedyID=@NeedyID";

            SqlCommand command = new SqlCommand(query, Con);
            command.Parameters.AddWithValue("@NeedyID", needyID);

            return ExcuteCommand(command);
        }
    }
}
