using System.ComponentModel.DataAnnotations;

namespace TestApplicationTessa.Models
{
	public class Document
	{
		[Key]
		public int ID { get; set; }

		public string Status { get; set; }

		public Task? ActiveTask { get; set; }

		public int? ActiveTaskId { get; set; }

		public List<Task> Tasks { get; set; }

	}
}
