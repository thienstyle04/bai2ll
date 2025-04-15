using bai2ll.Models.Domain;
using bai2ll.Models.ViewModel;


namespace Example.Models.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        VMStudent GetStudentsById(int id);
        void UpdateStudentById(int id, VMStudent model);
        void AddStudent(VMStudent model);
        void DeleteStudentById(int id);
    }
}
