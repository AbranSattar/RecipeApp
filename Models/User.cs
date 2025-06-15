using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    internal class User
    {
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
