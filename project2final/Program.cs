using System;
using BookLibraryApp;

var manager = new BookManager();

Console.WriteLine("=== Book Library ===");

while (true)
{
    Console.WriteLine("\n1. Add a Book");
    Console.WriteLine("2. View Books");
    Console.WriteLine("3. Search");
    Console.WriteLine("4. Quit");
    Console.Write("Choice: ");

    switch (Console.ReadLine())
    {
        case "1":
            AddBook();
            break;

        case "2":
            manager.ShowAll();
            break;

        case "3":
            Console.WriteLine();
            var q = InputHelper.ReadText("Title keyword: ");
            manager.Search(q);
            break;

        case "4":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

void AddBook()
{
    Console.WriteLine("\nAdding a new book...\n");
    string title = InputHelper.ReadText("Title: ");
    string author = InputHelper.ReadText("Author: ");
    int year = InputHelper.ReadYear("Year: ");

    manager.Add(new Book(title, author, year));
}
