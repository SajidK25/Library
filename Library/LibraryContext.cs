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
			builder.Entity<BookIssue>()
				.HasKey(bi => new { bi.StudentId,bi.BookId});
			builder.Entity<BookIssue>()
				.HasOne(bi => bi.Student)
				.WithMany(b => b.Books)
				.HasForeignKey(bi => bi.StudentId);
			base.OnModelCreating(builder);
		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<BookIssue> BookIssues { get; set; }
	}
}
