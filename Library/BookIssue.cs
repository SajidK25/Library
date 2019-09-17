using System;

namespace Library
{
	public class BookIssue
	{
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public int BookId { get; set; }
		public Book Book { get; set; }
		public DateTime IssueDate { get; set; }
	}
}
