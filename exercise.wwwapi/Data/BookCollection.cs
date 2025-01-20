using exercise.wwwapi.DTO.Language;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel.Student;

namespace exercise.wwwapi.Data
{

    public class BookCollection
    {
        private List<Book> books = new List<Book>(){
            new Book(1, "Book1", 32, "Author1", "Genre1"),
            new Book(2, "Book2", 543, "Author2", "Genre2"),
        };

        public Book Add(BookDto model)
        {
            int id = books.Count + 1;
            Book newBook = new Book(id, model.Title, model.NumPages, model.Author, model.Genre);
            books.Add(newBook);

            return newBook;
        }

        public Book Remove(int id)
        {
            Book book = books.FirstOrDefault(s => s.Id == id);
            books.Remove(book);

            return book;
        }

        public Book Get(int id)
        {
            return books.FirstOrDefault(s => s.Id == id);
        }

        public void Update(int id, BookDto model)
        {
            Book book = Get(id);
            book.Title = model.Title;
            book.NumPages = model.NumPages;
            book.Author = model.Author;
            book.Genre = model.Genre;

        }



        public List<Book> GetAll()
        {
            return books.ToList();
        }

        public List<Book> Books { get { return books; } }


    }
}
