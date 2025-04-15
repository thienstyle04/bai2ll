using bai2ll.Data;
using bai2ll.Models.Domain;
using bai2ll.Models.ViewModel;
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
         
           
                var Student = dbContext.Students.FirstOrDefault(p => p.Id == id);
                if (Student != null)
                {
                    string GenderVm;
                    if (Student.Gender == false) GenderVm = "female"; else GenderVm = "male";
                    var studentVM = new VMStudent()
                    {
                        Name = Student.Name,
                        Birth = Student.Birth,
                        ImgUrl = Student.ImgUrl,
                        Gender = GenderVm,
                        Mssv = Student.Mssv,
                        Description = Student.Description,
                    };
                    return View(studentVM);
                }
                else
                {
                    return View("NotFound");
                }

        }
        [HttpPost]
        public IActionResult EditSrudentById([FromRoute] int id, VMStudent student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["errorMessage"] = "Data is not valid";
                    return View(student);
                }

                var studentById = dbContext.Students.FirstOrDefault(p => p.Id == id);
                if (studentById == null)
                {
                    return View("NotFound");
                }

                studentById.Name = student.Name;
                studentById.Birth = student.Birth;
                studentById.Gender = student.Gender == "male";
                studentById.ImgUrl = student.ImgUrl;
                studentById.Mssv = student.Mssv;
                studentById.Description = student.Description;

                dbContext.SaveChanges();

                TempData["successMessage"] = "Update successful";
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(student);
            }

        }

        public IActionResult AddStudent()
        {
            return View();
        }

            [HttpPost]

        //public IActionResult AddStudent(VMStudent studentData)

        public IActionResult DelstudentById(int id)
        {
            var studentById = dbContext.Students.FirstOrDefault(n => n.Id == id);
            if (studentById == null)
            {
                return View("NotFound");
            }

            dbContext.Students.Remove(studentById);
            dbContext.SaveChanges();

            TempData["successMessage"] = "Deleted";
            return RedirectToAction("GetAll");

        }
    }
}
