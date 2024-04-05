using System;
using System.Collections.Generic;

public class Library
{
    string Name, Address;
    List<Book> Books;
    List<MediaItem> MediaItems;

    public Library(string Name, string Address, List<Book> Books, List<MediaItem> MediaItems)
    {
        this.Name = Name;
        this.Address = Address;
        this.Books = Books;
        this.MediaItems = MediaItems;
    }
    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine("Books : ");

        foreach (Book book in Books)
        {
            Console.WriteLine($"{book.Title}");
        }

        Console.WriteLine("Media Items: ");

        foreach (MediaItem media in MediaItems)
        {
            Console.WriteLine($"{media.Title}");
        }
    }

   
}

public class Book
{
    public string Title, Author, ISBN;
    public int PublicationYear;

    public Book(string Title, string Author, string ISBN, int PublicationYear)
    {
        this.Title = Title;
        this.Author = Author;
        this.ISBN = ISBN;
        this.PublicationYear = PublicationYear;
    }
}

public class MediaItem
{
    public string Title, MediaType;
    public int Duration;

    public MediaItem(string Title, string MediaType, int Duration)
    {
        this.Title = Title;
        this.MediaType = MediaType;
        this.Duration = Duration;
    }
}

public class Programm
{
    public static void Main()
    {
        Book book1 = new Book("Tech", "Jack", "1234", 2020);
        Book book2 = new Book("Romans", "set", "1234", 2021);
        Book book3 = new Book("git", "hub", "33", 2014);

        List<Book> books = new List<Book> { book1, book2, book3 };

        MediaItem item1 = new MediaItem("toplean", "CD", 20);
        MediaItem item2 = new MediaItem("checker", "DVD", 10);
        MediaItem item3 = new MediaItem("angel", "speaker", 30);

        List<MediaItem> items = new List<MediaItem> { item1, item2, item3 };
        Library Library1 = new Library("Balme", "Feteg st", books, items);

        Library1.AddBook(book3);
        Library1.PrintCatalog();
        Library1.RemoveBook(book3);
        Library1.PrintCatalog();
        Library1.RemoveMediaItem(item2);
        Library1.PrintCatalog();
    }
}
