using bai2ll.Data;
using bai2ll.Models.Domain;
using bai2ll.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Example.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _dbContext;

        public StudentRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Student> GetAll()
        {
            return _dbContext.Students;
        }

        public VMStudent? GetStudentsById(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                var genderVm = student.Gender ? "male" : "female";

                return new VMStudent
                {
                    Id = id,
                    Name = student.Name,
                    Birth = student.Birth,
                    ImgUrl = student.ImgUrl,
                    Gender = genderVm,
                    Mssv = student.Mssv,
                    Description = student.Description
                };
            }
            return null;
        }

        public void UpdateStudentById(int id, VMStudent model)
        {
            var student = _dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                student.Name = model.Name;
                student.Birth = model.Birth;
                student.Gender = model.Gender == "male";
                student.ImgUrl = model.ImgUrl;
                student.Mssv = model.Mssv;
                student.Description = model.Description;

                _dbContext.Update(student);
                _dbContext.SaveChanges();
            }
        }

        public void AddStudent(VMStudent model)
        {
            var student = new Student
            {
                Name = model.Name,
                Birth = model.Birth,
                Gender = model.Gender == "male",
                ImgUrl = model.ImgUrl,
                Mssv = model.Mssv,
                Description = model.Description
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void DeleteStudentById(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
        }
    }
}
