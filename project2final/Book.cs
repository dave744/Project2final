using System;

namespace BookLibraryApp
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            PublicationYear = year;
        }

        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nPublished: {PublicationYear}";
        }

        public string ToFileString()
        {
            return $"{Title}|{Author}|{PublicationYear}";
        }
    }
}
