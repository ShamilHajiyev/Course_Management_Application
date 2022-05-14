using System;
using System.Collections.Generic;
using System.Text;

namespace Course_managment.Models
{
    class Student
    {
        public string FullName;
        public string GroupNo;
        public bool Type;
        public static ushort Id;

        static Student()
        {
            Id = 1000;
        }

        public Student(string fullName, string groupNo, bool type)
        {
            FullName = fullName;
            Type = type;
            GroupNo = groupNo;
            Id++;
        }

        public override string ToString()
        {
            return $"{FullName} - {Id}";
        }
    }
}
