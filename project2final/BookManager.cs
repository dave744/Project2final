using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookLibraryApp
{
    public class BookManager
    {
        private List<Book> books = new List<Book>();
        private const string FilePath = "books.txt";

        public BookManager()
        {
            LoadFromFile();
        }

        public void Add(Book book)
        {
            books.Add(book);
            SaveToFile();
            Console.WriteLine("Book added ✔");
        }

        public void ShowAll()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books yet. Add a few first.");
                return;
            }

            Console.WriteLine("\n=== Stored Books ===\n");
            foreach (var b in books)
            {
                Console.WriteLine(b.ToString());
                Console.WriteLine();
            }
        }

        public void Search(string query)
        {
            var results = books.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine($"No books found with title matching '{query}'.");
                return;
            }

            Console.WriteLine($"\nFound {results.Count} result(s):\n");
            results.ForEach(b => Console.WriteLine(b + "\n"));
        }

        private void SaveToFile()
        {
            try
            {
                File.WriteAllLines(FilePath, books.Select(b => b.ToFileString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't save file... " + e.Message);
            }
        }

        private void LoadFromFile()
        {
            if (!File.Exists(FilePath)) return;

            try
            {
                foreach (var line in File.ReadAllLines(FilePath))
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3 && int.TryParse(parts[2], out int year))
                    {
                        books.Add(new Book(parts[0], parts[1], year));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading book file: " + e.Message);
            }
        }
    }
}
