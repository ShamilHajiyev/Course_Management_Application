using Course_managment.Enums;
using Course_managment.Interfaces;
using Course_managment.Models;
using System;
using System.Collections.Generic;

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
            else if(group.No != null)
            {
                _groups.Add(group);
                Console.WriteLine("Group successfully created");
            }
            else
            {
                Console.WriteLine("Group can not be created");
            }
        }

        public void ShowAllGroups()
        {
            if (_groups.Count == 0)
            {
                Console.WriteLine("There is no group here yet");
            }
            else
            {
                foreach (Group group in _groups)
                {
                    Console.WriteLine(group.ToString());
                }
            }
        }

        public void EditGroup(string oldNo, string newNo)
        {
            if (FindGroup(oldNo) == null)
            {
                Console.WriteLine("Group doesn't exist");
            }
            else if(FindGroup(newNo) != null)
            {
                Console.WriteLine("Group already exists");
            }
            else
            {
                newNo = newNo.ToUpper().Trim();
                FindGroup(oldNo).No = newNo;
                Console.WriteLine($"Group {newNo} successfully edited");
            }
        }

        public void ShowStudentsInGroup(string no)
        {
            if (FindGroup(no) != null)
            {
                if (FindGroup(no).Students.Count == 0)
                {
                    Console.WriteLine("There is no student here yet");
                }
                foreach (Student student in FindGroup(no).Students)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            else
            {
                MenuServices.ErrorMessage();
            }
        }

        public void ShowAllStudents()
        {
            foreach (Group group in _groups)
            {
                foreach (Student student in group.Students)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }

        public Student CreateStudent(string fullName, string groupNo, bool type)
        {
            Student student = new Student(fullName, groupNo, type);

            if (FindGroup(groupNo) == null)
            {
                MenuServices.ErrorMessage();
                return null;
            }

            if (FindGroup(groupNo).Students.Count < FindGroup(groupNo).Limit)
            {
                FindGroup(groupNo).Students.Add(student);
                Console.WriteLine($"{student.FullName} - {student.Id} successfully created");
                return student;
            }
            Console.WriteLine("Student can not be created");
            return null;
        }

        public void DeleteStudent(string no, ushort id)
        {
            if (FindStudent(no, id) != null)
            {
                Console.WriteLine($"{FindStudent(no, id)}  successfully deleted");
                FindGroup(no).Students.Remove(FindStudent(no, id));
            }
            else
            {
                MenuServices.ErrorMessage();
            }
        }

        public Group FindGroup(string no)
        {
            foreach (Group group in _groups)
            {
                if (no.ToUpper().Trim() == group.No.ToUpper().Trim())
                {
                    return group;
                }
            }
            return null;
        }

        public Student FindStudent(string no, ushort id)
        {
            if (FindGroup(no) == null)
            {
                return null;
            }
            foreach (Student student in FindGroup(no).Students)
            {
                if (id == student.Id)
                {
                    return student;
                }
            }
            return null;
        }
    }
}
