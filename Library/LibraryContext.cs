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
			base.OnModelCreating(builder);
		}
		public DbSet<Student> Students { get; set; }
	}
}
