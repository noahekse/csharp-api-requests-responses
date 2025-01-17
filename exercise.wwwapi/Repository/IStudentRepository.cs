using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        Student Get(string name);
        IEnumerable<Student> GetAll();
        Student Update(string name);

        bool Delete(string name);
    }
}
