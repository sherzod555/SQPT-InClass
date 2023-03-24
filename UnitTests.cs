using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Services;

namespace TestProject1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestStudentCreate()
        {
            StudentService stdService = new StudentService();
            Student std1 = new Student() { };
            std1.EnrollmentNo = 15;
            std1.EnrolledCourses = new List<Course> { };
            std1.StudentName = "Ibroxim";

            stdService.AddNewStudent(std1);
            if (stdService.GetStudents().Exists((x) => x.StudentName == "Ibroxim"))
            {
                Assert.IsTrue(true);
            } else
            {
                Console.WriteLine("AddNewStudent methods is failed to add student");
                Assert.IsTrue(false);
            }

        }


        [TestMethod]
        public void TestStudentRemove()
        {
            StudentService stdService = new StudentService();

            var studentCount = stdService.GetStudents().Count;

            stdService.RemoveStudentByName("Diyora");

            var studentCountAfterDelete = stdService.GetStudents().Count;

            // method 1
            //Assert.IsFalse(stdService.GetStudents().Exists(x => x.StudentName == "Diyora"));


            // method 2
            //Assert.IsTrue(studentCount > studentCountAfterDelete);



            // method 3
            //if (stdService.GetStudents().Count == studentCount - 1)
            //{
            //    Assert.IsTrue(true);
            //}
            //else
            //{
            //    Console.WriteLine("RemoveStudentByName method failed to remove student");
            //    Assert.IsTrue(false);
            //}

            // method 4
            Assert.IsNull(stdService.GetStudents().Find(x => x.StudentName == "Diyora"));

        }

        [TestMethod]
        public void TestCourseCreate()
        {
            StudentService stdService = new StudentService();
            var count = stdService.GetCourses().Count;
            Course cr1 = new Course() { };
            cr1.CourseId = 15;
            cr1.CourseName = "UNIT TESTING COURSE";
            stdService.AddNewCourse(cr1);

            var countAfterAdd = stdService.GetCourses().Count;

            Console.WriteLine("Count before: " + count.ToString());
            Console.WriteLine("Count after: " + countAfterAdd.ToString());

            Assert.AreNotEqual(count, countAfterAdd);

        }

        [TestMethod]
        public void TestAddStudentWithoutName()
        {
            StudentService stdService = new StudentService();
            Student std1 = new Student() { };
            std1.EnrollmentNo = 15;

            stdService.AddNewStudent(std1);
            if (stdService.GetStudents().Exists((x) => x.EnrollmentNo == 15))
            {
                Console.WriteLine("AddNewStudent method should not add student without name");
                Assert.IsTrue(false);
            }
            else
            {
                Assert.IsTrue(true);
            }

        }
        
        [TestMethod]
        public void TestEnrollStudent()
        {
            StudentService stdService = new StudentService();

            stdService.EnrollStudentIntoCourse("Abdullajon", 35);


            Assert.IsTrue(stdService.getStudentCourseByStudentName("Abdullajon").Exists(x => x.CourseId == 35));
        }
    }
}
