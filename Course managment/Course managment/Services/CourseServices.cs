using Course_managment.Enums;
using Course_managment.Interfaces;
using Course_managment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_managment.Services
{
    class CourseServices : ICourseServices
    {
        List<Group> _groups;

        public List<Group> Groups => _groups;

        public Group CreateGroup(Categories category, bool isOnline)
        {
            _groups = new List<Group>();
            Group group = new Group(category, isOnline);
            _groups.Add(group);
            return group;
        }

        public void ShowAllGroups()
        {
            foreach (var item in _groups)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void EditGroup(string oldNo, string newNo)
        {
            FindGroup(oldNo).No = newNo;
        }

        public void ShowStudentsInGroup(string no)
        {
            foreach (Student student in FindGroup(no).Students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public void ShowAllStudents()
        {
            foreach (Group group in _groups)
            {
                ShowStudentsInGroup(group.No);
            }
        }

        public Student CreateStudent(string fullName, string groupNo, bool type)
        {
            Student student = new Student(fullName, groupNo, type);
            if (FindGroup(groupNo).Students.Count < FindGroup(groupNo).Limit)
            {
                FindGroup(groupNo).Students.Add(student);
                return student;
            }
            return null;
        }

        public void DeleteStudent(ushort id)
        {

        }

        public Group FindGroup(string no)
        {
            foreach (Group group in _groups)
            {
                if (no == group.No)
                {
                    return group;
                }
            }
            return null;
        }

        public Student FindStudent(ushort id)
        {
            foreach (Group group in _groups)
            {
                foreach (Student student in group.Students)
                {
                    if (id == Student.Id)
                    {
                        return student;
                    }
                }
            }
            return null;
        }
    }
}
