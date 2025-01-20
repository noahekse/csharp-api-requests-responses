using exercise.wwwapi.Data;
using exercise.wwwapi.DTO.Language;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel.Student;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _books;
        public BookRepository() 
        {
            _books = new BookCollection();
        }

        public Book Add(BookDto model)
        {
            return _books.Add(model);
        }

        public Book Delete(int id)
        {
            return _books.Remove(id);
        }

        public Book Get(int id)
        {
            return _books.Get(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.GetAll();
        }

        public void Update(int id, BookDto model)
        {
            _books.Update(id, model);
        }
    }
}
