using Course_managment.Enums;
using System;

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
            Console.WriteLine("\n1 - Create group");
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
                Console.WriteLine("Is education offline? (y / n)\n");
                string education = Console.ReadLine();
                Console.Clear();

                if (education.ToLower().Trim() == "y")
                {
                    isOnline = false;
                    Course.CreateGroup((Categories)category, isOnline);
                }
                else if (education.ToLower().Trim() == "n")
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
            Course.ShowAllGroups();
            Console.WriteLine("\nEnter group no:");
            string oldNo = Console.ReadLine();
            Console.WriteLine("\nEnter new group no:");
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
            Course.ShowAllGroups();
            Console.WriteLine("\nEnter group no:");
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
            Course.ShowAllGroups();

            Console.WriteLine("\nEnter name:");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter surname:");
            string surname = Console.ReadLine();

            string fullName;

            if (NameCondition(name) && NameCondition(surname))
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
            Console.WriteLine("\nSelect type of student (G - Guaranteed / U - Unsecured)");
            string educationType = Console.ReadLine();
            Console.Clear();

            if (fullName != null && GroupNoCondition(no))
            {
                if (educationType.ToLower().Trim() == "guaranteed" || educationType.ToLower().Trim() == "g")
                {
                    type = true;
                    Course.CreateStudent(fullName, no.ToUpper().Trim(), type);
                }
                else if (educationType.ToLower().Trim() == "unsecured" || educationType.ToLower().Trim() == "u")
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
            Course.ShowAllStudents();

            Console.WriteLine("\nEnter group no:");
            string no = Console.ReadLine();

            ushort id;
            Console.WriteLine("\nEnter student ID:");
            bool result = ushort.TryParse(Console.ReadLine(), out id);
            Console.Clear();

            if (result)
            {
                Course.DeleteStudent(no, id);
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
            else
            {
                Console.WriteLine("Welcome back:)");
                return false;
            }
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

        public static bool NameCondition(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            foreach (char item in name)
            {
                if (!char.IsLetter(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}