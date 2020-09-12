using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIStudentSecurity.Models;

namespace APIStudentSecurity.Controllers
{
    public class StudentsController : ApiController
    {
        private DataContext db = new DataContext();

        [Authorize]
        // GET: api/Students
        public IQueryable<Students> GetStudents()
        {
            return db.Students;
        }

        [Authorize]
        // GET: api/Students/5
        [ResponseType(typeof(Students))]
        public IHttpActionResult GetStudents(int id)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [Authorize]
        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudents(int id, Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.StudentID)
            {
                return BadRequest();
            }

            db.Entry(students).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Authorize]
        // POST: api/Students
        [ResponseType(typeof(Students))]
        public IHttpActionResult PostStudents(Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(students);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = students.StudentID }, students);
        }

        [Authorize]
        // DELETE: api/Students/5
        [ResponseType(typeof(Students))]
        public IHttpActionResult DeleteStudents(int id)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            db.Students.Remove(students);
            db.SaveChanges();

            return Ok(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(int id)
        {
            return db.Students.Count(e => e.StudentID == id) > 0;
        }
    }
}