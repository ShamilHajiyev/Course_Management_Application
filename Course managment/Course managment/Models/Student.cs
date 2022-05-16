using System;

namespace Course_managment.Models
{
    class Student
    {
        public string FullName;
        public string GroupNo;
        public bool Type;
        public ushort Id;
        public static ushort IdNumber;

        static Student()
        {
            IdNumber = 1000;
        }

        public Student(string fullName, string groupNo, bool type)
        {
            FullName = fullName;
            Type = type;
            GroupNo = groupNo;
            Id = IdNumber;
            IdNumber++;
        }

        public override string ToString()
        {
            return $"{FullName} - {Id} - {GroupNo} - {((Type) ? "Guaranteed" : "Unsecured")}";
        }
    }
}
