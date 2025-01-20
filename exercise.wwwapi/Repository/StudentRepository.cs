using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel.Student;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _students;
        public StudentRepository() 
        {
            _students = new StudentCollection();
        }

        public Student Add(Student student)
        {
            _students.Add(student);
            return student;
        }

        public Student Delete(string name)
        {
            Student student = Get(name);
            return _students.Remove(name) ? student : new Student();
        }

        public Student Get(string name)
        {
            return _students.Get(name);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students.GetAll();
        }

        public void Update(string name, StudentDto model)
        {
           _students.Update(name, model);
        }
    }
}
