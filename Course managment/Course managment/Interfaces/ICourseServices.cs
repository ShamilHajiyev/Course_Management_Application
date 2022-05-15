using Course_managment.Enums;
using Course_managment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_managment.Interfaces
{
    interface ICourseServices
    {
        List<Group> Groups { get; }

        void CreateGroup(Categories category, bool isOnline);
        void ShowAllGroups();
        void EditGroup(string oldNo, string newNo);
        void ShowStudentsInGroup(string no);
        void ShowAllStudents();
        Student CreateStudent(string fullName, string groupNo, bool type);
        void DeleteStudent(string no, ushort id);
    }
}
