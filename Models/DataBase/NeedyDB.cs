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

        public object GetAllNeedy()
        {
            return (DataTable)FunctionExcuteReader("SELECT * FROM Needy");
        }

        public int GetNextNumberFromDatabase()
        {
            string query = "SELECT MAX(Number) FROM Needy";
            object result = FunctionExcuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                int maxNumber;
                if (int.TryParse(result.ToString(), out maxNumber))
                {
                    return maxNumber + 1;
                }
            }

            return 1; // Default value if the query doesn't return any result or there is an error
        }
        public string GenerateNeedyID(int number)
        {
            string year = DateTime.Now.Year.ToString();
            string formattedNumber = number.ToString();

            if (number < 10)
            {
                formattedNumber = "000" + formattedNumber;
            }
            else if (number < 100)
            {
                formattedNumber = "00" + formattedNumber;
            }
            else if (number < 1000)
            {
                formattedNumber = "0" + formattedNumber;
            }

            return year.Substring(year.Length - 2) + formattedNumber;
        }

        public int AddNewNeedy(Needy needy)
        {
            string query = "INSERT INTO Needy (Number, NeedyID, Fname, Mname, Lname, Familyname, SSN, PhoneNum, BirthDate, StreetAddress, floornum, Area, mark, Income, NumberOfFamilyMembers, AreaCode, Casetype, HealthStatus, EducationalState, SocialState, Job, AcceptStatus, Details, ImageDataPath, FrontidimgPath, BackidimgPath) " +
                            "VALUES (@Number, @NeedyID, @Fname, @Mname, @Lname, @Familyname, @SSN, @PhoneNum, @BirthDate, @StreetAddress, @floornum, @Area, @mark, @Income, @NumberOfFamilyMembers, @AreaCode, @Casetype, @HealthStatus, @EducationalState, @SocialState, @Job, @AcceptStatus, @Details, @ImageDataPath, @FrontidimgPath, @BackidimgPath)";

            SqlCommand command = new SqlCommand(query, Con);

            // Generate the Number value
            int nextNumber = GetNextNumberFromDatabase(); // Replace with your own logic to get the next available Number from the database

            command.Parameters.AddWithValue("@Number", nextNumber);

            // Generate the NeedyID value
            string needyID = GenerateNeedyID(nextNumber);

            command.Parameters.AddWithValue("@NeedyID", needyID);

            // Set the rest of the parameters
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
            string query = "UPDATE Needy SET Fname=@Fname, Mname=@Mname, Lname=@Lname, Familyname=@Familyname, SSN=@SSN, PhoneNum=@PhoneNum, Birthdate=@Birthdate, StreetAddress=@StreetAddress, floornum=@floornum, Area=@Area, mark=@mark, Income=@Income,  Casetype=@Casetype, NumberOfFamilyMembers=@NumberOfFamilyMembers, AreaCode=@AreaCode, HealthStatus=@HealthStatus, EducationalState=@EducationalState, SocialState=@SocialState, Job=@Job, Details=@Details,AcceptStatus=@AcceptStatus ,ImageDataPath=@ImageDataPath, FrontidimgPath=@FrontidimgPath, BackidimgPath=@BackidimgPath WHERE NeedyID=@NeedyID";

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
            command.Parameters.AddWithValue("@AcceptStatus", needy.AcceptStatus);
            command.Parameters.AddWithValue("@Details", needy.Details);
            command.Parameters.AddWithValue("@ImageDataPath", needy.ImageDataPath);
            command.Parameters.AddWithValue("@FrontidimgPath", needy.FrontidimgPath);
            command.Parameters.AddWithValue("@BackidimgPath", needy.BackidimgPath);
            command.Parameters.AddWithValue("@NeedyID", needy.NeedyID);



            return ExcuteCommand(command);
        }

        public List<Needy> GetNeedy(string needyid)
        {
            string query = "SELECT * FROM Needy WHERE NeedyID = '" + needyid + "'";



            DataTable dt = (DataTable)FunctionExcuteReader(query);   
            List<Needy> needyList = new List<Needy>();

            foreach (DataRow row in dt.Rows)
            {
                Needy needy = new Needy()
                {
                    Number = Convert.ToInt32(row["Number"]),
                    NeedyID = row["NeedyID"].ToString(),
                    Fname = row["Fname"].ToString(),
                    Mname = row["Mname"].ToString(),
                    Lname = row["Lname"].ToString(),
                    Familyname = row["Familyname"].ToString(),
                    SSN = row["SSN"].ToString(),
                    PhoneNum = row["PhoneNum"].ToString(),
                    StreetAddress = row["StreetAddress"].ToString(),
                    floornum = row["floornum"].ToString(),
                    Area = row["Area"].ToString(),
                    mark = row["mark"].ToString(),
                    Income = row["Income"].ToString(),
                    NumberOfFamilyMembers = row["NumberOfFamilyMembers"].ToString(),
                    AreaCode = row["AreaCode"].ToString(),
                    Casetype = row["Casetype"].ToString(),
                    HealthStatus = row["HealthStatus"].ToString(),
                    EducationalState = row["EducationalState"].ToString(),
                    SocialState = row["SocialState"].ToString(),
                    Job = row["Job"].ToString(),
                    AcceptStatus = row["AcceptStatus"].ToString(),
                    Details = row["Details"].ToString(),
                    ImageDataPath = row["ImageDataPath"].ToString(),
                    FrontidimgPath = row["FrontidimgPath"].ToString(),
                    BackidimgPath = row["BackidimgPath"].ToString()
                };

                needyList.Add(needy);
            }

            return needyList;
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
