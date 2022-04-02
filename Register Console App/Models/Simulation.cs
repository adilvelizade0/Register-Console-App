using System;
using static Register_Console_App.Helpers.Helper;

namespace Register_Console_App.Models
{
    public static class Simulation
    {
        public static void Start()
        {
            Group newGroup = null;
            Console.WriteLine("\n*-----------------------------------------------------------------------------------------------------------------------------*\n");
            var fullname = ReadLineStr("your fullname");
            var email = ReadLineStr("your email");
            TryAgain:
            var password = ReadLineStr("your password");
            Console.Clear();
            var user = new User(email,password,fullname);
            if (user.Password is null)
            {
                goto TryAgain;
            }
            Console.WriteLine("\n ✅  User created successfully\n");
            int choice;
            do
            {
                Console.WriteLine();
                choice = ReadLineInt("choice (Enter '0' to display the menu)");
                switch (choice)
                {
                    case 0:
                        Menu();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n*---------------------------------------------------------------------------------------------------------*\n");
                        user.ShowInfo();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n*---------------------------------------------------------------------------------------------------------*\n");
                        TryAgainGroupLimit:
                        var groupLimit = ReadLineInt("your group limit");
                        if (groupLimit is not (> 4 and < 19))
                        {
                            Console.Clear();
                            Console.WriteLine("\n ❌  Limit minimum 5 can be maximum 18.\n");
                            goto TryAgainGroupLimit;
                        }
                        TryAgainGroupNo:
                        var groupNo = ReadLineStr("your group no");
                        newGroup = new Group(groupNo,groupLimit);
                        if (newGroup.GroupNo is null)
                        {
                            Console.WriteLine("\n ❌  Must be 2 capital letters and 3 digits and must have 5 characters. For exp('AA123')\n");
                            goto TryAgainGroupNo;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n*---------------------------------------------------------------------------------------------------------*\n");
                        if (newGroup is null)
                        { 
                            Console.WriteLine("\n ❌  There is nothing yet\n");
                        }
                        else
                        {
                            Console.WriteLine("\n 0) Quit\n 1) Show all students\n 2) Get student by id\n 3) Add student\n");
                            switch (ReadLineInt("choice"))
                            {
                                case 0:
                                    Console.Clear();
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\n*---------------------------------------------------------------------------------------------------------*\n");
                                    if (newGroup.GetAllStudents() is null)
                                    {
                                        Console.WriteLine("\n ❌  There is nothing yet\n");
                                    }
                                    else
                                    {
                                        foreach (var std in newGroup.GetAllStudents())
                                        {
                                           std.StudentInfo();
                                        }
                                    }
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\n*---------------------------------------------------------------------------------------------------------*\n");
                                    var student = newGroup.GetStudent(ReadLineInt("student id"));
                                    student?.StudentInfo();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\n*---------------------------------------------------------------------------------------------------------*\n");
                                    newGroup.AddStudent(new Student(ReadLineStr("fullname"),ReadLineInt("point")));
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("\n ❌  There is no such command!");
                                    break;
                            } 
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n ✅  Program exited successfully");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n ❌  There is no such command!");
                        break;
                }
                
            } while (choice != 4);
        }
        
        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n _____ ______    _______    ________    ___  ___     \n|\\   _ \\  _   \\ |\\  ___ \\  |\\   ___  \\ |\\  \\|\\  \\    \n\\ \\  \\\\\\__\\ \\  \\\\ \\   __/| \\ \\  \\\\ \\  \\\\ \\  \\\\\\  \\   \n \\ \\  \\\\|__| \\  \\\\ \\  \\_|/__\\ \\  \\\\ \\  \\\\ \\  \\\\\\  \\  \n  \\ \\  \\    \\ \\  \\\\ \\  \\_|\\ \\\\ \\  \\\\ \\  \\\\ \\  \\\\\\  \\ \n   \\ \\__\\    \\ \\__\\\\ \\_______\\\\ \\__\\\\ \\__\\\\ \\_______\\\n    \\|__|     \\|__| \\|_______| \\|__| \\|__| \\|_______|");
            Console.WriteLine("\n*--------------------------------------------------------------*\n");
            Console.WriteLine(" 0) Show menu\n 1) Show info\n 2) Create new group\n 3) Enter the group\n 4) Exit program\n");
        }
    }
    
}