using Microsoft.EntityFrameworkCore;

namespace Library
{
	public class LibraryContext : DbContext
	{
		private string _connection;
		public LibraryContext()
		{
			_connection = @"Server=127.0.0.1,1433;Database=Library;User Id=sa;Password =R@@kin_007; ";
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connection);
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
<<<<<<< HEAD
			builder.Entity<BookIssue>()
				.HasKey(bi => new { bi.StudentId, bi.BookId });

=======
			builder.Entity<BookIssue>()
				.HasKey(bi => new { bi.StudentId, bi.BookId });
>>>>>>> ea663aee0c21f45270e2bf34d1a4fe9d0d0692a6
			builder.Entity<BookIssue>()
				.HasOne(bi => bi.Student)
				.WithMany(s => s.Books)
				.HasForeignKey(bi => bi.StudentId);

			builder.Entity<ReturnBook>()
				.HasKey(rb => new { rb.StudentId, rb.Barcode });
			builder.Entity<ReturnBook>()
				.HasOne(rb => rb.Student)
				.WithMany(s => s.rBooks)
				.HasForeignKey(rb => rb.StudentId);
			base.OnModelCreating(builder);
		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<BookIssue> BookIssues { get; set; }
		public DbSet<ReturnBook> ReturnBooks { get; set; }
	}
}
