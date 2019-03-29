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
    public void PrintCheckedBooks()
    {
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        System.Console.WriteLine($"{i + 1} {CheckedOut[i].Title} - {CheckedOut[i].Author}");
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
        System.Console.WriteLine($"You have successfully checked out {selectedBook.Title}");
      }
    }
    public void ReturnBook(string selection)
    {
      Book selectedBook = ValidateBook(selection, CheckedOut);
      if (selectedBook == null)
      {
        bool selecting = true;
        while (selecting)
        {
          Console.Clear();
          System.Console.WriteLine("Invalid Selection");
          System.Console.WriteLine("Which book would you like to return?");
          PrintCheckedBooks();
          selection = Console.ReadLine();
          selectedBook = ValidateBook(selection, CheckedOut);
          if (selectedBook != null)
          {
            selecting = false;
          }
        }
      }
      selectedBook.Available = true;
      CheckedOut.Remove(selectedBook);
      Books.Add(selectedBook);
      System.Console.WriteLine($"You have successfully returned {selectedBook.Title}");
    }
    private Book ValidateBook(string selection, List<Book> booklist)
    {
      int bookIndex;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > booklist.Count)
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