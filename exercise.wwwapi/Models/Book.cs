namespace exercise.wwwapi.Models
{
    public class Book
    {
        private int _id;
        private string _title;
        private int _numPages;
        private string _author;
        private string _genre;

        public Book(int id, string title, int numPages, string author, string genre) 
        {
            _id = id;
            _title = title;
            _numPages = numPages;
            _author = author;
            _genre = genre;
        }
        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public int NumPages { get => _numPages; set => _numPages = value; }
        public string Author { get => _author; set => _author = value; }
        public string Genre { get => _genre; set => _genre = value; }

    }
}
