using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
	static class BookDB
	{
		public static List<Book> GetAllBooks()
		{
			BookContext context = new BookContext();
			//gets all books like student db gets all students but in different syntax.
			List<Book> allBooks = (from b in context.Book select b).ToList();
			return allBooks;
		}

		/// <summary>
		/// adds book to the database
		/// </summary>
		/// <param name="b">The book to be added!</param>
		public static void Add(Book b)
		{
			//create context
			BookContext context = new BookContext();
			//add book to db
			context.Book.Add(b);
			//saves changes
			context.SaveChanges();
		}


		/* EF will track an object if you pull it out of a database and than do modifications*/
		public static void Update(Book b)
		{
			//create db context
			BookContext context = new BookContext();
			//get book from database
			// book = from the book table find the book with b's isbn number.
			Book originalBook = context.Book.Find(b.ISBN);
			originalBook.Price = b.Price;
			originalBook.Title = b.Title;

			context.SaveChanges();
		}

		public static void UpdateAlternate(Book b)
		{
			var context = new BookContext();
			//add book object to current context
			context.Book.Add(b);

			//let EF know the book already exists.  // this will modify the old one with everything that b has.
			context.Entry(b).State = EntityState.Modified;

			context.SaveChanges();
		}

		public static void Delete(Book b)
		{
			var context = new BookContext();
			//lets the context know that b is in it.
			context.Book.Add(b);

			context.Entry(b).State = EntityState.Deleted;
		}

		//Connected scenario where the DB context
		//tracks entities in memory
		public static void Delete(string isbn)
		{
			var context = new BookContext();
			//pull book from DB to make EF track it.
			Book bookToDelete = context.Book.Find(isbn);
			//mark book as deleted
			context.Book.Remove(bookToDelete);

			context.SaveChanges();
		}
	}
}
