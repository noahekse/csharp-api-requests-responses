using exercise.wwwapi.DTO.Language;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel.Student;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        Book Add(BookDto model);
        Book Get(int id);
        IEnumerable<Book> GetAll();
        void Update(int id, BookDto model);

        Book Delete(int id);
    }
}
