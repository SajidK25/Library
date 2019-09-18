using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{

	class Program
	{
		
		static void Main(string[] args)
		{
			Console.WriteLine("*****************************************");
			Console.WriteLine("       Welcome to library system.        ");
			Console.WriteLine("*****************************************");	
			var context = new LibraryContext();
			LibraryDashboard();
			
			while (true) {
				var choice = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(choice)) {
					break;
				} else {
					if (int.Parse(choice) == 1) {
						EntryStudent(context);
						LibraryDashboard();

					} else if (int.Parse(choice) == 2) {
						EntryBook(context);
						LibraryDashboard();
					} else if (int.Parse(choice) == 3) {
						IssueBook(context);
						LibraryDashboard();
					} else if (int.Parse(choice) == 4) {
						ReturnBook(context);
						LibraryDashboard();
					} else if (int.Parse(choice) == 5) {
						//CheckFine();
						LibraryDashboard();
					} else if (int.Parse(choice) == 6) {
						//ReceiveFine();
						LibraryDashboard();
					} else {
						Console.WriteLine("Invalid option\nRetry !!!");
					}
				}
			}
			


		}

		public static void LibraryDashboard()
		{

			Console.WriteLine("Please enter your choice:");

			Console.WriteLine("# To entry student information enter: 1\n" +
							"# To entry book information enter: 2\n" +
							"# To issue a book, enter: 3\n" +
							"# To return a book enter: 4\n" +
							"# To check fine, enter: 5\n" +
							"# To receive fine, enter: 6");
			Console.WriteLine("Enter your choice (1-6) :");
			
		}
		public static void EntryStudent(LibraryContext context)
		{

			Console.WriteLine("Please enter student Id: _ :");
			var studentId = int.Parse(Console.ReadLine());
			Console.WriteLine("Please enter student name: _ :");
			var studentName = Console.ReadLine();
			Console.WriteLine("Please enter fine amount: _ :");
			var fineAmount = decimal.Parse(Console.ReadLine());
			context.Students.Add(new Student {
				StudentID=studentId,
				StudentName=studentName,
				FineAmount=fineAmount
			});
			context.SaveChanges();
			Console.WriteLine("Student Entry is succesful");

		}
		public static void EntryBook(LibraryContext context)
		{

			Console.WriteLine("Please enter Book Title: _ :");
			var title = Console.ReadLine();
			Console.WriteLine("Please enter Book Author: _ :");
			var author = Console.ReadLine();
			Console.WriteLine("Please enter Book Edition: _ :");
			var edition = Console.ReadLine();
			Console.WriteLine("Please enter Book Barcode: _ :");
			var barcode = Console.ReadLine();
			Console.WriteLine("Please enter Number of Copy: _ :");
			var copyCount = int.Parse(Console.ReadLine());
			context.Books.Add(new Book {
				Title=title,
				Author=author,
				Edition=edition,
				Barcode=barcode,
				CopyCount=copyCount
			});
			context.SaveChanges();
			Console.WriteLine("Book Entry is succesful");

		}
		public static void IssueBook(LibraryContext context)
		{
			Console.WriteLine("Issue to (student Id): _ :");
			var studentId = int.Parse(Console.ReadLine());
			Console.WriteLine("Issued Book (student Id): _ :");
			var bookId = int.Parse(Console.ReadLine());
			var issueDate = DateTime.Now;

			var student = context.Students.Where(s => s.StudentID == studentId).FirstOrDefault();
			var book = context.Books.Where(b => b.BookId == bookId).FirstOrDefault();
			var bookCount= context.Books
				.Where(b => b.BookId == bookId)
				.Select(b => b.CopyCount).ToList();
			var barcode = context.Books.Where(b => b.BookId == bookId).FirstOrDefault();

			if (bookCount[0] > 0 && student.StudentID==studentId && book.BookId==bookId) {
				
					context.BookIssues.Add(
					new BookIssue {
						StudentId = studentId,
						BookId = bookId,
						IssueDate = issueDate,
						Barcode= barcode.Barcode
					});

					book.CopyCount -= 1;
					context.SaveChanges();
					Console.WriteLine("BookID :{0} has issued to StudentID :{1} Successfully!",bookId,studentId);
				
				
			}

		}
		
		public static void ReturnBook(LibraryContext context)
		{
			Console.WriteLine("Return from (student Id): _ :");
			var studentId = int.Parse(Console.ReadLine());
			Console.WriteLine("Return Book (Barcode): _ :");
			var barcode = Console.ReadLine();
			var returnDate = DateTime.Now;

			
			
			var student = context.Students.Where(s => s.StudentID == studentId).FirstOrDefault();
			var issuedBook = context.BookIssues
				.Where(bi => bi.StudentId == studentId && bi.Barcode == barcode).FirstOrDefault();
			var book = context.Books.Where(b => b.BookId == issuedBook.BookId).FirstOrDefault();

			if (student.StudentID == studentId && issuedBook.Barcode == barcode) {

				context.ReturnBooks.Add(
				new ReturnBook {
					StudentId = studentId,
					Barcode=barcode,
					BookId=issuedBook.BookId,
					ReturnDate=returnDate
					
				});

				book.CopyCount += 1;
				context.SaveChanges();
				Console.WriteLine("BookID :{0} has returned From StudentID :{1} Successfully!", issuedBook.BookId, studentId);


			}
		}
		public static void CheckFine(LibraryContext context)
		{

		}
		public static void ReceiveFine(LibraryContext context)
		{

		}




	}
}
