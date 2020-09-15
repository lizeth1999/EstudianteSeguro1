using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIStudentSecurity.Controllers;
using APIStudentSecurity.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentSecurity.Tests.Controllers
{
    [TestClass]
    public class ApiStudent
    {
        [TestMethod]
        public void TestGetStudent()
        {
            //Arrange

            StudentsController studentsController = new StudentsController();

            //Act

            var listaEstudiantes = studentsController.GetStudents();

            //Assert

            Assert.IsNotNull(listaEstudiantes);

        }

        [TestMethod]
        public  void  TestPostStudent()
        {
            //ARRANGE
            StudentsController studentsController = new StudentsController();
            Students expected = new Students()
            {
                StudentID = 7,
                LastName = "Jimenez",
                FirstName = "Lizeth",
                EnrollmentDate = DateTime.Now
            };

            //ACT
            IHttpActionResult actionResult = studentsController.PostStudents(expected);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Students>;

            //ASSERT
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        //PUT
        [TestMethod]
        public void TestUpdateStudents()
        {
            StudentsController controller = new StudentsController();
            Students students = new Students()
            {
                StudentID = 7,
                LastName = "Jimenez",
                FirstName = "Lizeth",
                EnrollmentDate = DateTime.Now
            };
            IHttpActionResult actionResult = controller.PostStudents(students);
            var result = controller.PutStudents(students.StudentID, students) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        //DELETE
        [TestMethod]
        public void TestDeleteStudent()
        {
            //ARRANGE
            StudentsController controller = new StudentsController();
            Students students = new Students()
            {
                StudentID = 7,
                LastName = "Jimenez",
                FirstName = "Lizeth",
                EnrollmentDate = DateTime.Now
            };

            //ACT
            IHttpActionResult actionResultPost = controller.PostStudents(students);
            IHttpActionResult actionResultDelete = controller.DeleteStudents(students.StudentID);
            //ASSERT
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Students>));
        }
    }
}
