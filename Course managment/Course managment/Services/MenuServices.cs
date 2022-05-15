using Course_managment.Enums;
using Course_managment.Interfaces;
using Course_managment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_managment.Services
{
    static class MenuServices
    {
        public static CourseServices Course;

        static MenuServices()
        {
            Course = new CourseServices();
        }

        public static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Create group");
            Console.WriteLine("2 - Show all groups");
            Console.WriteLine("3 - Edit group");
            Console.WriteLine("4 - Show students in group");
            Console.WriteLine("5 - Show all students");
            Console.WriteLine("6 - Create student");
            Console.WriteLine("7 - Delete student");
            Console.WriteLine("0 - Exit");
        }

        public static void CreateGroupMenu()
        {
            object category;
            Console.WriteLine("Select category:\n");
            Console.WriteLine("1 - Programming\n\n2 - Design\n\n3 - System_Administration\n\n4 - Digital_Marketing\n");
            bool categoryResult = Enum.TryParse(typeof(Categories), Console.ReadLine(), out category);
            Console.Clear();

            if (!categoryResult)
            {
                ErrorMessage();
            }
            else
            {
                bool isOnline;
                Console.WriteLine("Select form of education(Offline/Online)\n");
                string education = Console.ReadLine();
                Console.Clear();

                if (education.ToLower().Trim() == "offline")
                {
                    isOnline = false;
                    Course.CreateGroup((Categories)category, isOnline);
                }
                else if (education.ToLower().Trim() == "online")
                {
                    isOnline = true;
                    Course.CreateGroup((Categories)category, isOnline);
                }
                else
                {
                    ErrorMessage();
                }
            }
        }

        public static void ShowAllGroupsMenu()
        {
            Course.ShowAllGroups();
        }

        public static void EditGroupMenu()
        {
            Console.WriteLine("Enter group no:");
            string oldNo = Console.ReadLine();
            Console.WriteLine("Enter new group no:");
            string newNo = Console.ReadLine();
            Console.Clear();

            if (GroupNoCondition(newNo))
            {
                Course.EditGroup(oldNo, newNo);
            }
            else
            {
                Console.WriteLine("Group no must be started by a letter and all remained 3 characters must be numbers");
            }
        }

        public static void ShowStudentsInGroupMenu()
        {
            Console.WriteLine("Enter group no:");
            string no = Console.ReadLine();
            Console.Clear();
            Course.ShowStudentsInGroup(no);
        }

        public static void ShowAllStudentsMenu()
        {
            Course.ShowAllStudents();
        }
        public static void CreateStudentMenu()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter surname:");
            string surname = Console.ReadLine();

            bool nameExist = !(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name));
            bool surnameExist = !(string.IsNullOrEmpty(surname) || string.IsNullOrWhiteSpace(surname));
            string fullName;

            if (nameExist && surnameExist)
            {
                fullName = Capitalize(name) + " " + Capitalize(surname);
            }
            else
            {
                fullName = null;
            }

            Console.WriteLine("\nEnter group no:");
            string no = Console.ReadLine();

            bool type;
            Console.WriteLine("\nSelect type of student (Guaranteed/Unsecured)");
            string educationType = Console.ReadLine();
            Console.Clear();

            if (fullName != null && GroupNoCondition(no))
            {
                if (educationType.ToLower().Trim() == "guaranteed")
                {
                    type = true;
                    Course.CreateStudent(fullName, no.ToUpper().Trim(), type);
                }
                else if (educationType.ToLower().Trim() == "unsecured")
                {
                    type = false;
                    Course.CreateStudent(fullName, no.ToUpper().Trim(), type);
                }
                else
                {
                    ErrorMessage();
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        public static void DeleteStudentMenu()
        {
            ushort id;
            Console.WriteLine("Enter student ID:");
            bool remainedResult = ushort.TryParse(Console.ReadLine(), out id);
            Console.Clear();

            if (remainedResult)
            {
                Course.DeleteStudent(id);
            }
            else
            {
                ErrorMessage();
            }
        }

        public static bool ExitMenu()
        {
            Console.WriteLine("Press 0 again to quit program\n");
            string confirmation = Console.ReadLine();
            Console.Clear();
            if (confirmation == "0")
            {
                Console.WriteLine("Bye:)");
                return true;
            }
            return false;
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("Something went wrong:(");
        }

        public static string Capitalize(string word)
        {
            word = word.ToLower().Trim();
            if (word.Length > 1)
            {
                return char.ToUpper(word[0]) + word.Substring(1);
            }
            else
            {
                return Convert.ToString(char.ToUpper(word[0]));
            }
        }

        public static bool GroupNoCondition(string no)
        {
            if (no.Length != 4)
            {
                return false;
            }
            bool firstLetterResult = byte.TryParse(no[0].ToString(), out byte firstLetter);
            if (firstLetterResult)
            {
                return false;
            }
            bool remainedResult = ushort.TryParse(no.Substring(1), out ushort remained);
            if (!remainedResult)
            {
                return false;
            }
            return true;
        }
    }
}
