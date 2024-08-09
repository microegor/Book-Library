namespace Library
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public Book(string title, string author, string isbn, int year, string description)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            Description = description;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Year: {Year}, Description: {Description}";
        }
    }
}