using Microsoft.EntityFrameworkCore;

namespace TestApplicationTessa.Models
{
    public class DataBaseContext : DbContext
    {
		public DbSet<Document> Documents { get; set; }

		public DbSet<Task> Tasks { get; set; }

		public DataBaseContext(DbContextOptions<DataBaseContext> options)
        {
			//Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Document>().HasMany(x => x.Tasks).WithOne(x => x.Document).HasForeignKey(x =>x.DocumentId).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Document>().HasOne(x => x.ActiveTask).WithOne(x => x.ActiveTaskDocument);

		}
		protected override void OnConfiguring(DbContextOptionsBuilder options) 
			=> options.UseSqlite("Data Source=tessaDB.db");

	}
}
