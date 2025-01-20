using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel.Student;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        Student Get(string name);
        IEnumerable<Student> GetAll();
        void Update(string name, StudentDto model);

        Student Delete(string name);
    }
}
