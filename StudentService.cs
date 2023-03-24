using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UM.Services
{
    public class StudentService
    {
        Repository _repository;
        List<Course> _courses;
        List<Student> _students;
        List<Faculty> _faculties;
        public StudentService()
        {
             _repository = new Repository();
            //initialize DB
            _courses = _repository.GetCourses();
            _students = _repository.GetStudents();
            _faculties = _repository.GetFaculties();
        }

        public void AddNewStudent(Student student)
        {
            _students.Add(student);
        }

        public bool RemoveStudentByName(string name)
        {
            var item=_students.FirstOrDefault(s => s.StudentName == name);
            return _students.Remove(item);
        }


        public void EnrollStudentIntoCourse(string studentName, int? _courseId)
        {
            Student student = new Student()
            {
                EnrollmentNo = 1,
                StudentName = studentName,
                EnrolledCourses = new List<Course>
                { new Course() { CourseId = _courseId.Value, CourseName = "Computer Science" } }
            };
           
              _students.Add(student);        
                   
        }

        public void AddNewCourse(Course course)
        {
            _courses.Add(course);
        }

        public void AddNewFaculty(Faculty faculty)
        {
            _faculties.Add(faculty);
        }

        public List<Course> getStudentCourseByStudentName(string studentName)
        {
            var selectedStudentCourses = (from s in _students where s.StudentName == studentName select s.EnrolledCourses).FirstOrDefault();

            return selectedStudentCourses;
        }

        public List<Faculty> GetFaculties()
        {
            return _faculties; 
        }
        public List<Course> GetCourses()
        {
            return _courses;
        }
        public List<Student> GetStudents()
        {
            return _students;
        }

        public List<Student> StudentsToPVDemo(string courseName)
        {
            IEnumerable<Course> allCourses = _repository.GetCourses();
            var selectedCourseId = (from c in _courses where c.CourseName == courseName select c.CourseId).FirstOrDefault();

            IEnumerable<Student> allStudents = _students;
            return allStudents.Where(s => s.EnrolledCourses.Any(c => c.CourseId == selectedCourseId)).ToList();

        }

        public List<Faculty> FacultiesToPVDemo(string courseName)
        {
            IEnumerable<Course> allCourses = _courses;
            var selectedCourseId = (from c in allCourses where c.CourseName == courseName select c.CourseId).FirstOrDefault();

            IEnumerable<Faculty> allFaculties = _faculties;
            var facultiesForCourse = allFaculties.Where(f => f.AllotedCourses.Any(c => c.CourseId == selectedCourseId)).ToList();

            return facultiesForCourse;
        }

        public List<Faculty> FacultiesToTempDataDemo(string courseName)
        {
            var selectedCourseId = (from c in _courses where c.CourseName == courseName select c.CourseId).FirstOrDefault();

            IEnumerable<Faculty> allFaculties = _repository.GetFaculties();
            var facultiesForCourse = allFaculties.Where(f => f.AllotedCourses.Any(c => c.CourseId == selectedCourseId)).ToList();

            return facultiesForCourse;
        }


    }
}
