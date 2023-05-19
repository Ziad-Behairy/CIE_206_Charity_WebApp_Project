//using CIE_206.Models.TableModel;
//using System.Data;

using CIE_206.Models.TableModel;
using System.Data;

namespace CIE_206.Models.DataBase
{
    public class UsersDB : DB
    {

        public bool CheckIfEmailExist(string Email)
        {
            int num = (int)FunctionExcuteScalar("Select Count(*) from Users Where U_Email = '" + Email + "';");
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        public int CalculateUserAge(string date)
        {
            string dateString = date;
            DateTime givenDate = DateTime.Parse(dateString);
            DateTime currentDate = DateTime.Now;

            int yearsDiff = currentDate.Year - givenDate.Year;

            if (currentDate.Month < givenDate.Month || (currentDate.Month == givenDate.Month && currentDate.Day < givenDate.Day))
            {
                yearsDiff--;
            }
            return yearsDiff;
        }

        public int AddUser(Users u)
        {
            int num = (int)FunctionExcuteNonQuery("INSERT INTO Users(UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) VALUES ('" + u.UserType + "','" + u.Fname + "','" + u.Lname + "','" + u.U_Email + "','" + u.U_Password + "','" + u.PhoneNumber + "','" + u.Gender + "','" + u.BirthDate + "','" + u.Country + "')");

            u.UserID = (int)FunctionExcuteScalar("Select UserID from Users where U_Email = '" + u.U_Email + "';");
            return num;
        }

        public int CheckAcount(string Email, string Pass)
        {
            DataTable dt = (DataTable)FunctionExcuteReader("select * from Users where U_Email = '" + Email + "'");
            if (dt.Rows.Count == 0)
            {
                return -2;
            }
            else if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                if (row.Field<string>("U_Password") != Pass)
                {
                    return -1;
                }
                else if (row.Field<string>("UserType") == "A")
                {
                    return 1;
                }
                else if (row.Field<string>("UserType") == "E")
                {
                    return 2;
                }
                else if (row.Field<string>("UserType") == "DE")
                {
                    return 3;
                }
                else if (row.Field<string>("UserType") == "U")
                {
                    return 10;
                }
            }
            return 3;
        }


        public Users GetUserByID(int id)
        {
            DataTable QueryList = (DataTable)FunctionExcuteReader("SELECT * From Users Where Id = " + id);
            DataRow[] Rows = QueryList.Select();


            Users temp = new Users();

            foreach (DataRow row in Rows)
            {
                temp.UserID = row.Field<int>("UserId");
                temp.Fname = row.Field<string>("Fname");
                temp.Lname = row.Field<string>("Lname");
                temp.U_Email = row.Field<string>("U_Email");
                temp.U_Password = row.Field<string>("U_Password");
                temp.Gender = row.Field<string>("Gender");
                temp.Age = row.Field<string>("Age");
                temp.BirthDate = row.Field<string>("BirthDate");
                temp.CreateDate = row.Field<string>("CreateDate");
                temp.Country = row.Field<string>("Country");
            }

            return temp;
        }


        public Users GetUserWithEmail(string Email)
        {
            DataTable QueryList = (DataTable)FunctionExcuteReader("SELECT * FROM Users WHERE U_Email = '" + Email + "'");

            DataRow[] Rows = QueryList.Select();


            Users temp = new Users();

            foreach (DataRow row in Rows)
            {
                temp.UserID = row.Field<int>("UserId");
                temp.Fname = row.Field<string>("Fname");
                temp.Lname = row.Field<string>("Lname");
                temp.U_Email = row.Field<string>("U_Email");
                temp.U_Password = row.Field<string>("U_Password");
                temp.Gender = row.Field<string>("Gender");
                temp.Age = row.Field<string>("Age");
                temp.BirthDate = row.Field<string>("BirthDate");
                temp.CreateDate = row.Field<string>("CreateDate");
                temp.Country = row.Field<string>("Country");
            }

            return temp;
        }


        public void EditUser(Users u)
        {
            int NumberOfRowsAffected = (int)FunctionExcuteNonQuery("UPDATE Users SET Fname = '" + u.Fname + "', Lname = '" + u.Lname + "', U_Password = '" + u.U_Password + "', U_Email = '" + u.U_Email + "', UserType = '" + u.UserType + "' WHERE Id = " + u.UserID + ";");
            return;
        }


        public int DeleteUser(int id)
        {
            int NumberOfRowsAffected = (int)FunctionExcuteNonQuery("DELETE FROM Users WHERE Id = " + id);
            return NumberOfRowsAffected;
        }

        public DataTable GetAllUsers()
        {
            DataTable List = (DataTable)FunctionExcuteReader("SELECT * From Users");
            return List;
        }

    }
}
