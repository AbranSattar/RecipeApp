using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    internal class User
    {
        /*CREATE TABLE tblUser (
        UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
        FirstName VARCHAR(30),
LastName VARCHAR(50),
Email VARCHAR(255),
UserName VARCHAR(255),
RoleID int NOT NULL FOREIGN KEY REFERENCES tblRole(RoleID),
Password VARCHAR(255));
GO*/
        public int userID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int roleID { get; set; }
        public string Password { get; set; }
        
        public User(int uID, string Fname, string Lname, string Uname, int rID, string Pword)
        {
            userID = uID;
            FirstName = Fname;
            LastName = Lname;
            UserName = Uname;
            roleID = rID;
            Password = Pword;
        }

    }
}
