using System;
using System.Collections.Generic;
using System.Text;

namespace UM.Services
{
    public class Repository
    {
        public List<Course> GetCourses()
        {
            return new List<Course> {
                            new Course () {  CourseId = 1, CourseName = "Chemistry"},
                            new Course () {  CourseId = 2, CourseName = "Physics"},
                            new Course () {  CourseId = 3, CourseName = "Math" },
                            new Course () {  CourseId = 4, CourseName = "Computer Science" }
    };
        }
        public List<Faculty> GetFaculties()
        {
            return new List<Faculty> {
                            new Faculty () {  FacultyId = 1, FacultyName= "BIS",
                                AllotedCourses = new List<Course>
                                {new Course () { CourseId = 1, CourseName = "Chemistry"},
                                                 new Course () { CourseId = 2, CourseName = "Physics"},
                                                 new Course () { CourseId = 3, CourseName = "Math"},
                            }},
                            new Faculty () {  FacultyId = 2, FacultyName= "BA" ,
                                AllotedCourses = new List<Course>
                                {new Course () { CourseId = 2, CourseName = "Physics"},
                                                 new Course () { CourseId = 4, CourseName = "Computer Science"}
                            }},
                            new Faculty () {  FacultyId = 3, FacultyName= "Economics",
                                AllotedCourses = new List<Course>
                                {new Course () { CourseId = 3, CourseName = "Math"},
                                                 new Course () { CourseId = 4, CourseName = "Computer Science"}
                            }}
    };
        }
        public List<Student> GetStudents()
        {
            List<Student> result = new List<Student> {
                                        new Student () { EnrollmentNo = 1, StudentName= "Aziz",
                                            EnrolledCourses = new List<Course>
                                            { new Course () { CourseId = 1, CourseName = "Chemistry"},
                                                              new Course () { CourseId = 2, CourseName = "Physics"}
                                                              
                                        }},

                                        new Student () {  EnrollmentNo = 2, StudentName= "Diyora",
                                            EnrolledCourses = new List<Course>
                                            { new Course () { CourseId = 2, CourseName = "Physics"} ,
                                                              new Course ()
                                                              { CourseId = 4, CourseName = "Computer Science"}
                                        }},

                                        new Student () {  EnrollmentNo = 3, StudentName= "Fotima",
                                            EnrolledCourses = new List<Course>
                                            {  new Course () { CourseId = 3, CourseName = "Math"},
                                                               new Course () { CourseId = 4, CourseName = "Computer Science"}
                                        }}
                                };

            return result;
        }
    }
}
