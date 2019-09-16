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
			LibraryDashboard();
			Console.WriteLine("Enter your choice (1-6) :");
			var choice = int.Parse(Console.ReadLine());
			if (choice == 1) {
				EntryStudent();
			}else if (choice == 2) {
				EntryBook();
			} else if (choice == 3) {
				IssueBook();
			} else if (choice == 4) {
				ReturnBook();
			} else if (choice == 5) {
				CheckFine();
			} else if (choice == 6) {
				ReceiveFine();
			} else {
				Console.WriteLine("Invalid option\nRetry !!!");
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
			

		}
		public static void EntryStudent()
		{
			Console.WriteLine("Please enter student Id: _ :");
			var StudentId = Console.ReadLine();
			Console.WriteLine("Please enter student name: _ :");
			var StudentName = Console.ReadLine();
			Console.WriteLine("Please enter fine amount: _ :");
			var FineAmount = Console.ReadLine();
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
