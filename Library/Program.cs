using System;
using System.Collections.Generic;

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
						EntryBook();
					} else if (int.Parse(choice) == 3) {
						IssueBook();
					} else if (int.Parse(choice) == 4) {
						ReturnBook();
					} else if (int.Parse(choice) == 5) {
						CheckFine();
					} else if (int.Parse(choice) == 6) {
						ReceiveFine();
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
		public static void EntryBook()
		{

		}
		public static void IssueBook()
		{

		}
		public static void ReturnBook()
		{

		}
		public static void CheckFine()
		{

		}
		public static void ReceiveFine()
		{

		}




	}
}
