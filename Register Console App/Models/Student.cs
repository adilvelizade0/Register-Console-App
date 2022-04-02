using System;

namespace Register_Console_App.Models
{
    public class Student
    {
        private static int _id;

        
        public int StudentId { get; private set; }
        public string FullName { get; set; }
        public double Point { get; private set; }

        static Student()
        {
            _id = 0;
        }

        private Student()
        {
            StudentId = ++ _id;
        }

        public Student(string fullName, double point):this()
        {
            FullName = fullName;
            Point = point;
        }

        public void StudentInfo()
        {
            Console.WriteLine($"\n Id: {StudentId.ToString()}\n 👥  Fullname: {FullName}\n Point: {Point.ToString()}\n");
        }
        
    }
}