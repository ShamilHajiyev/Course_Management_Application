using Course_managment.Enums;
using Course_managment.Services;
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
            Number = 100;
        }

        public Group(Categories category, bool isOnline)
        {
            Category = category;
            switch (category)
            {
                case Categories.Programming:
                    No = "P" + Number;
                    break;
                case Categories.Design:
                    No = "D" + Number;
                    break;
                case Categories.System_Administration:
                    No = "S" + Number;
                    break;
                case Categories.Digital_Marketing:
                    No = "M" + Number;
                    break;
                default:
                    No = null;
                    MenuServices.ErrorMessage();
                    break;
            }
            Number++;

            IsOnline = isOnline;
            if (IsOnline)
            {
                Limit = 15;
            }
            else
            {
                Limit = 10;
            }
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return $"{No} - {Category} - {((IsOnline) ? "Online" : "Offline")} - Students: {Students.Count}/{Limit}";
        }
    }
}
