using System;
using System.Collections.Generic;
using System.Linq;

namespace Register_Console_App.Models
{
    public class Group
    {
        private List<Student> _students;
        private int? _studentLimit;
        
        public string GroupNo { get; set; }

        public int? StudentLimit
        {
            get => _studentLimit;
            set
            {
                if (value is > 4 and < 19)
                {
                    _studentLimit = value;
                }
                else
                {
                    _studentLimit = null;
                }
            }
        }

        private Group()
        {
            _students = new List<Student>(0);
        }

        public Group(string groupNo, int studentLimit):this()
        {
            GroupNo = CheckGroupNo(groupNo) ? groupNo : null;
            StudentLimit = studentLimit;
        }

        private static bool CheckGroupNo(string groupNo)
        {
            if (groupNo.Length != 5)
            {
                return false;
            }

            for (int i = 0; i < groupNo.Length ; i++)
            {
                if (i <= 1)
                {
                    if (Char.IsLetter(groupNo[i]))
                    {
                        if (Char.ToUpper(groupNo[i]) != groupNo[i])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (!Char.IsDigit(Convert.ToChar(groupNo[i])))
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public void AddStudent(Student student)
        {
            try
            {
                if (_students.Count == StudentLimit)
                {
                    throw new Exception("\n ❌  Crossed the employee limit\n");
                }
            
                _students.Add(student);
                Console.WriteLine("\n ✅  A student was successfully added\n");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public Student GetStudent(int? id)
        {
            try
            {
                if (id is null)  throw new NullReferenceException("\n ❌  Id can't be null\n");
                var student = _students.Find(student => student.StudentId == id);
                if (student is null)  throw new NullReferenceException("\n ❌  No results found\n");
                return student;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public List<Student> GetAllStudents()
        {
            return _students.Count != 0 ? _students : null;
        }
    }
}