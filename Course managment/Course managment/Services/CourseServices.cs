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

        public CourseServices()
        {
            _groups = new List<Group>();
        }

        public void CreateGroup(Categories category, bool isOnline)
        {
            Group group = new Group(category, isOnline);
            if (FindGroup(group.No) != null)
            {
                Console.WriteLine("Group already exists");
            }
            else
            {
                _groups.Add(group);
                Console.WriteLine("Group successfully created");
            }
        }

        public void ShowAllGroups()
        {
            foreach (Group group in _groups)
            {
                Console.WriteLine(group.ToString());
            }
        }

        public void EditGroup(string oldNo, string newNo)
        {


            
            else if (oldNo < 100 || oldNo > 999)
            {
                Console.WriteLine("Group no must be chosen between 100 and 999");
            }
            else
            {

            }

            if (FindGroup(oldNo) == null)
            {
                "Group doesn't exist");
            }
            else if(FindGroup(newNo) != null)
            {
                Console.WriteLine("Group already exists");
            }
            else
            {

            }
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
