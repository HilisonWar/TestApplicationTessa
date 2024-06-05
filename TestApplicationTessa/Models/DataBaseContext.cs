using Microsoft.EntityFrameworkCore;

namespace TestApplicationTessa.Models
{
    public class DataBaseContext : DbContext
    {
		public DbSet<Document> Documents { get; set; }

		public DbSet<Task> Tasks { get; set; }

		public DataBaseContext()
		{
			Database.EnsureCreated();
		}

	}
}
