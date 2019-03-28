using System.Collections.Generic;
using System;
namespace console_library.Models
{
  public class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }
    private List<Book> Books { get; set; }

    public List<Book> CheckedOut { get; set; }

    public void PrintBooks()
    {
      for (int i = 0; i < Books.Count; i++)
      {
        System.Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author}");
      }
    }
    public void AddBook(Book book)
    {
      Books.Add(book);
    }
    public void Checkout(string selection)
    {
      Book selectedBook = ValidateBook(selection, Books);
      if (selectedBook == null)
      {
        Console.Clear();
        System.Console.WriteLine("Invalid Selection");
        return;
      }
      else
      {
        selectedBook.Available = false;
        CheckedOut.Add(selectedBook);
        Books.Remove(selectedBook);
        System.Console.WriteLine($"You have successfully check out{ selectedBook.Title}");
      }
    }
    private Book ValidateBook(string selection, List<Book> booklist)
    {
      int bookIndex;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 0 || bookIndex > Books.Count)
      {
        return null;
      }
      return booklist[bookIndex - 1];
    }

    public Library(string location, string name)
    {
      Location = location;
      Name = name;
      Books = new List<Book>();
      CheckedOut = new List<Book>();
    }
  }
}