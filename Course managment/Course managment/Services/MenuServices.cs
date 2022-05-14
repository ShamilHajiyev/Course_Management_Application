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
            Console.WriteLine("1 - Create group");
            Console.WriteLine("2 - Show all groups");
            Console.WriteLine("3 - Edit group");
            Console.WriteLine("4 - Show students in group");
            Console.WriteLine("5 - Show all students");
            Console.WriteLine("6 - Create student");
            Console.WriteLine("7 - Delete student");
            Console.WriteLine("0 - Exit");
        }
        
        public static bool ExitMenu()
        {
            Console.WriteLine("Press 0 again to quit program");
            string confirmation = Console.ReadLine();
            Console.Clear();
            if (confirmation == "0")
            {
                Console.WriteLine("Bye:)");
                return true;
            }
            return false;
        }

        public static void CreateGroupMenu()
        {
            object category;
            Console.WriteLine("Select category:\n1 - Programming\n2 - Design\n3 - System_Administration\n4 - Digital_Marketing");
            bool categoryResult = Enum.TryParse(typeof(Categories), Console.ReadLine(), out category);
            if (!categoryResult)
            {
                ErrorMessage();
            }
            else
            {
                bool isOnline;
                Console.WriteLine("Select form of education(Offline/Online)");
                string education = Console.ReadLine();
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
            ushort oldNo;
            Console.WriteLine("Enter group no:");
            bool oldNoResult = ushort.TryParse(Console.ReadLine(), out oldNo);
            ushort newNo;
            Console.WriteLine("Enter new group no:");
            bool newNoResult = ushort.TryParse(Console.ReadLine(), out newNo);

            if (!(oldNoResult && newNoResult))
            {
                ErrorMessage();
            }
            else if (oldNo < 100 || oldNo > 999 || newNo < 100 || newNo > 999)
            {
                Console.WriteLine("Group no must be chosen between 100 and 999");
            }
            else
            {

            }
            Course.EditGroup(oldNo, newNo);
        }

        public static void ShowStudentsInGroupMenu()
        {
            Console.WriteLine("Enter group no:");
            string no = Console.ReadLine();
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
            Console.WriteLine("Enter surname:");
            string surname = Console.ReadLine();
            string fullName = name + surname;
            Console.WriteLine("Enter group no:");
            string no = Console.ReadLine();
            bool type;
            Console.WriteLine("Select type of student(Guaranteed/Unsecured)");
            string educationType = Console.ReadLine();
            if (educationType.ToLower().Trim() == "guaranteed")
            {
                type = true;
                Course.CreateStudent(fullName, no, type);
            }
            else if (educationType.ToLower().Trim() == "unsecured")
            {
                type = false;
                Course.CreateStudent(fullName, no, type);
            }
            else
            {
                ErrorMessage();
            }
        }

        public static void DeleteStudentMenu()
        {
            ushort id;
            Console.WriteLine(Actions.Delete_Student);
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("Something went wrong:(");
        }
    }
}
