using Course_managment.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_managment.Models
{
    class Group
    {
        public string No;
        public Categories Category;
        public bool IsOnline;
        public byte Limit;
        public List<Student> Students;
        public static ushort Number;

        static Group()
        {
            Number = 10;
        }

        public Group(Categories category, bool isOnline)
        {
            Category = category;
            No = Number + Enum.GetName(typeof(Categories),category);

            IsOnline = isOnline;
            Limit = 15;

            Students = new List<Student>();
        }

        public override string ToString()
        {
            return $"{No}";
        }
    }
}
