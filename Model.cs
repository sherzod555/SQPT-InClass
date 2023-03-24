using System;
using System.Collections.Generic;

namespace UM.Services
{
    public class ViewModelDemoVM
    {
        public List<Course> allCourses { get; set; }
        public List<Student> allStudents { get; set; }
        public List<Faculty> allFaculties { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<Course> AllotedCourses { get; set; }
    }

    public class Student
    {
        public int EnrollmentNo { get; set; }
        public string StudentName { get; set; }
        public List<Course> EnrolledCourses { get; set; }
    }
}
