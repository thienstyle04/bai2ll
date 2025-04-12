using bai2ll.Data;
using bai2ll.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace bai2ll.Controllers
{
    public class StudentController1 : Controller
    {
        private SchoolDbContext dbContext;
        public StudentController(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult GatAll()
        {
            IEnumerable<Student> allStudent = dbContext.Students;
            return View(allStudent);
        }

        public IActionResult GetStudentById(int id)
        {
            var StudentById =dbContext.Students.FirstOrDefault(p => p.Id == id);
            if(StudentById == null)
            {
                return NotFound("khong tim thay MSSV nay");
            }
            return View(StudentById);
        }
            [HttpGet]

        public IActionResult EditStudentById(int id)
        {
            return View();
        }
            [HttpPost]
        public IActionResult EditSrudentById([FromRoute] int id, VMStudent student)

        public IActionResult AddStudent()
            [HttpPost]

        public IActionResult AddStudent(VMStudent studentData)

        public IActionResult DelstudentById(int id)
    }
}
