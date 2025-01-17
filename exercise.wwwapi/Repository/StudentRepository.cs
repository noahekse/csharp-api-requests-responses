using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel.Student;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentCollection _students;
        public StudentRepository() 
        {
            _students = new StudentCollection();
        }

        public Student Add(Student student)
        {
            _students.Add(student);
            return student;
        }

        public bool Delete(string name)
        {
            return _students.Remove(name);
        }

        public Student Get(string name)
        {
            return _students.Get(name);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students.getAll();
        }

        public Student Update(string name, StudentRequest model)
        {
            Student student = Get(name);
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            return student;
        }
    }
}
