using System;
using console_library.Models;

namespace library
{
  class Program
  {
    static void Main(string[] args)
    {

      Book whereTheSidewalkEnds = new Book("Where the Sidewalk Ends", "Shel Silverstein", true);
      Book theHobbit = new Book("The Hobbit", "J.R.R.Tolkien", true);
      Book theLionTheWitchAndTheWardrobe = new Book("The Lion, The Witch, and the Wardrobe", "C.S.Lewis", true);
      Book harryPotterAndTheSorcerersStone = new Book("Harry Potter and the Sorcerer's Stone", "J.K.Rowling", true);

      Library lb = new Library("Boise", "Library!");
      lb.AddBook(whereTheSidewalkEnds);
      lb.AddBook(theHobbit);
      lb.AddBook(theLionTheWitchAndTheWardrobe);
      lb.AddBook(harryPotterAndTheSorcerersStone);


      System.Console.WriteLine($"Welcome to the {lb.Name} in {lb.Location}.");
      System.Console.WriteLine("Select a book number to checkout (Q)uit, or (R)eturn a book");
      lb.PrintBooks();

      string selection = Console.ReadLine();
      lb.Checkout(selection);
    }
  }
}
