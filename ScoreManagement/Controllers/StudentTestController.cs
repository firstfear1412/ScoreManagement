using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScoreManagement.Entity;
using ScoreManagement.Model.student_test;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTestController : ControllerBase
    {
        private readonly demoDB _context;

        public StudentTestController(demoDB context)
        {
            _context = context;
        }

        // GET: api/StudentTest/stu
        [AllowAnonymous]
        [HttpGet("stu")]
        public async Task<ActionResult<IEnumerable<student_test>>> GetAllStudents()
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            var students = new List<student_test>();  // ใช้ student_test แทน StudentTestController

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = @"SELECT * FROM student_test";  // ใช้ SQL Query ที่ต้องการ

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // อ่านข้อมูลจาก DataReader
                        while (await reader.ReadAsync())
                        {
                            var student = new student_test
                            {
                                row_id = reader.GetInt32(reader.GetOrdinal("row_id")),
                                student_code = reader.GetString(reader.GetOrdinal("student_code")),
                                student_name = reader.GetString(reader.GetOrdinal("student_name")),
                                university = reader.GetString(reader.GetOrdinal("university")),
                                faculty = reader.GetString(reader.GetOrdinal("faculty")),
                                major = reader.GetString(reader.GetOrdinal("major"))
                            };

                            students.Add(student);
                        }
                    }
                }
            }

            return Ok(students);
        }
    }
}

//        // GET: api/StudentTest/stu/{id}
//        [AllowAnonymous]
//        [HttpGet("stu/{id}")]
//        public ActionResult<student_test> GetStudentById(int id)
//        {
//            var student = _context.student_test.FirstOrDefault(s => s.row_id == id);
//            if (student == null) return NotFound("Student not found.");
//            return Ok(student);
//        }

//        // POST: api/StudentTest/stu
//        [HttpPost("stu")]
//        public ActionResult CreateStudent([FromBody] student_test newStudent)
//        {
//            if (newStudent == null) return BadRequest("Invalid data.");
//            _context.student_test.Add(newStudent);
//            _context.SaveChanges();
//            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.row_id }, newStudent);
//        }

//        // PUT: api/StudentTest/stu/{id}
//        [HttpPut("stu/{id}")]
//        public ActionResult UpdateStudent(int id, [FromBody] student_test updatedStudent)
//        {
//            var student = _context.student_test.FirstOrDefault(s => s.row_id == id);
//            if (student == null) return NotFound("Student not found.");

//            student.student_code = updatedStudent.student_code;
//            student.student_name = updatedStudent.student_name;
//            student.university = updatedStudent.university;
//            student.faculty = updatedStudent.faculty;
//            student.major = updatedStudent.major;

//            _context.SaveChanges();
//            return NoContent();
//        }

//        // DELETE: api/StudentTest/stu/{id}
//        [HttpDelete("stu/{id}")]
//        public ActionResult DeleteStudent(int id)
//        {
//            var student = _context.student_test.FirstOrDefault(s => s.row_id == id);
//            if (student == null) return NotFound("Student not found.");

//            _context.student_test.Remove(student);
//            _context.SaveChanges();
//            return NoContent();
//        }
//    }
//}
