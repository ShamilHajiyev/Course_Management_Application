using Course_managment.Enums;
using Course_managment.Models;
using Course_managment.Services;
using System;

namespace Course_managment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program");
            bool exit = false;
            bool result;
            byte selection;

            do
            {
                MenuServices.ShowMenu();
            Input:
                Console.WriteLine();
                result = byte.TryParse(Console.ReadLine(), out selection);
                Console.Clear();

                if (!result)
                {
                    MenuServices.ErrorMessage();
                    MenuServices.ShowMenu();
                    goto Input;
                }

                switch (selection)
                {
                    case (byte)Actions.Create_Group:
                        MenuServices.CreateGroupMenu();
                        break;
                    case (byte)Actions.Show_All_Groups:
                        MenuServices.ShowAllGroupsMenu();
                        break;
                    case (byte)Actions.Edit_Group:
                        MenuServices.EditGroupMenu();
                        break;
                    case (byte)Actions.Show_Students_In_Group:
                        MenuServices.ShowStudentsInGroupMenu();
                        break;
                    case (byte)Actions.Show_All_Students:
                        MenuServices.ShowAllStudentsMenu();
                        break;
                    case (byte)Actions.Create_Student:
                        MenuServices.CreateStudentMenu();
                        break;
                    case (byte)Actions.Delete_Student:
                        MenuServices.DeleteStudentMenu();
                        break;
                    case (byte)Actions.Exit:
                        exit = MenuServices.ExitMenu();
                        break;
                    default:
                        MenuServices.ErrorMessage();
                        break;
                }
            } while (!exit);
        }
    }
}
