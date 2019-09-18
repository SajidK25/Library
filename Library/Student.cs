using System.Collections;
using System.Collections.Generic;

namespace Library
{
	public class Student
	{
		public int StudentID { get; set; }
		public string StudentName { get; set; }
		public decimal FineAmount { get; set; } = 0;
		public IList<BookIssue> Books { get; set; }
		public IList<ReturnBook> rBooks { get; set; }
	}
}
