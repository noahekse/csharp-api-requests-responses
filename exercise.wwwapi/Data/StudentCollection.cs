using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel.Student;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
            
        };

        public Student Get(string name)
        {
            return _students.FirstOrDefault(s => s.FirstName == name);
        }

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public bool Remove(string name)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == name);
            return _students.Remove(student);
        }

      

        public List<Student> getAll()
        {
            return _students.ToList();
        }
    };


}
