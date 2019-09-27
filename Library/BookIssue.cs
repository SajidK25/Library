using System;

namespace Library
{
	public class BookIssue
	{
<<<<<<< HEAD
		public int BookIssueId { get; set; }
=======
		public int Id { get; set; }
>>>>>>> 5479e32afa059482a6b5cf19c5bdeefe97f535d6
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public int BookId { get; set; }
		public Book Book { get; set; }
		public string Barcode { get; set; }
		public DateTime IssueDate { get; set; }
	}
}
