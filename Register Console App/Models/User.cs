using System;
using Register_Console_App.Interfaces;

namespace Register_Console_App.Models
{
    public class User:IAccount
    {
        private static int _id;

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; private set; }

        static User()
        {
            _id = 0;
        }

        private User()
        {
            UserId = ++_id;
        }
        
        public User(string email, string password):this()
        {
            Email = email;
            Password = PasswordChecker(password.Trim()) ? password : null;
        }

        public User(string email, string password,string fullName):this(email,password)
        {
            FullName = fullName;
        }


        private static bool CheckInt(string password)
        {
            foreach (var chr in password)
            {
                if (char.IsDigit(chr))
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool PasswordChecker(string? password)
        {

            try
            {
                if (password is null)
                {
                    throw new NullReferenceException("\n ❌  Password can't be null!\n");
                }
                
                if (password.Length < 8)
                {
                    throw new Exception("\n ❌  The password must be at least 8 characters!\n");
                }
                
                if (Array.Exists(password.Split(separator: ""), str => str == str.ToLower()))
                {
                    throw new Exception("\n ❌  The password must contain at least 1 uppercase letter!\n");
                }

                if (Array.Exists(password.Split(separator: ""), str => str == str.ToUpper()))
                {
                    throw new Exception("\n ❌  The password must contain at least 1 lowercase letter!\n");
                }

                if (CheckInt(password))
                {
                    throw new Exception("\n ❌  The password must be at least 1 digit!\n");
                }
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\n Id: {UserId.ToString()}\n 👥  Fullname: {FullName}\n ✉️  Email: {Email}\n");
        }
    }
}